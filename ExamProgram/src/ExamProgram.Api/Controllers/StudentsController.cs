﻿using ExamProgram.Api.ResponseMessages;
using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.DTOs.StudentDtos;
using ExamProgram.Business.ExamProgramApiExceptions.CommonExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.LessonExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.StudentExceptions;
using ExamProgram.Business.Services.Implementations;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
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
            try
            {
                await _studentService.CreateAsync(dto);
            }
            catch(SameNumberException ex)
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
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            StudentGetDto data;

            try
            {
                data = await _studentService.GetByIdAsync(id);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
            }
            catch(StudentNotFoundException ex)
            {
                return NotFound(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
            }
            catch(NotFoundException ex)
            {
                return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
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
            try
            {
                await _studentService.UpdateAsync(id,dto);
            }
            catch (SameNumberException ex)
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
    }
}
