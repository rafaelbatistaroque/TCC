using Colaborador.Domain.ValueObjects;

namespace Colaborador.Business.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        public ColaboradorNome Nome { get; set; }
        public CPF ColaboradorCPF { get; set; }
        public int FuncaoId { get; set; }
    }
}
