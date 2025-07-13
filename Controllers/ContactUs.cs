using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

public class MessageModel
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Message { get; set; } = "";
}

[ApiController]

[Route("contact")]

public class ContactController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ReceiveMessage([FromForm] MessageModel Message)
    {
        await EmailService.SendMessage(Message);

        return Ok($"We received your message successfully");
    }

    [HttpGet]
    public string returnok()
    {
        return ("hello world");
    }
}


