using FluentValidation;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Validations
{
    public class ContactInfoValidator : AbstractValidator<ContactInfoDto>
    {
        public ContactInfoValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş bırakılamaz.")
                .MaximumLength(250).WithMessage("Adres en fazla 250 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Telefon numarası en fazla 30 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Çalışma saatleri boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Çalışma saatleri en fazla 100 karakter olabilir.");
        }
    }
}