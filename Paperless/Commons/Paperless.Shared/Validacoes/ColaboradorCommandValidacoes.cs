using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public class ColaboradorCommandValidacoes : Notifiable
    {
        public void ValidarColaboradorNome(string colaboradorNome)
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
        public void ValidarColaboradorFuncaoEmpresa(string colaboradorFuncaoEmpresa)
        {
            AddNotifications(new Contract()
               .IsNotNullOrWhiteSpace(colaboradorFuncaoEmpresa, nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_NULO_VAZIO)
               .IsTrue(colaboradorFuncaoEmpresa != null && Regex.IsMatch(colaboradorFuncaoEmpresa, @"[a-zA-Z]"), nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_NUMEROS)
               );
        }
    }
}
