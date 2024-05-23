using AutoMapper;
using ExamProgram.Business.DTOs.TeacherDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;

    public TeacherService(
            ITeacherRepository teacherRepository,
            IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(TeacherCreateDto dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);
        teacher.CreatedDate = DateTime.UtcNow;

        await _teacherRepository.CreateAsync(teacher);
        await _teacherRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _teacherRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _teacherRepository.Delete(data);
        await _teacherRepository.CommitAsync();
    }

    public async Task<IEnumerable<TeacherGetDto>> GetAllAsync()
    {
        var datas = await _teacherRepository.GetAll().ToListAsync();

        return _mapper.Map<IEnumerable<TeacherGetDto>>(datas);
    }

    public async Task<TeacherGetDto> GetByIdAsync(int id)
    {
        var data = await _teacherRepository.GetSingleAsync(x=> x.Id == id,"Lessons");

        return _mapper.Map<TeacherGetDto>(data);
    }

    public async Task UpdateAsync(int id, TeacherUpdateDto dto)
    {
        var data = await _teacherRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _teacherRepository.CommitAsync();
    }
}
