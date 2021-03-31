using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public class ColaboradorCommandValidacoes : Notifiable
    {
        public void ValidarColaboradorPrimeiroNome(string colaboradorNome)
        {
            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(colaboradorNome, nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_NULO_VAZIO)
                .IsTrue(colaboradorNome != null && Regex.IsMatch(colaboradorNome, @"[a-zA-Z]"), nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_NUMEROS)
                );
        }

        public void ValidarColaboradorSobrenome(string colaboradorNome)
        {
            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(colaboradorNome, nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_NULO_VAZIO)
                .IsTrue(colaboradorNome != null && Regex.IsMatch(colaboradorNome, @"[a-zA-Z]"), nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_NUMEROS)
                );
        }

        public void ValidarColaboradorCPF(string colaboradorCPF)
        {
            AddNotifications(new Contract()
               .IsNotNullOrWhiteSpace(colaboradorCPF, nameof(colaboradorCPF), ColaboradorTextosInformativos.COLABORADOR_CPF_NULO_VAZIO)
               .IsTrue(colaboradorCPF != null && Regex.IsMatch(colaboradorCPF, @"^((\d{3}[.\s-]?){3}\d{2}|11)$"), nameof(colaboradorCPF), ColaboradorTextosInformativos.COLABORADOR_CPF_FORMATO_INVALIDO)
               );
        }

        public void ValidarColaboradorFuncaoEmpresa(int colaboradorFuncaoEmpresa)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(colaboradorFuncaoEmpresa, 0, nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_INVALIDA)
                .HasMinLengthIfNotNullOrEmpty(colaboradorFuncaoEmpresa.ToString(), 1, nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_INVALIDA)
                );
        }
    }
}
