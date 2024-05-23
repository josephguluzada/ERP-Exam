using ExamProgram.Business.DTOs.ExamDtos;

namespace ExamProgram.Business.Services.Interfaces;

public interface IExamService
{
    Task CreateAsync(ExamCreateDto dto);
    Task<ExamGetDto> GetByIdAsync(int id);
    Task<IEnumerable<ExamGetDto>> GetAllAsync();
    Task UpdateAsync(int id, ExamUpdateDto dto);
    Task DeleteAsync(int id);
}
