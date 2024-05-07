
namespace Amax.InsurancePro.Infrastructure.Dtos;

public class AgentsDto: BaseTableResponsDto
{
	public List<AgentDto> Data { get; set; } = new List<AgentDto>();
}
