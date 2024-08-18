using IDMT.Application.Abstractions.Clock;
using IDMT.Application.Abstractions.Email;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Positions;
using IDMT.Domain.SupportGroups;
using IDMT.Infrastructure.Clock;
using IDMT.Infrastructure.Email;
using IDMT.Infrastructure.Identity;
using IDMT.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IDMT.Infrastructure
{
	public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddTransient<IDateTimeProvider, DateTimeProvider>();
			AddPersistence(services, configuration);
			AddEmail(services, configuration);
			services.AddHttpContextAccessor();
			return services;
		}

		private static void AddEmail(IServiceCollection services, ConfigurationManager configuration)
		{
			var emailSettings = new EmailConfiguration();
			configuration.Bind(EmailConfiguration.SettingName, emailSettings);
			services.AddSingleton(Options.Create(emailSettings));
			services.AddSingleton<IEmailService, EmailService>();
		}

		private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DefaultConnection") ??
									  throw new ArgumentNullException(nameof(configuration));

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

			services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

			services.AddScoped<IPositionRepository, PositionRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IHrJobRepository, HrJobRepository>();
			services.AddScoped<ISupportGroupRepository, SupportGroupRepository>();

			services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());


		}
	}
}
