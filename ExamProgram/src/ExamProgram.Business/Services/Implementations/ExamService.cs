using AutoMapper;
using ExamProgram.Business.DTOs.ExamDtos;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class ExamService : IExamService
{
    private readonly IExamRepository _examRepository;
    private readonly ILessonRepository _lessonRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public ExamService(
            IExamRepository examRepository,
            ILessonRepository lessonRepository,
            IStudentRepository studentRepository,
            IMapper mapper)
    {
        _examRepository = examRepository;
        _lessonRepository = lessonRepository;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task CreateAsync(ExamCreateDto dto)
    {
        if (!_lessonRepository.Table.Any(x => x.Code.ToLower() == dto.LessonCode.Trim().ToLower()))
            throw new NullReferenceException("Lesson Code not exist!");
        if (!_studentRepository.Table.Any(x => x.Number == dto.StudentNumber))
            throw new NullReferenceException("Student number not exist!");
        var lesson = await _lessonRepository.GetSingleAsync(x=>x.Code.ToLower() == dto.LessonCode.Trim().ToLower());
        var student = await _studentRepository.GetSingleAsync(x => x.Number == dto.StudentNumber);
        var data = _mapper.Map<Exam>(dto);
        data.LessonId = lesson.Id;
        data.StudentId = student.Id;
        data.CreatedDate = DateTime.UtcNow;

        await _examRepository.CreateAsync(data);
        await _examRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _examRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new NullReferenceException();

        _examRepository.Delete(data);
        await _examRepository.CommitAsync();
    }

    public async Task<IEnumerable<ExamGetDto>> GetAllAsync()
    {
        var datas = await _examRepository.GetAll("Lesson", "Student").ToListAsync();

        return _mapper.Map<IEnumerable<ExamGetDto>>(datas);
    }

    public async Task<ExamGetDto> GetByIdAsync(int id)
    {
        var data = await _examRepository.GetSingleAsync(x => x.Id == id, "Lesson", "Student");
        if (data is null) throw new NullReferenceException();

        return _mapper.Map<ExamGetDto>(data);
    }

    public async Task UpdateAsync(int id, ExamUpdateDto dto)
    {
        if (!_lessonRepository.Table.Any(x => x.Code.ToLower() == dto.LessonCode.Trim().ToLower()))
            throw new NullReferenceException("Lesson Code not exist!");
        if (!_studentRepository.Table.Any(x => x.Number == dto.StudentNumber))
            throw new NullReferenceException("Student number not exist!");
        var lesson = await _lessonRepository.GetSingleAsync(x => x.Code.ToLower() == dto.LessonCode.Trim().ToLower());
        var student = await _studentRepository.GetSingleAsync(x => x.Number == dto.StudentNumber);
        var data = await _examRepository.GetSingleAsync(x => x.Id == id, "Lesson", "Student");
        if (data is null) throw new NullReferenceException();

        _mapper.Map(dto, data);
        data.LessonId = lesson.Id;
        data.StudentId = student.Id;
        data.UpdatedDate = DateTime.UtcNow;

        await _examRepository.CommitAsync();
    }
}
