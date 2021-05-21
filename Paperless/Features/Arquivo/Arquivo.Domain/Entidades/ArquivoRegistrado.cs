using Arquivo.Domain.ValueObjects;
using System;

namespace Arquivo.Domain.Entidades
{
    public class ArquivoRegistrado
    {
        public int Id { get; }
        public int ColaboradorId { get; }
        public string Extensao { get; }
        public DateTime DataCadastro { get; }
        public string AnoReferencia { get; }
        public string MesReferencia { get; }
        public Anexo Anexo { get; }
        public string? Observacoes { get; }
        public string LinkParaDownload { get; }

        private ArquivoRegistrado(int colaboradorId, Anexo anexo, string anoReferencia, string mesReferencia, string observacoes)
        {
            ColaboradorId = colaboradorId;
            DataCadastro = DateTime.Now;
            AnoReferencia = anoReferencia;
            MesReferencia = mesReferencia;
            Anexo = anexo;
            Observacoes = observacoes;
        }

        private ArquivoRegistrado(int colaboradorId, Anexo anexo, string anoReferencia, string mesReferencia, string observacoes, int id = 0)
            : this(colaboradorId, anexo, anoReferencia, mesReferencia, observacoes)
        {
            Id = id;
        }

        public static ArquivoRegistrado Criar(int colaboradorId, string anoReferencia, string mesReferencia, int tipoArquivo, string observacoes, string extensao)
        {
            return new ArquivoRegistrado(colaboradorId, Anexo.Criar(tipoArquivo, extensao), anoReferencia, mesReferencia, observacoes);
        }

        public static ArquivoRegistrado Retornar(int id, int colaboradorId, string anoReferencia, string mesReferencia, int tipoArquivo, string codigoAnexo, string extensao, string observacoes)
        {
            return new ArquivoRegistrado(colaboradorId, Anexo.Retornar(tipoArquivo, codigoAnexo, extensao), anoReferencia, mesReferencia, observacoes, id);
        }
    }
}