using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiService _apiService;

        public AuthController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var authToken = await _apiService.Login(model);

                    Response.Cookies.Append("token", authToken.AccessToken, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddYears(1),
                        HttpOnly = true
                    });
                }
                catch (ApiException ex)
                {
                    if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        foreach (var key in ex.ModelErrors.Keys)
                        {
                            ModelState.AddModelError(key, ex.ModelErrors[key]);
                        }
                        return View(model);
                    }
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _apiService.Logout();
            }

            catch (Exception)
            {
                return RedirectToAction("login", "auth");
            }

            return RedirectToAction("Login", "Auth");
        }
    }
}
