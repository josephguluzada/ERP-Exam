using ExamProgram.Business.DTOs.ClassDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.ClassDtoValidators;

public class ClassCreateDtoValidator : AbstractValidator<ClassCreateDto>
{
    public ClassCreateDtoValidator()
    {
        RuleFor(x => x.Number)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .GreaterThan(0).WithMessage("Nomre 0'dan böyük olmalıdır");
    }
}
