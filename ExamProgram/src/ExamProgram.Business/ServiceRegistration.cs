using ExamProgram.Business.MappingProfiles;
using ExamProgram.Business.Services.Implementations;
using ExamProgram.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExamProgram.Business;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IClassService, ClassService>();



        services.AddAutoMapper(typeof(MapProfile));
    }
}
