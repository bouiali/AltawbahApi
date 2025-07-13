using Microsoft.AspNetCore.Mvc;

[ApiController]

[Route("subscribe")]

public class SubscribeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ReceiveSubscribe([FromForm] string Email)
    {
        await EmailService.SendSubscribe(Email); 
        return Ok("You subscribed successefully");
    }
}