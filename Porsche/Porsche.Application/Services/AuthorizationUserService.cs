using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
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

    public async Task<string> RegisterUser(RegisterRequest request)
    {
        string userName = request.Email;

        var user = new UserEntity()
        {
            Email = request.Email,
            UserName = userName,
            FirstName = request.FirstName,
            SecondName = request.SecondName
        };
        
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            var roles = await userManager.GetRolesAsync(user);
            tokenService.AddRolesToClaims(authClaims, roles);

            return tokenService.CreateToken(authClaims);
        }

        throw new AuthenticationException("User already exists");
    }

    public async Task<string> LoginUser(LoginRequest request)
    {
        var loginModel = new LoginModel()
        {
            Email = request.Email,
            Password = request.Password
        };        
        
        var userByEmail = await userManager.FindByEmailAsync(loginModel.Email);

        if (userByEmail == null)
            throw new AuthenticationException("User does not exist");
        

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