using Amax.InsurancePro.Infrastructure.Dtos;

namespace Amax.InsurancePro.Infrastructure.Dtos;

public class AuthenticateResponseDto 
{
	public string? Token { get; set; }
	public LoginInfoDto? LoginInfoDto { get; set; }
    
}