using System;

using DotnetMeetup.Shared.Enums.UI;

using Microsoft.AspNetCore.Components;

namespace DotnetMeetup.Shared.Services.ToastService
{
    public interface IToastService
    {
        ToastLocation Location { get; set; }

        event EventHandler<ToastEventArgs> ToastEvent;

        void Danger(string message, Action<ToastOptions> optionBuilder);
        public void Success(string message, Action<ToastOptions> optionBuilder);
        void Warning(string message, Action<ToastOptions> optionBuilder);
    }
}
