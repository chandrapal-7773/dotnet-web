using Amax.InsurancePro.Web.Infrastructure.Services;
using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Amax.InsurancePro.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }


        public IActionResult ResetPassword(string username)
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequestViewModel request)
        {

            var result = await _authService.Login(request);

            return Ok();
        }

        public async Task<IActionResult> Logout()
        {

            await _authService.Logout();

            return RedirectToAction("Index", "Home");
        }

    }
}