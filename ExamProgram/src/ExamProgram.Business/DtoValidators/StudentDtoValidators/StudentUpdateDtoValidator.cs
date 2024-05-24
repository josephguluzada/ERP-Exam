using ExamProgram.Business.DTOs.StudentDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.StudentDtoValidators;

public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateDtoValidator()
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


        RuleFor(x => x.Number)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .GreaterThan(0).WithMessage("Nomre 0'dan böyük olmalıdır");

        RuleFor(x => x.ClassId)
            .NotNull().WithMessage("Null ola bilmez")
            .GreaterThan(0).WithMessage("Id 0dan boyuk olmalidir!");
    }
}
