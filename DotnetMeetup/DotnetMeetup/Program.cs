using DotnetMeetup.Components;
using DotnetMeetup.Components.Account;
using DotnetMeetup.Data;
using DotnetMeetup.Shared.Models;
using DotnetMeetup.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddControllers();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddHttpClient();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddCommonServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers(); 

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DotnetMeetup.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!db.Events.Any())
    {
        db.Events.AddRange(new List<Event>
        {
            new Event
            {
                Title = "Code Koans and Katas",
                Date = new DateTime(2025, 4, 23, 18, 0, 0),
                Location = "Deschutes Hall Room 220, UO",
                Description = "Michael Birchmeier guided us through Code Koans and Katas—interactive coding exercises for sharpening skills and deepening understanding."
            },
            new Event
            {
                Title = "ASP.NET Core MVC Workshop",
                Date = new DateTime(2025, 3, 12, 18, 0, 0),
                Location = "Deschutes Hall Room 220, UO",
                Description = "Presented by Joel Southall, this hands-on intro to ASP.NET Core MVC used EF Core and SQLite. We explored CRUD operations and MVC patterns in a practical .NET session."
            },
            new Event
            {
                Title = ".NET Dinner – February",
                Date = new DateTime(2025, 2, 28, 17, 30, 0),
                Location = "Claim 52 Kitchen, Eugene",
                Description = "Hosted by Mark Davis, an informal community dinner to share updates about upcoming EugDotNet meetups, introduce the team, and discuss CodeChops — a mentoring program for learning Blazor and Oqtane."
            },
            new Event
            {
                Title = ".NET Dinner – January",
                Date = new DateTime(2025, 1, 8, 17, 30, 0),
                Location = "Claim 52 Kitchen, Eugene",
                Description = "An evening of conversation and connection for .NET developers in Eugene. Hosted by Mark Davis, this casual dinner welcomed newcomers and veterans alike to network, share insights, and discuss the local dev scene."
            }
        });

        db.SaveChanges();
    }
}



app.Run();
