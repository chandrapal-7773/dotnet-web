using Amax.InsurancePro.Web.Models;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public interface IAgencyService
	{
		Task<AgenciesViewModel> GetAll(DatatableRequest request);
		Task<AgencyViewModel> Get(int id);
		Task<ResultViewModel> Add(AgencyViewModel request);
		Task<ResultViewModel> Edit(int id, AgencyViewModel request);
		Task<ResultViewModel> Delete(int id);
	}
}
