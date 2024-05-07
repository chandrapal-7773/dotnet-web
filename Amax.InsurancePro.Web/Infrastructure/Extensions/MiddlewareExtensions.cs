using Amax.InsurancePro.Web.Infrastructure.Middlewares;

namespace Amax.InsurancePro.Web.Infrastructure.Extensions
{
	public static class MiddlewareExtensions
	{

		public static void ConfigureCookiePolicy(this IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.Unspecified; //this is required for Culture cookie creation

			});
		}

		public static void ConfigureSession(this IServiceCollection services,  IConfiguration configuration)
		{
			var appSettings = configuration.GetSection("AppSettings");

			services.AddSession(options =>
			{
				//TODO set from appsettings
				options.Cookie.Name = "AmaxSession";
				options.IdleTimeout = TimeSpan.FromMinutes(5);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
		}

		public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
		}

	}
}
