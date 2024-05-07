using Amax.InsurancePro.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amax.InsurancePro.Web.Controllers.Company
{
	public class CompanyController : BaseController
	{
		public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
		{

		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpGet("{id}")]
		public IActionResult Edit(int id)
		{
			return View();
		}

		public IActionResult List()
		{
			return View();
		}
	}
}
