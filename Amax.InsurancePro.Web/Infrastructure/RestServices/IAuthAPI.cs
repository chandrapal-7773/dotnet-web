using Amax.InsurancePro.Infrastructure.Dtos;
using Refit;

namespace Amax.InsurancePro.Web.Infrastructure.RestServices
{
	public interface IAuthApi
	{
		[Post("/auth/authenticate")]
		Task<AuthenticateResponseDto> Login(AuthenticateRequestDto model);

		[Post("/auth/resetpassword")]
		Task<AuthenticateResponseDto> ResetPassword(AuthenticateRequestDto model);

	}
}
