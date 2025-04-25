
using DotnetMeetup.Shared.Enums.UI;

using Microsoft.AspNetCore.Components;

namespace DotnetMeetup.Shared.Components.Base;

public class StyleableBaseComponent : ComponentBase
{
    [Parameter]
    public virtual string? Class { get; set; }

    [Parameter]
    public virtual string? Style { get; set; }

    [Parameter]
    public BootstrapColor? BgColor { get; set; }

}
