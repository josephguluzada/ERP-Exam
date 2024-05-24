using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(ClassCreateDto dto)
        {
            await _classService.CreateAsync(dto);

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _classService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _classService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _classService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClassUpdateDto dto)
        {
            await _classService.UpdateAsync(id, dto);

            return Ok();
        }



    }
}
