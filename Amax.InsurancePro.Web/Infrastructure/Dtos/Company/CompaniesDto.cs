namespace Amax.InsurancePro.Infrastructure.Dtos;

public class CompaniesDto : BaseTableResponsDto
{
	public List<CompanyDto> Data { get; set; } = new List<CompanyDto>();
}
