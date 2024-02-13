using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure;
using Porsche.Infrastructure.DTOs;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class AuthorizationUserService : IAuthorizationUserService
{
    private readonly ITokenService tokenService;
    private readonly UserManager<UserEntity> userManager;
    private readonly SignInManager<UserEntity> signInManager;

    public AuthorizationUserService(ITokenService tokenService, UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
    {
        this.tokenService = tokenService;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<string> RegisterUser(RegisterModel registerModel)
    {
        string userName = registerModel.Email;

        var user = new UserEntity()
        {
            Email = registerModel.Email,
            UserName = userName,
            FirstName = registerModel.FirstName,
            SecondName = registerModel.SecondName
        };

        Console.WriteLine(user.Email, user.SecondName);

        var result = await userManager.CreateAsync(user, registerModel.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "ADMIN");
            var claims = await userManager.GetClaimsAsync(user);
            
            return tokenService.CreateToken(claims);
        }

        throw new AuthenticationException("User already exists");
    }

    public async Task<string> LoginUser(LoginModel loginModel)
    {
        var userByEmail = await userManager.FindByEmailAsync(loginModel.Email);

        if (userByEmail == null)
            throw new AuthenticationException("User do not exist");
        

        var result = await signInManager
            .PasswordSignInAsync(userByEmail.UserName, loginModel.Password, false, false);
        
        if (!result.Succeeded)
            throw new AuthenticationException("Wrong pass");

        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, loginModel.Email),
            new Claim(ClaimTypes.Name, userByEmail.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, userByEmail.Id.ToString())
        };

        var roles = await userManager.GetRolesAsync(userByEmail);
        
        foreach (var role in roles)
        {
            Console.WriteLine(role);
        }
        tokenService.AddRolesToClaims(authClaims, roles);
        var token = tokenService.CreateToken(authClaims);
        
        await userManager.UpdateAsync(userByEmail);

        return token;
    }
}