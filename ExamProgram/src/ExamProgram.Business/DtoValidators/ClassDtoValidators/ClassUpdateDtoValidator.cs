using ExamProgram.Business.DTOs.ClassDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.ClassDtoValidators;

internal class ClassUpdateDtoValidator : AbstractValidator<ClassUpdateDto>
{
    public ClassUpdateDtoValidator()
    {
        RuleFor(x => x.Number)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .GreaterThan(0).WithMessage("Nomre 0'dan böyük olmalıdır");
    }
}
