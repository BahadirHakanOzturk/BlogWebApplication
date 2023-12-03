using Blog.Application.ViewModels;
using FluentValidation;

namespace Blog.Application.ValidationRules;

public class CategoryAddVMValidator : AbstractValidator<CategoryAddVM>
{
    public CategoryAddVMValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz.");
		RuleFor(c => c.Name).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır.");
		RuleFor(c => c.Name).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.");
	}
}
