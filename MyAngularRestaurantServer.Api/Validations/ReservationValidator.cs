using FluentValidation;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Validations
{
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad soyad boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.ReservationDate)
                .NotEmpty().WithMessage("Rezervasyon tarihi boş bırakılamaz.")
                .GreaterThan(DateTime.Now)
                .WithMessage("Rezervasyon tarihi geçmiş bir tarih olamaz.");

            RuleFor(x => x.PersonCount)
                .GreaterThan(0).WithMessage("Kişi sayısı en az 1 olmalıdır.")
                .LessThanOrEqualTo(20).WithMessage("Tek rezervasyonda en fazla 20 kişi seçilebilir.");

            RuleFor(x => x.SpecialRequest)
                .MaximumLength(500)
                .WithMessage("Özel istek en fazla 500 karakter olabilir.");
        }
    }
}