using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amax.InsurancePro.Web.Controllers.Agency
{
    [Route("api/agency/[action]")]
    public class AgencyApiController : BaseApiController
    {
        public readonly IAgencyService _agencyService;
        public readonly ILogger<AgencyController> _logger;

        public AgencyApiController(IAgencyService agencyService, ILogger<AgencyController> logger)
        {
            _agencyService = agencyService;
            _logger = logger;
        }

		[Authorize("AdminOnly")]
		[HttpPost]
        public async Task<IActionResult> List(DatatableRequest model)
        {
            return Ok(await _agencyService.GetAll(model));
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await _agencyService.Get(id));
		}


		[Authorize("AdminOnly")]
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AgencyViewModel model)
		{
			return Ok(await _agencyService.Add(model));
		}

		[Authorize("AdminOnly")]
		[HttpPost("{id}")]
		public async Task<IActionResult> Edit(int id, [FromBody] AgencyViewModel model)
		{
			return Ok(await _agencyService.Edit(id, model));
		}

		[Authorize("AdminOnly")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _agencyService.Delete(id));
		}

	}
}
