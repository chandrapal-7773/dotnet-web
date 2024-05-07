using Amax.InsurancePro.Web.Models;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public interface ICompanyService
	{
		Task<CompanyViewModel> Get(int id);
		Task<CompaniesViewModel> GetAll(DatatableRequest request);
		Task<ResultViewModel> Add(CompanyViewModel request);
		Task<ResultViewModel> Edit(int id, CompanyViewModel request);
		Task<ResultViewModel> Delete(int id);
	}
}
