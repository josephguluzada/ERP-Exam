using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(LessonCreateDto dto)
        {
            await _lessonService.CreateAsync(dto);

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lessonService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _lessonService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _lessonService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LessonUpdateDto dto)
        {
            await _lessonService.UpdateAsync(id, dto);

            return Ok();
        }
    }
}
