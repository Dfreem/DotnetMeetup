using DotnetMeetup.Shared.Enums.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Icon;
public interface IIcon<TIcon> where TIcon : struct, Enum
{
    IconVendor Vendor { get; set; }

    string CSS { get; set; }
}
