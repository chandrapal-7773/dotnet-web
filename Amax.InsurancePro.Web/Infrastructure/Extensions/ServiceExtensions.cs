using Amax.InsurancePro.Web.Infrastructure.Services;

namespace Amax.InsurancePro.Web.Infrastructure.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IAgentService, AgentService>();
			services.AddScoped<IAgencyService, AgencyService>();
			services.AddScoped<ICompanyService, CompanyService>();
		}
	}
}
