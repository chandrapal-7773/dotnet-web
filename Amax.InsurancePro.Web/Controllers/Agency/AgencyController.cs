using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amax.InsurancePro.Web.Controllers.Agency
{
    public class AgencyController : BaseController
    {

        public AgencyController(ILogger<AgencyController> logger)
        {

        }

		public IActionResult List()
        {
            return View();
        }


    }
}
