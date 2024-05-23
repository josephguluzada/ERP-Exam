﻿using AutoMapper;
using ExamProgram.Business.DTOs.ClassDtos;
using ExamProgram.Business.DTOs.StudentDtos;
using ExamProgram.Business.DTOs.TeacherDtos;
using ExamProgram.Core.Entities;

namespace ExamProgram.Business.MappingProfiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<TeacherCreateDto, Teacher>().ReverseMap();
        CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();
        CreateMap<TeacherGetDto, Teacher>().ReverseMap();

        CreateMap<ClassCreateDto, Class>().ReverseMap();
        CreateMap<ClassUpdateDto, Class>().ReverseMap();
        CreateMap<ClassGetDto, Class>().ReverseMap();

        CreateMap<StudentCreateDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();
        CreateMap<StudentGetDto, Student>().ReverseMap();
    }
}
