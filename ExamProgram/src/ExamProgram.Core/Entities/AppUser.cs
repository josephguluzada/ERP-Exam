using Microsoft.AspNetCore.Identity;

namespace ExamProgram.Core.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; }
}
