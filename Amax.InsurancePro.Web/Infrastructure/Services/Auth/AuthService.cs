using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.RestServices;
using Amax.InsurancePro.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Refit;
using System.Security.Claims;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public class AuthService : BaseService, IAuthService
	{
		private readonly IAuthApi _authApi;
		private readonly IMapper _mapper;
		public AuthService(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor): base(appSettings, httpContextAccessor) 
		{
			_authApi = RestService.For<IAuthApi>(HttpClient);
			_mapper = mapper;
		}

		public async Task<bool> Login(AuthenticateRequestViewModel authViewModel)
		{

			var authReqDto = _mapper.Map<AuthenticateRequestDto>(authViewModel);

			var authResponseDto = await _authApi.Login(authReqDto);

			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, authResponseDto.LoginInfoDto.UserName),
				new Claim(ClaimTypes.Role, authResponseDto.LoginInfoDto.IsAdmin ? "admin" : "agent"),
				new Claim("Token", authResponseDto.Token),
			};
			var claimsIdentity = new ClaimsIdentity(claims, "Login");

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

			return true;
			

		}

        public async Task<bool> Logout()
        {
            await HttpContext.SignOutAsync();

			return true;
        }

        public async Task<bool> ResetPassword(AuthenticateRequestViewModel authViewModel)
		{
			var authReqDto = _mapper.Map<AuthenticateRequestDto>(authViewModel);

			var authRequestDto = await _authApi.ResetPassword(authReqDto);

			await HttpContext.SignOutAsync();

			return true;

		}


	}
}
