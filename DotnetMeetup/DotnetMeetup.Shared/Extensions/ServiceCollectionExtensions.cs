
using DotnetMeetup.Shared.Services.ToastService;

using Microsoft.Extensions.DependencyInjection;

namespace DotnetMeetup.Shared.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<IToastService, ToastService>();
        return services;
    }

}
