using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.ClassViewModels;
using ExamProgram.UI.ViewModels.LessonViewModels;
using ExamProgram.UI.ViewModels.TeacherViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.UI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ICrudService _crudService;

        public LessonController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            IEnumerable<LessonViewModel> datas = null;

            try
            {
                datas = await _crudService.GetAllAsync<IEnumerable<LessonViewModel>>("/lessons/getall");
            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(datas);
        }

        public async Task<IActionResult> Create()
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            var teachers = await _crudService.GetAllAsync<List<TeacherViewModel>>("/teachers/getall");
            ViewBag.Classes = await _crudService.GetAllAsync<List<CLassViewModel>>("/class/getall");
            ViewBag.Teachers = teachers.Select(t => new { t.Id, t.Fullname });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            var teachers = await _crudService.GetAllAsync<List<TeacherViewModel>>("/teachers/getall");
            ViewBag.Classes = await _crudService.GetAllAsync<List<CLassViewModel>>("/class/getall");
            ViewBag.Teachers = teachers.Select(t => new { t.Id, t.Fullname });
            try
            {
                await _crudService.CreateAsync("lessons/create", model);
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
            var teachers = await _crudService.GetAllAsync<List<TeacherViewModel>>("/teachers/getall");
            ViewBag.Classes = await _crudService.GetAllAsync<List<CLassViewModel>>("/class/getall");
            ViewBag.Teachers = teachers.Select(t => new { t.Id, t.Fullname });
            LessonCreateViewModel data = null;
            try
            {
                data = await _crudService.GetByIdAsync<LessonCreateViewModel>($"/lessons/get/{id}", id);
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            if (data is null) return View("Error");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, LessonCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            var teachers = await _crudService.GetAllAsync<List<TeacherViewModel>>("/teachers/getall");
            ViewBag.Classes = await _crudService.GetAllAsync<List<CLassViewModel>>("/class/getall");
            ViewBag.Teachers = teachers.Select(t => new { t.Id, t.Fullname });
            try
            {
                await _crudService.UpdateAsync($"/lessons/update/{id}", model);
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
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
                await _crudService.DeleteAsync($"/lessons/delete/{id}", id);
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
