namespace Porsche.Domain.Models;

public class AddingCarToPorscheCenter
{
    public int PorscheCenterId { get; set; }
    public int CarId;
}

public class AddingCarToSaved
{
    public int CarId { get; set; }
    public int  UserId { get; set; }
}