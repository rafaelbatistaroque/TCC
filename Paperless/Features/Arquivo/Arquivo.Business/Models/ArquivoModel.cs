using Arquivo.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arquivo.Business.Models
{
    [Table("Arquivo")]
    public class ArquivoModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public Anexo Anexo{ get; set; }
        public DateTime DataCadastro { get; set; }
        public string AnoReferencia { get; set; }
        public string MesReferencia { get; set; }
        public string Observacoes { get; set; }
    }
}
