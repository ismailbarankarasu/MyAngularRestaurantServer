using FluentValidation;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Validations
{
    public class ServiceValidator : AbstractValidator<ServiceDto>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Hizmet başlığı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Hizmet başlığı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Hizmet başlığı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Hizmet açıklaması boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Hizmet açıklaması en az 10 karakter olmalıdır.")
                .MaximumLength(300).WithMessage("Hizmet açıklaması en fazla 300 karakter olmalıdır.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("İkon bilgisi boş bırakılamaz.");
        }
    }
}