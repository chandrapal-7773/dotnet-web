using Amax.InsurancePro.Infrastructure.Dtos;
using Refit;

namespace Amax.InsurancePro.Web.Infrastructure.RestServices
{
	public interface ICompanyAPI
	{
		[Post("/company/GetAll")]
		Task<CompaniesDto> GetAll(TableParameterDto model);

		[Get("/company/get?id={id}")]
		Task<CompanyDto> Get(int id);

		[Post("/company/add")]
		Task<ResultDto> Add(CompanyDto company);

		[Put("/company/update/{id}")]
		Task<ResultDto> Edit(int id, CompanyDto company);

		[Delete("/company/delete/{id}")]
		Task<ResultDto> Delete(int id);
	}
}
