
using Microsoft.AspNetCore.Mvc;

public class PersonModel
{
    public string Gender { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string BornDate { get; set; } = "";
    public string PasseportNumber { get; set; } = "";
    public string PasseportExperationDate { get; set; } = "";
    public IFormFile Passeport { get; set; }

}
public class ReservationModel
{
    public string PackageType { get; set; } = "";
    public List<PersonModel> Persons { get; set; }
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string TrainBooking { get; set; } = "";
    public string WheelChairPusher { get; set; } = "";
    public string Notes { get; set; } = "";

}

[ApiController]

[Route("reserve")]

public class ReserveController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ReseiveReservation([FromForm] ReservationModel reservation)
    {
        await EmailService.SendReservation(reservation);
        return Ok("We are received your reservation successfully \n we will contact you as soon as possible.");   
    }
}