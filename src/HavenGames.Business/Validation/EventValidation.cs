using FluentValidation;
using HavenGames.Business.Models;



namespace HavenGames.Business.Validation
{
    public class EventValidation : AbstractValidator<Event>
    {
        public EventValidation()
        {
            RuleFor(f => f.Name)
                 .NotEmpty()
                 .WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(2, 100)
                 .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Imagem)
                 .NotEmpty()
                 .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Description)
                 .NotEmpty()
                 .WithMessage("O campo {PropertyName} precisa ser fornecido");
                

            RuleFor(f => f.Localization)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Date)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

        }

    }
}

