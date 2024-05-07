using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amax.InsurancePro.Web.Controllers.Agent
{
    public class AgentController : BaseController
    {

        public AgentController(IAgentService agentService, ILogger<AgentController> logger)
        {

        }


		[Authorize("AdminOnly")]
		public IActionResult List()
        {
            return View();
        }


    }
}
