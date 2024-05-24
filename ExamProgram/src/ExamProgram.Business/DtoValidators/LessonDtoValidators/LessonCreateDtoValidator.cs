using ExamProgram.Business.DTOs.LessonDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.LessonDtoValidators;

public class LessonCreateDtoValidator : AbstractValidator<LessonCreateDto>
{
    public LessonCreateDtoValidator()
    {
        RuleFor(x => x.Name)
        .NotNull().WithMessage("Null ola bilmez")
        .NotEmpty().WithMessage("Bos ola bilmez")
        .MaximumLength(30).WithMessage("Adın uzunluğu max 30 ola bilər")
        .MinimumLength(2).WithMessage("Adın uzunluğu min 2 ola bilər");

        RuleFor(x => x.Code)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .MaximumLength(3).WithMessage("Code'un uzunluğu max 3 ola bilər")
            .MinimumLength(3).WithMessage("Code'un uzunluğu min 3 ola bilər");

        RuleFor(x => x.TeacherId)
            .NotNull().WithMessage("Null ola bilmez")
            .GreaterThan(0).WithMessage("Id 0dan boyuk olmalidir!");

        RuleFor(x => x.ClassId)
            .NotNull().WithMessage("Null ola bilmez")
            .GreaterThan(0).WithMessage("Id 0dan boyuk olmalidir!");
    }
}
