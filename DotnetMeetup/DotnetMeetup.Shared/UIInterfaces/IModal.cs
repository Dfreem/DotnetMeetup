using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.UIInterfaces;

public interface IModal
{
    ElementReference ModalRef { get; set; }
    public string Id { get; set; }

}
