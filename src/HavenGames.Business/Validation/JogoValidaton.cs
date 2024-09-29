using FluentValidation;
using HavenGames.Business.Models;


namespace HavenGames.Business.Validation
{
    public class JogoValidation : AbstractValidator<Jogo>
    {
        public JogoValidation()
        {
            RuleFor(p => p.Nome)
        .NotEmpty()
        .WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(2, 100)
        .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

            RuleFor(p => p.Plataforma)
        .NotEmpty()
        .WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(2, 100)
        .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

            RuleFor(p => p.Genero)
        .NotEmpty()
        .WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(2, 100)
        .WithMessage("O campo{PropertyName} precisa ter entre {MaxLength} caracteres");

            RuleFor(e => e.Imagem)
        .NotEmpty()
        .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Descricao)
        .NotEmpty()
        .WithMessage("O campo {PropertyName} precisa ser fornecido")
        .Length(2, 200)
        .WithMessage("O campo{PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


        }
    }
}

