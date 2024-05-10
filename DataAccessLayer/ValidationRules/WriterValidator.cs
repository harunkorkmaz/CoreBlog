using EntityLayer.Dto;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class WriterValidator : AbstractValidator<RegisterDto>
{
    public WriterValidator()
    {
        RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail cannot be empty");
        RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Please enter at least two characters");
        RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Please enter maximum of 50 characters");
        RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Password should contain at least one uppercase letter");
        RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Password should contain at least one lowercase letter");
        RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Password should contain at least one digit");
        RuleFor(x => x.WriterPasswordAgain).Equal(x => x.WriterPassword).WithMessage("Passwords do not match");
    }
}
