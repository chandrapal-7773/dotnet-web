using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amax.InsurancePro.Web.Controllers
{
	[Authorize]
	[Route("[controller]/[action]")]
	public class BaseController : Controller
	{
		
	}
}
