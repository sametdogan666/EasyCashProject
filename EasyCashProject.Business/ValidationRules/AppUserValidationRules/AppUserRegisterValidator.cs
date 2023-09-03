using EasyCashProject.DTO.Dtos.AppUserDtos;
using EasyCashProject.Entities.Concrete;
using FluentValidation;

namespace EasyCashProject.Business.ValidationRules.AppUserValidationRules;

public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        RuleFor(x=>x.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakterden oluşmalıdır");
        RuleFor(x=>x.FirstName).MaximumLength(50).WithMessage("Ad alanı fazla 50 karakterden oluşmalıdır.");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakterden oluşmalıdır");
        RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Soyad alanı fazla 50 karakterden oluşmalıdır.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");

        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
        RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı alanı en az 3 karakterden oluşmalıdır");
        RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı adı alanı fazla 50 karakterden oluşmalıdır.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
        RuleFor(x => x.ConfirmPassword).Equal(y=>y.Password).WithMessage("Şifreleriniz eşleşmiyor");
    }
}