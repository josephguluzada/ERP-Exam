using ExamProgram.UI.Services;
using ExamProgram.UI.Services.Interfaces;
using ExamProgram.UI.ViewModels.TeacherViewModels;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

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
            var response = await _crudService.GetAllAsync<IEnumerable<TeacherViewModel>>("/teachers/getall");

            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateViewModel model)
        {
            await _crudService.CreateAsync("/teachers/create",model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await _crudService.GetByIdAsync<TeacherCreateViewModel>($"/teachers/get/{id}", id);
            if (data is null) return View("Error");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,TeacherCreateViewModel model)
        {
            await _crudService.UpdateAsync($"/teachers/update/{id}", model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _crudService.DeleteAsync($"/teachers/delete/{id}", id);

            return RedirectToAction(nameof(Index));
        }
    }
}
