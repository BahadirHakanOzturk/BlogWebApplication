using Blog.Application.ViewModels;
using FluentValidation;

namespace Blog.Application.ValidationRules;

public class UserSignUpVMValidator : AbstractValidator<UserSignUpVM>
{
    public UserSignUpVMValidator()
    {
		RuleFor(x => x.NameSurname)
			.NotEmpty().WithMessage("Ad Soyad kısmı boş geçilemez");

		RuleFor(x => x.UserName)
			.NotEmpty().WithMessage("Kullanıcı adı kısmı boş geçilemez")
			.MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın")
			.MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");

		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Mail adresi boş geçilemez")
			.EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Mail Formatı uygun değil");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Şifre boş geçilemez");

		RuleFor(x => x.ConfirmPassword)
			.NotEmpty().WithMessage("Şifre boş geçilemez")
			.Equal(x => x.Password).WithMessage("Şifreler aynı olmalıdır");
	}    
}
