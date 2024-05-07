using Amax.InsurancePro.Infrastructure.Dtos;
using Refit;

namespace Amax.InsurancePro.Web.Infrastructure.RestServices
{
	public interface IAgentApi
	{
		[Post("/agent/GetAll")]
		Task<AgentsDto> GetAll(TableParameterDto model);

		[Get("/agent/get?id={id}")]
		Task<AgentDto> Get(int id);

		[Post("/agent/add")]
		Task<ResultDto> Add(AgentDto newAgent);

		[Put("/agent/update/{id}")]
		Task<ResultDto> Edit(int id, AgentDto newAgent);

		[Delete("/agent/delete/{id}")]
		Task<ResultDto> Delete(int id);
	}
}
