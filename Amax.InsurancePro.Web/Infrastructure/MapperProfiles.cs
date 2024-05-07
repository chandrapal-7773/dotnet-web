using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Models;
using AutoMapper;
namespace Amax.InsurancePro.Web.Infrastructure
{
	public class MapperProfiles : Profile
	{
		public MapperProfiles()
		{

			CreateMap<ResultDto, ResultViewModel>();

			CreateMap<AuthenticateRequestViewModel, AuthenticateRequestDto>().ReverseMap();
			CreateMap<AuthenticateResponseViewModel, AuthenticateResponseDto>().ReverseMap();

			CreateMap<BaseTableResponsDto, BaseTableViewModel>().ReverseMap();
			CreateMap<TableParameterDto, DatatableRequest>()
				.ForMember(dest => dest.length, opt => opt.MapFrom(src => src.Length))
				.ForMember(dest => dest.start, opt => opt.MapFrom(src => src.Start)).ReverseMap();

			AgentMappers();
			AgencyMappers();
			CompanyMappers();

		}

		private void AgentMappers()
		{
			CreateMap<AgentLocationsDto, AgentLocationsViewModel>().ReverseMap();
			CreateMap<AgentDto, AgentViewModel>().ReverseMap();
			CreateMap<AgentsDto, AgentsViewModel>().ReverseMap();
		}
		private void AgencyMappers()
		{
			CreateMap<AgencyDto, AgencyViewModel>().ReverseMap();
			CreateMap<AgenciesDto, AgenciesViewModel>().ReverseMap();
		}
		private void CompanyMappers()
		{
			CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
			CreateMap<CompaniesDto, CompaniesViewModel>().ReverseMap();
		}
	}
}
