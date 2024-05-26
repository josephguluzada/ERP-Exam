using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.TeacherViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ICrudService _crudService;
        public TeacherController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            var response = await _crudService.GetAllAsync<IEnumerable<TeacherViewModel>>("/teachers/getall");

            return View(response);
        }

        public IActionResult Create()
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            if (!ModelState.IsValid) return View();

            try
            {
                await _crudService.CreateAsync("/teachers/create", model);
            }
            catch (ApiException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    foreach (var key in e.ModelErrors.Keys)
                    {
                        ModelState.AddModelError(key, e.ModelErrors[key]);
                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            TeacherCreateViewModel data = null;
            try
            {
                data = await _crudService.GetByIdAsync<TeacherCreateViewModel>($"/teachers/get/{id}", id);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.StatusCode = ex.StatusCode;
                    ViewBag.ErrorMessage = ex.ModelErrors[""];
                    return View("Error");
                }
            }
            catch (HttpRequestException ex)
            {
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            if (data is null) return View("Error");

            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,TeacherCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            try
            {
                await _crudService.UpdateAsync($"/teachers/update/{id}", model);
            }
            catch(ApiException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    foreach (var key in ex.ModelErrors.Keys)
                    {
                        ModelState.AddModelError(key, ex.ModelErrors[key]);
                    }
                        return View(model);
                }else if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.StatusCode = ex.StatusCode;
                    ViewBag.ErrorMessage = ex.ModelErrors[""];
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            try
            {
                await _crudService.DeleteAsync($"/teachers/delete/{id}", id);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.StatusCode = ex.StatusCode;
                    ViewBag.ErrorMessage = ex.ModelErrors[""];

                    return View("Error");
                }
            }
            catch (HttpRequestException ex)
            {
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception ex)
            {

                return View("Error");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
