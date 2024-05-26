using AutoMapper;
using ExamProgram.Business.DTOs.StudentDtos;
using ExamProgram.Business.ExamProgramApiExceptions.CommonExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.StudentExceptions;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public StudentService(
            IStudentRepository studentRepository,
            IClassRepository classRepository,
            IMapper mapper)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(StudentCreateDto dto)
    {
        if (await _studentRepository.Table.AnyAsync(x => x.Number == dto.Number))
            throw new SameNumberException("Number","Nömrə hal-hazırda mövcuddur");
        if (!await _classRepository.Table.AnyAsync(x => x.Id == dto.ClassId))
            throw new NotFoundException("ClassId", "Belə bir sinif mövcud deyil");

        var data = _mapper.Map<Student>(dto);
        data.CreatedDate = DateTime.UtcNow;

        await _studentRepository.CreateAsync(data);
        await _studentRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _studentRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new StudentNotFoundException("","Tələbə tapılmadı");

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
        if(data is null) throw new StudentNotFoundException("","Tələbə tapılmadı");

        return _mapper.Map<StudentGetDto>(data);
    }

    public async Task UpdateAsync(int id, StudentUpdateDto dto)
    {
        if (await _studentRepository.Table.AnyAsync(x => x.Number == dto.Number))
            throw new SameNumberException("Number", "Nömrə hal-hazırda mövcuddur");
        if (!await _classRepository.Table.AnyAsync(x => x.Id == dto.ClassId))
            throw new NotFoundException("ClassId", "Belə bir sinif mövcud deyil");
        var data = await _studentRepository.GetSingleAsync(x => x.Id == id, "Class");
        if (data is null) throw new StudentNotFoundException("", "Tələbə tapılmadı");

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _studentRepository.CommitAsync();
    }
}
