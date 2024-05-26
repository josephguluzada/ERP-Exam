using ExamProgram.Api.ResponseMessages;
using ExamProgram.Business.DTOs.TokenDtos;
using ExamProgram.Business.DTOs.UserDtos;
using ExamProgram.Business.ExamProgramApiExceptions.UserExceptions;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgram.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(
            IAuthService authService, 
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager)
    {
        _authService = authService;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost("")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        TokenResponseDto? responseDto = null;
        try
        {
            responseDto = await _authService.Login(userLoginDto);
        }
        catch(InvalidCredsException ex)
        {
            return BadRequest(new ApiResponseMessage { Errors = ApiResponseMessage.CreateResponseMessage(ex) });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(responseDto);
    }

    [HttpGet("")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return Ok();
    }

    //[HttpGet("[action]")]
    //public async Task<IActionResult> CreateAdmin()
    //{
    //    AppUser admin = new AppUser()
    //    {
    //        Fullname = "Yusif Guluzada",
    //        UserName = "SuperAdmin",
    //    };

    //    var result = await _userManager.CreateAsync(admin, "Admin123@");


    //    return Ok(result);
    //}

    //[HttpGet("[action]")]
    //public async Task<IActionResult> CreateRole()
    //{
    //    var role1 = new IdentityRole("Admin");
    //    var role2 = new IdentityRole("SuperAdmin");

    //    await _roleManager.CreateAsync(role1);
    //    await _roleManager.CreateAsync(role2);

    //    return Ok();
    //}

    //[HttpGet("[action]")]
    //public async Task<IActionResult> AddRoleAdmin()
    //{
    //    AppUser admin = await _userManager.FindByNameAsync("SuperAdmin");

    //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

    //    return Ok("Add Olundu");
    //}
}
