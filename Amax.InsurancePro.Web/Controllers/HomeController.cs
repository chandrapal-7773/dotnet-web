using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Amax.InsurancePro.Web.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHttpContextAccessor _contextAccessor;

		public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
		{
			_logger = logger;
			_contextAccessor=contextAccessor;
		}

		[Route("/")]
		[Route("/[controller]")]
		[Route("/[controller]/[action]")]
		public IActionResult Index()
		{
			return View();
		}

        [Route("/Forbidden")]
        [Route("/[controller]/[action]")]
        public IActionResult Forbidden()
        {
            return View();
        }

    }
}