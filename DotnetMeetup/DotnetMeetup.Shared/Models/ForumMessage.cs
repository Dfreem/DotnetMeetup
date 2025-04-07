using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Models;

public class ForumMessage
{
    public int Id { get; set; }
    public string OriginalPost { get; set; } = string.Empty;

    public ForumMessage? ParentMessage { get; set; }

    public ForumMessage[] Comments { get; set; } = [];

    public bool IsTopLevel { get; set; }

}
