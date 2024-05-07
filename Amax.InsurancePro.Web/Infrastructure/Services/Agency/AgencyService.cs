using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.RestServices;
using Amax.InsurancePro.Web.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Refit;
using System.Runtime.InteropServices;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public class AgencyService : BaseService, IAgencyService
	{
		private readonly IAgencyApi _agencyApi;
		private readonly IMapper _mapper;

		public AgencyService(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor): base(appSettings, httpContextAccessor) 
		{
			_agencyApi = RestService.For<IAgencyApi>(HttpClient);
			_mapper = mapper;
		}

		public async Task<AgenciesViewModel> GetAll(DatatableRequest request)
		{
			var tableParams = _mapper.Map<TableParameterDto>(request);

			var agencies = await _agencyApi.GetAll(tableParams);

			return _mapper.Map<AgenciesViewModel>(agencies);
		}

		public async Task<ResultViewModel> Add(AgencyViewModel request)
		{
			var agencyDto = _mapper.Map<AgencyDto>(request);

			var resultDto = await _agencyApi.Add(agencyDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<ResultViewModel> Delete(int id)
		{
			var resultDto = await _agencyApi.Delete(id);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<ResultViewModel> Edit(int id, AgencyViewModel request)
		{
			var agencyDto = _mapper.Map<AgencyDto>(request);

			var resultDto = await _agencyApi.Edit(id, agencyDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<AgencyViewModel> Get(int id)
		{
			var agencyDto = await _agencyApi.Get(id);

			return _mapper.Map<AgencyViewModel>(agencyDto);
		}
	}
}
