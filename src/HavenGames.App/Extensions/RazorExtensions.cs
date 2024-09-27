using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore.Storage;


namespace HavenGames.app.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {
            return tipoPessoa == 1? FormataCPF(documento) :FormataCNPJ(documento);
        }
        public static string FormataCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static string PessoaFisicaOuJuridica(this RazorPage page, int tipoPessoa)
        {
            return tipoPessoa == 1 ? "Pessoa Física" : "Pessoa Jurídica";
        }

        public static string SimOuNao(this RazorPage page, bool isTrue)
        {
            return isTrue ? "Sim" : "Não";
        }
    }
}
