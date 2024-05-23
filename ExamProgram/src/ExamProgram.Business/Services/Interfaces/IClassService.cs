using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.TeacherDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface IClassService
{
    Task CreateAsync(ClassCreateDto dto);
    Task<ClassGetDto> GetByIdAsync(int id);
    Task<IEnumerable<ClassGetDto>> GetAllAsync();
    Task UpdateAsync(int id, ClassUpdateDto dto);
    Task DeleteAsync(int id);
}
