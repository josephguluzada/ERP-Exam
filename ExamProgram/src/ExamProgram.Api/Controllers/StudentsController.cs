using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.StudentDtos;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            await _studentService.CreateAsync(dto);

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            await _studentService.UpdateAsync(id, dto);

            return Ok();
        }
    }
}
