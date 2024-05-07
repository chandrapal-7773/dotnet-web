
namespace Amax.InsurancePro.Infrastructure.Dtos;
public class AgenciesDto: BaseTableResponsDto
{
	public List<AgencyDto> Data { get; set; } = new List<AgencyDto>();
}
