using FluentValidation;
using HavenGames.Business.Models;


namespace HavenGames.Business.Validation
{
    public class CategoriaValidation : AbstractValidator<Personagem>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo{PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Imagem)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Descricao)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 50)
               .WithMessage("O campo{PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Jogo)
             .NotNull()
             .WithMessage("O campo {PropertyName} precisa ser fornecido");
             

        }
    }
}
