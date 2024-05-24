using ExamProgram.Business.DTOs.TeacherDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.TeacherDtoValidators;

public class TeacherUpdateDtoValidator : AbstractValidator<TeacherUpdateDto>
{
    public TeacherUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
       .NotNull().WithMessage("Null ola bilmez")
       .NotEmpty().WithMessage("Bos ola bilmez")
       .MaximumLength(30).WithMessage("Adın uzunluğu max 30 ola bilər")
       .MinimumLength(2).WithMessage("Adın uzunluğu min 2 ola bilər");

        RuleFor(x => x.Surname)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .MaximumLength(30).WithMessage("Soyadın uzunluğu max 30 ola bilər")
            .MinimumLength(3).WithMessage("Soyadın uzunluğu min 3 ola bilər");
    }
}
