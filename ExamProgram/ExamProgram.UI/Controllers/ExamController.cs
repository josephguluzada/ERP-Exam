using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.ClassViewModels;
using ExamProgram.UI.ViewModels.ExamViewModels;
using ExamProgram.UI.ViewModels.LessonViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ICrudService _crudService;

        public ExamController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ExamViewModel> datas = null;

            try
            {
                datas = await _crudService.GetAllAsync<IEnumerable<ExamViewModel>>("/exams/getall");
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(datas);
        }

        public async Task<IActionResult> Create()
        {
            
            try
            {
                ViewBag.Lessons = await _crudService.GetAllAsync<List<LessonViewModel>>("/lessons/getall");
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamCreateViewModel model)
        {
            ViewBag.Lessons = await _crudService.GetAllAsync<List<LessonViewModel>>("/lessons/getall");
            try
            {
                await _crudService.CreateAsync("/exams/create", model);
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
            catch(HttpRequestException ex)
            {
                return RedirectToAction("Login", "Auth");
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
            ExamCreateViewModel data = null;
            try
            {
                ViewBag.Lessons = await _crudService.GetAllAsync<List<LessonViewModel>>("/lessons/getall");
                data = await _crudService.GetByIdAsync<ExamCreateViewModel>($"/exams/get/{id}", id);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ExamCreateViewModel model)
        {

            try
            {
                ViewBag.Lessons = await _crudService.GetAllAsync<List<LessonViewModel>>("/lessons/getall");
                await _crudService.UpdateAsync($"/exams/update/{id}", model);
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
                }else if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
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

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _crudService.DeleteAsync($"/exams/delete/{id}", id);
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
