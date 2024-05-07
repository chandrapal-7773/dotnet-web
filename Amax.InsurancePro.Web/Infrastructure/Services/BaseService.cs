using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public class BaseService
	{

		private readonly IUserProfileService userProfileService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public BaseService(IOptionsSnapshot<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
		{
			AppSettings = appSettings.Value;
			_httpContextAccessor = httpContextAccessor;
		}

		public AppSettings AppSettings { get; }

		public HttpContext HttpContext { get { return _httpContextAccessor.HttpContext; } }

		public HttpClient HttpClient
		{

			get

			{

				var accessToken = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Token")?.Value;

				var client = new HttpClient() { BaseAddress = new Uri(AppSettings.APIRootUri) };

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

				return client;
			}
		}

	}
}
