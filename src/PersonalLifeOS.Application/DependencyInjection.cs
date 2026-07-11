using Microsoft.Extensions.DependencyInjection;
using PersonalLifeOS.Application.Finance.Mappings;

namespace PersonalLifeOS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(configuration =>
            configuration.AddProfile<MappingProfile>());

        return services;
    }
}
