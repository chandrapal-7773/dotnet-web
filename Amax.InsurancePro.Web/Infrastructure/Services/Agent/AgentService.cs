using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.RestServices;
using Amax.InsurancePro.Web.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Refit;
using System.Runtime.InteropServices;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public class AgentService : BaseService, IAgentService
	{
		private readonly IAgentApi _agentApi;
		private readonly IMapper _mapper;

		public AgentService(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor): base(appSettings, httpContextAccessor) 
		{
			_agentApi = RestService.For<IAgentApi>(HttpClient);
			_mapper = mapper;
		}

		public async Task<ResultViewModel> Add(AgentViewModel request)
		{
			var agentDto = _mapper.Map<AgentDto>(request);

			var resultDto = await _agentApi.Add(agentDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<ResultViewModel> Edit(int id, AgentViewModel request)
		{
			var agentDto = _mapper.Map<AgentDto>(request);

			var resultDto = await _agentApi.Edit(id, agentDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}
		public async Task<ResultViewModel> Delete(int id)
		{

			var resultDto = await _agentApi.Delete(id);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<AgentViewModel> Get(int id)
		{

			var agentDto = await _agentApi.Get(id);

			return _mapper.Map<AgentViewModel>(agentDto);

		}

		public async Task<AgentsViewModel> GetAll(DatatableRequest request)
		{
			var tableParams = _mapper.Map<TableParameterDto>(request);

			var agents = await _agentApi.GetAll(tableParams);

			return _mapper.Map<AgentsViewModel>(agents);
		}
	}
}
