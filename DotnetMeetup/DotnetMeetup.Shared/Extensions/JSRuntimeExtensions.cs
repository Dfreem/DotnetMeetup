using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Extensions;

public static class JSRuntimeExtensions
{
    public static async Task ShowModal(this IJSRuntime js, ElementReference modalRef)
    {
        await js.InvokeVoidAsync("showModal", modalRef);
    }
    public static async Task HideModal(this IJSRuntime js, ElementReference modalRef)
    {
        await js.InvokeVoidAsync("hideModal", modalRef);
    }

    /// <summary>
    /// register event listeners for modal events. The <paramref name="dotnetObjectRef"/> should be a <see cref="DotNetObjectReference"/> holding a reference to the component class representing a modal.
    /// The parent contained in the referende should contain JSINvokable methods. Pass in the names of the JSInvokable methods which will be triggered on the  modals show and hide events respectively.
    /// </summary>
    /// <param name="js">an IJSRuntime reference from DI</param>
    /// <param name="modalRef">an element reference bound to the modal element</param>
    /// <param name="dotnetObjectRef">a DotnetObjectReference with JSInvokable methods</param>
    /// <param name="showMethodName">the name of the JSInvokable method to call ont he modal show event</param>
    /// <param name="hideMethodName">the name of the JSInvokable method to call ont he modal hide event</param>
    /// <returns></returns>
    public static async Task RegisterModalEvents(this IJSRuntime js, ElementReference modalRef, object dotnetObjectRef, string showMethodName, string hideMethodName)
    {
        await js.InvokeVoidAsync("registerModalEvents", modalRef, dotnetObjectRef, showMethodName, hideMethodName);
    }
}
