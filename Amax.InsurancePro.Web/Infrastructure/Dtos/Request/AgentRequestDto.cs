using Amax.InsurancePro.Infrastructure.Dtos;
namespace Amax.InsurancePro.Infrastructure.Dtos.Request;
public class AgentRequestDto : BaseRequestDto
{
    public AgentDto Agent { get; set; }
}