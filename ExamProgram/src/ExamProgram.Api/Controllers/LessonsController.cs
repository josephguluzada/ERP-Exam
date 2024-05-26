using ExamProgram.Api.ResponseMessages;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.ExamProgramApiExceptions.CommonExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.LessonExceptions;
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
            try
            {
                await _lessonService.CreateAsync(dto);
            }
            catch (LessonCodeAlreadyExistException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
            catch (LessonNotFoundException ex)
            {
                return NotFound(ex.Message);
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
            try
            {
                await _lessonService.UpdateAsync(id, dto);

            }
            catch (LessonCodeAlreadyExistException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (LessonNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
