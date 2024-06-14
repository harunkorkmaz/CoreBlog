using EntityLayer.Concrete;
using FluentValidation;

namespace DataAccessLayer.ValidationRules;

public class BlogValidator : AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.Title).MaximumLength(150).WithMessage("Cannot be longer than 150 characters");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Cannot be shorther than 5 characters");
    }
}
