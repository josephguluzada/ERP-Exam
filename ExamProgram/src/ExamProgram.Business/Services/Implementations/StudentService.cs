using AutoMapper;
using ExamProgram.Business.DTOs.StudentDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(
            IStudentRepository studentRepository,
            IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(StudentCreateDto dto)
    {
        var data = _mapper.Map<Student>(dto);
        data.CreatedDate = DateTime.UtcNow;

        await _studentRepository.CreateAsync(data);
        await _studentRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _studentRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _studentRepository.Delete(data);
        await _studentRepository.CommitAsync();
    }

    public async Task<IEnumerable<StudentGetDto>> GetAllAsync()
    {
        var datas = await _studentRepository.GetAll("Class").ToListAsync();

        return _mapper.Map<IEnumerable<StudentGetDto>>(datas);
    }

    public async Task<StudentGetDto> GetByIdAsync(int id)
    {
        var data = await _studentRepository.GetSingleAsync(x => x.Id == id, "Class");
        if(data is null) throw new NullReferenceException();

        return _mapper.Map<StudentGetDto>(data);
    }

    public async Task UpdateAsync(int id, StudentUpdateDto dto)
    {
        var data = await _studentRepository.GetSingleAsync(x => x.Id == id, "Class");
        if (data is null) throw new NullReferenceException();

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _studentRepository.CommitAsync();
    }
}
