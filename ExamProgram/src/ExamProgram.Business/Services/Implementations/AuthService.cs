using ExamProgram.Business.DTOs.TokenDtos;
using ExamProgram.Business.DTOs.UserDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExamProgram.Business.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(
           UserManager<AppUser> userManager,
           RoleManager<IdentityRole> roleManager,
           SignInManager<AppUser> signInManager,
           IConfiguration configuration,
           IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<TokenResponseDto> Login(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByNameAsync(userLoginDto.userName);

        if (user is null)
        {
            throw new Exception("Invalid Credentials");
        }

        var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.password, false, false);
        if (!result.Succeeded)
        {
            throw new Exception("Invalid Credentials");
        }

        IList<string> userRoles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Fullname", user.Fullname),
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var securityKey = _configuration.GetSection("JWT:securityKey").Value;
        var tokenExpireDate = DateTime.UtcNow.AddHours(3);
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                audience: _configuration.GetSection("JWT:audience").Value,
                issuer: _configuration.GetSection("JWT:issuer").Value,
                expires: tokenExpireDate
                );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new TokenResponseDto(user.UserName, token, tokenExpireDate);
    }

    public async Task Logout()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync();
        _httpContextAccessor.HttpContext.Response.Headers.Remove("Authorization");
    }
}
