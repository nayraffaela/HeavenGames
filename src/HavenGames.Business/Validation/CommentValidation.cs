using FluentValidation;
using HavenGames.Business.Models;


namespace HavenGames.Business.Validation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
                RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 150)
            .WithMessage("O campo{PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

                RuleFor(e => e.Descricao)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 150)
            .WithMessage("O campo{PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


        }
    }
}
