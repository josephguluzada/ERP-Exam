using ExamProgram.UI.ExamProgramUIExceptions;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.ClassViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.UI.Controllers
{
    public class ClassController : Controller
    {
        private readonly ICrudService _crudService;

        public ClassController(ICrudService crudService)
        {
            _crudService = crudService;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            var datas = await _crudService.GetAllAsync<IEnumerable<CLassViewModel>>("/class/getall");

            return View(datas);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            try
            {
                await _crudService.CreateAsync("/class/create",model);
            }
            catch(ApiException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                {
                    foreach (var key in ex.ModelErrors.Keys)
                    {
                        ModelState.AddModelError(key, ex.ModelErrors[key]);
                    }
                    return View();
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
            ClassCreateViewModel data = null;

            try
            {
                data = await _crudService.GetByIdAsync<ClassCreateViewModel>($"/class/get/{id}", id);
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
        public async Task<IActionResult> Update(int id,ClassCreateViewModel model)
        {
            if (HttpContext.Request.Cookies["token"] is null)
            {
                return RedirectToAction("login", "auth");
            }
            try
            {
                await _crudService.UpdateAsync($"/class/update/{id}", model);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    foreach (var key in ex.ModelErrors.Keys)
                    {
                        ModelState.AddModelError(key, ex.ModelErrors[key]);
                    }
                    return View();
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
                await _crudService.DeleteAsync($"/class/delete/{id}", id);
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
