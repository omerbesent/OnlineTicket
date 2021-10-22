using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EventValidator : AbstractValidator<EventDto>
    {
        public EventValidator()
        {
            RuleFor(e => e.Title).NotEmpty().WithMessage("Başlık zorunlu");
            RuleFor(e => e.EventDetails).NotEmpty().WithMessage("Etkinlik detayı zorunlu");
            RuleFor(e => e.CategoryId).NotEmpty().WithMessage("Kategori seçilmeli");
            RuleFor(e => e.CoverPhoto).NotEmpty().WithMessage("Etkinlik resmi seçilmeli");
            RuleFor(e => e.Date).NotEmpty().WithMessage("Etkinlik tarihi girilmeli");
            RuleFor(e => e.PlaceId).NotEmpty().WithMessage("Etkinlik mekanı seçilmeli");
            RuleFor(e => e.Price).NotEmpty().WithMessage("Etkinlik fiyatı");
            RuleFor(e => e.Sessions).NotEmpty().WithMessage("Etkinlik oturumları girilmeli");
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
