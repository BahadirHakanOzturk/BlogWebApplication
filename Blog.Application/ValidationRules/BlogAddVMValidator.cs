using Blog.Application.ViewModels;
using FluentValidation;

namespace Blog.Application.ValidationRules;

public class BlogAddVMValidator : AbstractValidator<BlogAddVM>
{
    public BlogAddVMValidator()
    {
		RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz");
		RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz").MinimumLength(120).WithMessage("Minimum 120 karakterlik bir yazı girmelisiniz");
		RuleFor(x => x.Image).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
		RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
		RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen 4 karakterden daha fazla veri girişi yapın");
	}
}
