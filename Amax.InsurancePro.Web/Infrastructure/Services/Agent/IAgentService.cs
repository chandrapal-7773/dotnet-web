using Amax.InsurancePro.Web.Models;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public interface IAgentService
	{
		Task<AgentViewModel> Get(int id);
		Task<AgentsViewModel> GetAll(DatatableRequest request);
		Task<ResultViewModel> Add(AgentViewModel request);
		Task<ResultViewModel> Edit(int id, AgentViewModel request);
		Task<ResultViewModel> Delete(int id);
	}
}
