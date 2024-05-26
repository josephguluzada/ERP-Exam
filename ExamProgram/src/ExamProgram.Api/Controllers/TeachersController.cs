using ExamProgram.Api.ResponseMessages;
using ExamProgram.Business.DTOs.ExamDtos;
using ExamProgram.Business.DTOs.TeacherDtos;
using ExamProgram.Business.ExamProgramApiExceptions.ExamExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.TeacherExceptions;
using ExamProgram.Business.Services.Implementations;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(TeacherCreateDto dto)
        {
            try
            {
                await _teacherService.CreateAsync(dto);
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
            return Ok(await _teacherService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TeacherGetDto exam;

            try
            {
                exam = await _teacherService.GetByIdAsync(id);
            }
            catch (TeacherNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
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
                await _teacherService.DeleteAsync(id);
            }
            catch (TeacherNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeacherUpdateDto dto)
        {
            try
            {
                await _teacherService.UpdateAsync(id, dto);
            }
            catch (TeacherNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception)
            {

                throw;
            };

            return Ok();
        }
    }
}
