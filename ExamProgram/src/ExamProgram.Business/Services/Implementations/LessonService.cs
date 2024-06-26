﻿using AutoMapper;
using ExamProgram.Business.DTOs.LessonDtos;
using ExamProgram.Business.ExamProgramApiExceptions.CommonExceptions;
using ExamProgram.Business.ExamProgramApiExceptions.LessonExceptions;
using ExamProgram.Business.Services.Interfaces;
using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Business.Services.Implementations;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public LessonService(
            ILessonRepository lessonRepository,
            ITeacherRepository teacherRepository,
            IClassRepository classRepository,
            IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _teacherRepository = teacherRepository;
        _classRepository = classRepository;
        _mapper = mapper;
    }
    public async Task CreateAsync(LessonCreateDto dto)
    {
        if (!await _classRepository.Table.AnyAsync(x => x.Id == dto.ClassId))
            throw new NotFoundException("ClassId", "Belə bir sinif mövcud deyil");
        if (!await _teacherRepository.Table.AnyAsync(x => x.Id == dto.TeacherId))
            throw new NotFoundException("TeacherId", "Belə bir müəllim mövcud deyil");
        if (await _lessonRepository.Table.AnyAsync(x => x.Code.ToLower() == dto.Code.Trim().ToLower()))
            throw new LessonCodeAlreadyExistException("Code", "Bu kodlu sinif haz-hazırda mövcuddur");
        var data = _mapper.Map<Lesson>(dto);
        data.CreatedDate = DateTime.UtcNow;

        await _lessonRepository.CreateAsync(data);
        await _lessonRepository.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _lessonRepository.GetSingleAsync(x => x.Id == id);

        if (data is null) throw new LessonNotFoundException("", "Dərs tapılmadı");

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
        if (data is null) throw new LessonNotFoundException("","Dərs tapılmadı");

        return _mapper.Map<LessonGetDto>(data);
    }

    public async Task UpdateAsync(int id, LessonUpdateDto dto)
    {
        if (!await _classRepository.Table.AnyAsync(x => x.Id == dto.ClassId))
            throw new NotFoundException("ClassId", "Belə bir sinif mövcud deyil");
        if (!await _teacherRepository.Table.AnyAsync(x => x.Id == dto.TeacherId))
            throw new NotFoundException("TeacherId", "Belə bir müəllim mövcud deyil");
        if (await _lessonRepository.Table.AnyAsync(x => x.Code.ToLower() == dto.Code.Trim().ToLower() && x.Id != id))
            throw new LessonCodeAlreadyExistException("Code", "Bu kodlu sinif haz-hazırda mövcuddur");
        var data = await _lessonRepository.GetSingleAsync(x => x.Id == id, "Class", "Teacher");
        if (data is null) throw new LessonNotFoundException("","Dərs tapılmadı");

        _mapper.Map(dto, data);
        data.UpdatedDate = DateTime.UtcNow;

        await _lessonRepository.CommitAsync();
    }
}
