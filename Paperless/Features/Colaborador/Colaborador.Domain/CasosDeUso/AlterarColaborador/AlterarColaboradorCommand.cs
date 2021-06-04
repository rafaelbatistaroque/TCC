using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Colaborador.Domain.CasosDeUso.AlterarColaborador
{
    public class AlterarColaboradorCommand : ColaboradorCommandQueryValidacoes, ICommandQueryBase
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public int FuncaoId { get; set; }

        public void Validar()
        {
            ValidarId(Id);
            ValidarPrimeiroNome(PrimeiroNome);
            ValidarSobrenome(Sobrenome);
            ValidarFuncaoId(FuncaoId);
        }
    }
}
