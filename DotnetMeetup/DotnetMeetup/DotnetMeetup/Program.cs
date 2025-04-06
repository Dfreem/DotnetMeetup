using DotnetMeetup.Components;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Logging

// might not be necessary
builder.Logging.AddSerilog();

// just log to the console for now
builder.Services.AddSerilog(config =>
{
    config.MinimumLevel.Information();
    config.WriteTo.Console();
});

#endregion

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DotnetMeetup.Client._Imports).Assembly);

app.Run();
