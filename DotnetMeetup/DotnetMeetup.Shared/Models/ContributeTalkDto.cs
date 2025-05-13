using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Models;

public class ContributeTalkDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string TalkTitle { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Notes { get; set; }
}
