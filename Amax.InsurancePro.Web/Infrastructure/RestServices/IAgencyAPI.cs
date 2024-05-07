using Amax.InsurancePro.Infrastructure.Dtos;
using Refit;

namespace Amax.InsurancePro.Web.Infrastructure.RestServices
{
	public interface IAgencyApi
	{
		[Post("/agency/GetAll")]
		Task<AgenciesDto> GetAll(TableParameterDto model);

		[Get("/agency/get?id={id}")]
		Task<AgencyDto> Get(int id);

		[Post("/agency/add")]
		Task<ResultDto> Add(AgencyDto agency);

		[Put("/agency/update/{id}")]
		Task<ResultDto> Edit(int id, AgencyDto agency);

		[Delete("/agency/delete/{id}")]
		Task<ResultDto> Delete(int id);
	}
}
