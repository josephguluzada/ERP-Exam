using AutoMapper;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IMapper _mapper;

    public LessonService(
            ILessonRepository lessonRepository,
            IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }
    public async Task CreateAsync(LessonCreateDto dto)
    {
        var data = _mapper.Map<Lesson>(dto);
        data.CreatedDate = DateTime.UtcNow;

        await _lessonRepository.CreateAsync(data);
        await _lessonRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _lessonRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _lessonRepository.Delete(data);
        await _lessonRepository.CommitAsync();
    }

    public async Task<IEnumerable<LessonGetDto>> GetAllAsync()
    {
        var datas = await _lessonRepository.GetAll("Class","Teacher").ToListAsync();

        return _mapper.Map<IEnumerable<LessonGetDto>>(datas);
    }

    public async Task<LessonGetDto> GetByIdAsync(int id)
    {
        var data = await _lessonRepository.GetSingleAsync(x => x.Id == id, "Class", "Teacher");
        if (data is null) throw new NullReferenceException();

        return _mapper.Map<LessonGetDto>(data);
    }

    public async Task UpdateAsync(int id, LessonUpdateDto dto)
    {
        var data = await _lessonRepository.GetSingleAsync(x => x.Id == id, "Class", "Teacher");
        if (data is null) throw new NullReferenceException();

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _lessonRepository.CommitAsync();
    }
}
