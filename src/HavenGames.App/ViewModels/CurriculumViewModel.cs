using HavenGames.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class CurriculumViewModel
    {
        [Required]
        [Display(Name = "Nome deve ser informado")]
        public string Nome { get; set; }
        [Required]
        public string NomeSocial { get; set; }
        [Required]
        [Display(Name = "Data de nascimento deve ser informada")]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }
        [Required]
        [Display(Name = "CPF deve ser informado")]
        public string CPF { get; set; }
        [Required]
        [Display(Name = "E-mail deve ser informado")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefone deve ser informado")]
        public int Telefone { get; set; }
        [Required]
        [Display(Name = "Escolaridade deve ser preenchida")]
        public Escolaridade Escolaridade { get; set; }
        [Required]
        [Display(Name = "Escolha uma opção)")]
        public Status Status { get; set; }
        [Required]
        [Display(Name = "Vaga deve ser escolhida)")]
        public Vaga Vaga { get; set; }

        [Required]
        [Display(Name = "Currículo (PDF ou Word)")]
        public IFormFile CurriculoArquivo { get; set; }
    }
}
