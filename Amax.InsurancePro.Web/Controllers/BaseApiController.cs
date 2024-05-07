using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amax.InsurancePro.Web.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class BaseApiController : Controller
	{
		
	}
}
