using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DotnetMeetup.Shared.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddCommonServices();

await builder.Build().RunAsync();
