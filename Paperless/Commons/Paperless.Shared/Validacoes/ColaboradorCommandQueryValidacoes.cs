using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;

namespace Paperless.Shared.Validacoes
{
    public abstract class ColaboradorCommandQueryValidacoes : Notifiable
    {
        protected void ValidarId(int id)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(id, 0, nameof(id), ColaboradorTextosInformativos.ID_INVALIDO)
                );
        }

        protected void ValidarPrimeiroNome(string colaboradorNome)
        {
            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(colaboradorNome, nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_NULO_VAZIO)
                .Matchs(colaboradorNome, @"[a-zA-Z]", nameof(colaboradorNome), ColaboradorTextosInformativos.COLABORADOR_NOME_INVALIDO)
                );
        }

        protected void ValidarSobrenome(string sobrenome)
        {
            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(sobrenome, nameof(sobrenome), ColaboradorTextosInformativos.COLABORADOR_SOBRENOME_NULO_VAZIO)
                .Matchs(sobrenome, @"[a-zA-Z]", nameof(sobrenome), ColaboradorTextosInformativos.COLABORADOR_SOBRENOME_INVALIDO)
                );
        }

        protected void ValidarCPF(string colaboradorCPF)
        {
            AddNotifications(new Contract()
               .IsNotNullOrWhiteSpace(colaboradorCPF, nameof(colaboradorCPF), ColaboradorTextosInformativos.COLABORADOR_CPF_NULO_VAZIO)
               .Matchs(colaboradorCPF, @"^((\d{3}[.\s-]?){3}\d{2}|11)$", nameof(colaboradorCPF), ColaboradorTextosInformativos.COLABORADOR_CPF_FORMATO_INVALIDO)
               );
        }

        protected void ValidarFuncaoEmpresa(int colaboradorFuncaoEmpresa)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(colaboradorFuncaoEmpresa, 0, nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_INVALIDA)
                .HasMinLengthIfNotNullOrEmpty(colaboradorFuncaoEmpresa.ToString(), 1, nameof(colaboradorFuncaoEmpresa), ColaboradorTextosInformativos.COLABORADOR_FUNCAO_INVALIDA)
                );
        }
    }
}
