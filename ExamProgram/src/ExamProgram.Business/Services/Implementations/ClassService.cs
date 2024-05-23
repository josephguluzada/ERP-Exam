using AutoMapper;
using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.TeacherDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public ClassService(
            IClassRepository classRepository,
            IMapper mapper)
    {
        _classRepository = classRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ClassCreateDto dto)
    {
        var data = _mapper.Map<Class>(dto);
        data.CreatedDate = DateTime.UtcNow;

        await _classRepository.CreateAsync(data);
        await _classRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _classRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _classRepository.Delete(data);
        await _classRepository.CommitAsync();
    }

    public async Task<IEnumerable<ClassGetDto>> GetAllAsync()
    {
        var datas = await _classRepository.GetAll().ToListAsync();

        return _mapper.Map<IEnumerable<ClassGetDto>>(datas);
    }

    public async Task<ClassGetDto> GetByIdAsync(int id)
    {
        var data = await _classRepository.GetSingleAsync(x => x.Id == id);

        return _mapper.Map<ClassGetDto>(data);
    }

    public async Task UpdateAsync(int id, ClassUpdateDto dto)
    {
        var data = await _classRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _classRepository.CommitAsync();
    }
}
