using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Colaborador.Domain.CasosDeUso.CriarColaborador
{
    public class CriarColaboradorCommand : ColaboradorCommandValidacoes, ICommandBase
    {
        public string ColaboradorPrimeiroNome { get; set; }
        public string ColaboradorSobrenome { get; set; }
        public string ColaboradorCPF { get; set; }
        public int ColaboradorFuncaoEmpresa { get; set; }

        public void Validar()
        {
            ValidarColaboradorPrimeiroNome(ColaboradorPrimeiroNome);
            ValidarColaboradorSobrenome(ColaboradorSobrenome);
            ValidarColaboradorCPF(ColaboradorCPF);
            ValidarColaboradorFuncaoEmpresa(ColaboradorFuncaoEmpresa);
        }
    }
}
