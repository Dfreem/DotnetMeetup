using System;

using DotnetMeetup.Shared.Enums.UI;

using Microsoft.AspNetCore.Components;

namespace DotnetMeetup.Shared.Services.ToastService
{
    public class ToastOptions
    {
        public ToastLocation Position { get; set; }
        /// <summary>
        /// Duration in milliseconds
        /// </summary>
        public int Interval { get; set; }
        public bool Markup { get; set; }

    }


}
