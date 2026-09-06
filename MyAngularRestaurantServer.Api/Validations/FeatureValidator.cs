using FluentValidation;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Validations
{
    public class FeatureValidator : AbstractValidator<FeatureDto>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel adresi boş bırakılamaz.");

            RuleFor(x => x.ButtonTitle)
                .NotEmpty().WithMessage("Buton başlığı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Buton başlığı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.ButtonUrl)
                .NotEmpty().WithMessage("Buton bağlantısı boş bırakılamaz.");
        }
    }
}