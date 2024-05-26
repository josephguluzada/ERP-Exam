using ExamProgram.Api.ResponseMessages;
using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.TeacherDtos;
using ExamProgram.Business.ExamProgramApiExceptions.ClassExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.TeacherExceptions;
using ExamProgram.Business.Services.Implementations;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("")]
        public async Task<IActionResult> Create(ClassCreateDto dto)
        {
            try
            {
                await _classService.CreateAsync(dto);
            }
            catch(SameClassNoException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _classService.GetAllAsync());
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ClassGetDto data;

            try
            {
                data = await _classService.GetByIdAsync(id);
            }
            catch (ClassNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(data);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _classService.DeleteAsync(id);
            }
            catch(ClassNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClassUpdateDto dto)
        {
            try
            {
                await _classService.UpdateAsync(id, dto);
            }
            catch(SameClassNoException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (ClassNotFoundException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

            return Ok();
        }



    }
}
