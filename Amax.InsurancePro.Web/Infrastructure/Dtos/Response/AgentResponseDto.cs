using Amax.InsurancePro.Infrastructure.Dtos;

namespace Amax.InsurancePro.Infrastructure.Dtos.Response;

public class AgentResponseDto : BaseResponseDto
{
    public AgentDto Agent { get; set; }
    public List<AgentDto> AgentList { get; set; }
}