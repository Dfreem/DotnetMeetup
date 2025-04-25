
using DotnetMeetup.Shared.Enums.UI;

namespace DotnetMeetup.Shared.Services.ToastService;

#nullable enable

public class ToastService : IToastService
{
    List<Task> _queue = new();
    bool _isToasting = false;

    public event EventHandler<ToastEventArgs> ToastEvent = default!;

    public ToastLocation Location { get; set; }
    public ToastOptions? Options { get; set; }


    public void Success(string message, Action<ToastOptions>? optionBuilder = null)
    {
        ToastEventArgs? args = new(message, BootstrapColor.Success);
        if (optionBuilder is not null)
        {
            ToastOptions options = new();
            optionBuilder(options);
            if (options.Position == ToastLocation.None)
                options.Position = ToastLocation.Top;

            args = new(message, BootstrapColor.Success, options);
        }
        AddToQ(args);
    }

    public void Danger(string message, Action<ToastOptions>? optionBuilder = null)
    {
        ToastEventArgs? args = new(message, BootstrapColor.Danger);
        if (optionBuilder is not null)
        {
            ToastOptions options = new();
            optionBuilder(options);
            if (options.Position == ToastLocation.None)
                options.Position = ToastLocation.Top;

            args = new(message, BootstrapColor.Danger, options);
        }
        AddToQ(args);
    }

    public void Warning(string message, Action<ToastOptions>? optionBuilder = null)
    {

        ToastEventArgs? args = new(message, BootstrapColor.Warning);
        if (optionBuilder is not null)
        {
            ToastOptions options = new();
            optionBuilder(options);
            if (options.Position == ToastLocation.None)
                options.Position = ToastLocation.Top;

            args = new(message, BootstrapColor.Warning, options);
        }
        AddToQ(args);
    }

    private void AddToQ(ToastEventArgs args)
    {
        _queue.Add(RaiseToastEventAsync(args));
        if (!_isToasting)
            ProcessToastEventsAsync().GetAwaiter();

    }

    protected async Task RaiseToastEventAsync(ToastEventArgs args)
    {
        ToastEvent?.Invoke(this, args);
        await Task.CompletedTask;
    }

    private async Task ProcessToastEventsAsync()
    {
        _isToasting = true;
        while (_queue.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(_queue);
            _queue.Remove(finishedTask);
            await finishedTask;
        }
        _isToasting = false;
    }

}

#region Toast Event Args

public class ToastEventArgs : EventArgs
{

    public ToastEventArgs(string message = "", BootstrapColor color = BootstrapColor.Default, ToastOptions? options = null)
    {
        Message = message;
        CssClass = "toast-" + Enum.GetName(color)?.ToLower() ?? "warning";

        if (options is not null)
        {
            Location = options.Position;
            Markup = options.Markup;
            Duration = options.Interval;

        }

    }

    public string Message { get; set; }
    public int? Duration { get; set; }
    public string CssClass { get; set; } = "";
    public bool Markup { get; set; }
    public ToastLocation Location { get; set; } = ToastLocation.Top | ToastLocation.Center;
}

#endregion
