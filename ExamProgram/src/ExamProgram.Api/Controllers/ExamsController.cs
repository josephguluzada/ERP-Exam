using ExamProgram.Business.DTOs.ExamDtos;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.Services.Implementations;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(ExamCreateDto dto)
        {
            await _examService.CreateAsync(dto);

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _examService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ExamGetDto exam;

            try
            {
                exam = await _examService.GetByIdAsync(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(exam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _examService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExamUpdateDto dto)
        {
            await _examService.UpdateAsync(id, dto);

            return Ok();
        }

    }
}
