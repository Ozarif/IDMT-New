using FluentValidation;
using IDMT.Application.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace IDMT.Application
{
	public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly);
				configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

			});

			services.AddValidatorsFromAssembly(typeof(ApplicationServicesRegistration).Assembly, includeInternalTypes: true);

			return services;
        }
    }
}
