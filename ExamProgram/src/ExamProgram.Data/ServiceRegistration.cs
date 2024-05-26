using ExamProgram.Core.Repositories;
using ExamProgram.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExamProgram.Data;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();



    }
}
