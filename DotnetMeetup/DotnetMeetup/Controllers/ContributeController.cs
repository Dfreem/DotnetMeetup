using DotnetMeetup.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMeetup.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContributeController : ControllerBase
{
    private readonly ILogger<ContributeController> _logger;

    public ContributeController(ILogger<ContributeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult SubmitTalk([FromBody] ContributeTalkDto talk)
    {
        _logger.LogInformation("Received talk proposal: {Title} by {Name}", talk.TalkTitle, talk.Name);
        // TODO: Save to database or email to organizer
        return Ok();
    }
}
