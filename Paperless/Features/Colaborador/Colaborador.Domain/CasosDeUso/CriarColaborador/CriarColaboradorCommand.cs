using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Colaborador.Domain.CasosDeUso.CriarColaborador
{
    public class CriarColaboradorCommand : ColaboradorCommandQueryValidacoes, ICommandQueryBase
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string numeroCPF { get; set; }
        public int FuncaoId { get; set; }

        public void Validar()
        {
            ValidarPrimeiroNome(PrimeiroNome);
            ValidarSobrenome(Sobrenome);
            ValidarNumeroCPF(numeroCPF);
            ValidarFuncaoId(FuncaoId);
        }
    }
}
