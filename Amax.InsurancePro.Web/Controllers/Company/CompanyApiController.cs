using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amax.InsurancePro.Web.Controllers.Company
{
	[Route("api/company/[action]")]
	public class CompanyApiController : BaseApiController
	{
		public readonly ICompanyService _companyService;
		public readonly ILogger<CompanyController> _logger;

		public CompanyApiController(ICompanyService companyService, ILogger<CompanyController> logger)
		{
			_companyService = companyService;
			_logger = logger;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await _companyService.Get(id));
		}

		[Authorize("AdminOnly")]
		[HttpPost]
		public async Task<IActionResult> List(DatatableRequest model)
		{
			return Ok(await _companyService.GetAll(model));
		}

		[Authorize("AdminOnly")]
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CompanyViewModel model)
		{
			return Ok(await _companyService.Add(model));
		}

		[Authorize("AdminOnly")]
		[HttpPost("{id}")]
		public async Task<IActionResult> Edit(int id, [FromBody] CompanyViewModel model)
		{
			return Ok(await _companyService.Edit(id, model));
		}

		[Authorize("AdminOnly")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _companyService.Delete(id));
		}
	}
}
