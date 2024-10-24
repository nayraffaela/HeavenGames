using HavenGames.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace HavenGames.App.ViewModels
{
    public class CurriculumViewModel
    {
        [Required(ErrorMessage = "Nome deve ser informado")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome Social deve ser informado")]
        [Display(Name = "Nome Social")]
        public string NomeSocial { get; set; }

        [Required(ErrorMessage = "Data de nascimento deve ser informada")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "CPF deve ser informado")]
        [Display(Name = "CPF")]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "E-mail deve ser informado")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone deve ser informado")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Escolaridade deve ser preenchida")]
        [Display(Name = "Escolaridade")]
        public Escolaridade Escolaridade { get; set; }

        [Required(ErrorMessage = "Escolha uma opção")]
        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Vaga deve ser escolhida")]
        [Display(Name = "Vaga")]
        public Vaga Vaga { get; set; }

      
        
    }
}
