using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Colaborador.Domain.CasosDeUso.AdicionarColaborador
{
    public class AdicionarColaboradorCommand : ColaboradorCommandValidacoes, ICommandBase
    {
        public string ColaboradorNome { get; set; }
        public string ColaboradorCPF { get; set; }
        public string ColaboradorFuncaoEmpresa { get; set; }

        public void Validar()
        {
            ValidarColaboradorNome(ColaboradorNome);
            ValidarColaboradorCPF(ColaboradorCPF);
            ValidarColaboradorFuncaoEmpresa(ColaboradorFuncaoEmpresa);
        }
    }
}
