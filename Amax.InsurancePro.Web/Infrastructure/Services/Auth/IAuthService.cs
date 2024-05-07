using Amax.InsurancePro.Web.Models;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public interface IAuthService
	{
		Task<bool> Login(AuthenticateRequestViewModel authViewModel);
		Task<bool> Logout();
		Task<bool> ResetPassword(AuthenticateRequestViewModel authViewModel);
	}
}
