using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.CategoryName).MaximumLength(40).WithMessage("Cannot be longer than 40 characters");
        RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Cannot be shorther than 2 characters");
    }
}
