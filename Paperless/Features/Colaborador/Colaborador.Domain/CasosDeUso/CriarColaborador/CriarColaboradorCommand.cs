using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Colaborador.Domain.CasosDeUso.CriarColaborador
{
    public class CriarColaboradorCommand : ColaboradorCommandQueryValidacoes, ICommandQueryBase
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public int FuncaoEmpresa { get; set; }

        public void Validar()
        {
            ValidarPrimeiroNome(PrimeiroNome);
            ValidarSobrenome(Sobrenome);
            ValidarCPF(CPF);
            ValidarFuncaoEmpresa(FuncaoEmpresa);
        }
    }
}
