using Amax.InsurancePro.Infrastructure.Dtos;

namespace Amax.InsurancePro.Infrastructure.Dtos.Response;

public class UserResponseDto : BaseResponseDto
{
    public LoginInfoDto UserLoginInfo { get; set; }
    public string DashboardUrl { get; set; }

}