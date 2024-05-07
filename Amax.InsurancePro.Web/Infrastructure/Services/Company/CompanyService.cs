using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.RestServices;
using Amax.InsurancePro.Web.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Refit;

namespace Amax.InsurancePro.Web.Infrastructure.Services
{
	public class CompanyService : BaseService, ICompanyService
	{
		private readonly ICompanyAPI _companyApi;
		private readonly IMapper _mapper;

		public CompanyService(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor) : base(appSettings, httpContextAccessor)
		{
			_companyApi = RestService.For<ICompanyAPI>(HttpClient);
			_mapper = mapper;
		}

		public async Task<ResultViewModel> Add(CompanyViewModel request)
		{
			var companyDto = _mapper.Map<CompanyDto>(request);

			var resultDto = await _companyApi.Add(companyDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<ResultViewModel> Delete(int id)
		{
			var resultDto = await _companyApi.Delete(id);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<ResultViewModel> Edit(int id, CompanyViewModel request)
		{
			var companyDto = _mapper.Map<CompanyDto>(request);

			var resultDto = await _companyApi.Edit(id, companyDto);

			return _mapper.Map<ResultViewModel>(resultDto);
		}

		public async Task<CompanyViewModel> Get(int id)
		{
			var companyDto = await _companyApi.Get(id);

			return _mapper.Map<CompanyViewModel>(companyDto);
		}

		public async Task<CompaniesViewModel> GetAll(DatatableRequest request)
		{
			var tableParams = _mapper.Map<TableParameterDto>(request);

			var companies = await _companyApi.GetAll(tableParams);

			return _mapper.Map<CompaniesViewModel>(companies);
		}
	}
}
