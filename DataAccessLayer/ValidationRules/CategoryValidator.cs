using EntityLayer.Concrete;
using FluentValidation;

namespace DataAccessLayer.ValidationRules;

public class CategoryValidator : AbstractValidator<Tag>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.Name).MaximumLength(40).WithMessage("Cannot be longer than 40 characters");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Cannot be shorther than 2 characters");
    }
}
