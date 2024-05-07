using Amax.InsurancePro.Infrastructure.Dtos;

namespace Amax.InsurancePro.Infrastructure.Dtos.Request;
public class UserRequestDto : BaseRequestDto
{
    public UserDto? user { get; set; }
    public LoginInfoDto? UserInfo { get; set; }
}