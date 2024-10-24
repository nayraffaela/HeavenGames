using FluentValidation;
using HavenGames.Business.Models;


namespace HavenGames.Business.Validation
{
    public class JogoValidation : AbstractValidator<Jogo>
    {
        public JogoValidation()
        {
                RuleFor(j => j.Nome)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

                RuleFor(j => j.Plataforma)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

                RuleFor(j => j.Genero)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

                RuleFor(j => j.Imagem)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}

