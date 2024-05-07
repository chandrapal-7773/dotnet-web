using Amax.InsurancePro.Infrastructure.Dtos;
using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Amax.InsurancePro.Web.Controllers.Agent
{
    [Route("api/agent/[action]")]
    public class AgentApiController : BaseApiController
    {
        public readonly IAgentService _agentService;
        public readonly ILogger<AgentController> _logger;

        public AgentApiController(IAgentService agentService, ILogger<AgentController> logger)
        {
            _agentService = agentService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _agentService.Get(id));
        }

		[Authorize("AdminOnly")]
		[HttpPost]
        public async Task<IActionResult> List(DatatableRequest model)
        {

			return Ok(await _agentService.GetAll(model));
        }

		[Authorize("AdminOnly")]
		[HttpPost]
        public async Task<IActionResult> Add([FromBody] AgentViewModel model)
        {
            return Ok(await _agentService.Add(model));
        }

		[Authorize("AdminOnly")]
		[HttpPost("{id}")]
		public async Task<IActionResult> Edit(int id, [FromBody] AgentViewModel model)
		{
			return Ok(await _agentService.Edit(id, model));
		}

		[Authorize("AdminOnly")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _agentService.Delete(id));
		}
	}
}
