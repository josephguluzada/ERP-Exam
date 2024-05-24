using ExamProgram.Business.DTOs.ExamDtos;
using FluentValidation;

namespace ExamProgram.Business.DtoValidators.ExamDtoValidators;

public class ExamCreateDtoValidator : AbstractValidator<ExamCreateDto>
{
    public ExamCreateDtoValidator()
    {
        RuleFor(x => x.StudentNumber)
        .NotNull().WithMessage("Null ola bilmez")
        .NotEmpty().WithMessage("Bos ola bilmez")
        .GreaterThan(0).WithMessage("Nomre 0'dan böyük olmalıdır");

        RuleFor(x => x.LessonCode)
            .NotNull().WithMessage("Null ola bilmez")
            .NotEmpty().WithMessage("Bos ola bilmez")
            .MaximumLength(3).WithMessage("Code'un uzunluğu max 3 ola bilər")
            .MinimumLength(3).WithMessage("Code'un uzunluğu min 3 ola bilər");

        RuleFor(x => x.Grade)
            .NotNull().WithMessage("Null ola bilmez");

        RuleFor(x => x).Custom((x, context) =>
        {
            if(x.Grade < 0 || x.Grade > 5)
            {
                context.AddFailure(nameof(x.Grade), "Qiymet 0 ile 5 araliginda olmalidir");
            }
        });


    }
}
