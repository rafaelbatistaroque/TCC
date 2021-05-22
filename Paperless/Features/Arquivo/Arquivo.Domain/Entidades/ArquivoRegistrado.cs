using Arquivo.Domain.ValueObjects;
using System;

namespace Arquivo.Domain.Entidades
{
    public class ArquivoRegistrado
    {
        public int Id { get; }
        public int ColaboradorId { get; }
        public string DataCadastro { get; }
        public string AnoReferencia { get; }
        public string MesReferencia { get; }
        public Anexo Anexo { get; }
        public string? Observacoes { get; }

        private ArquivoRegistrado(int colaboradorId, Anexo anexo, string anoReferencia, string mesReferencia, string observacoes, string dataCadastro)
            : this(anexo, anoReferencia, mesReferencia, observacoes, dataCadastro)
        {
            ColaboradorId = colaboradorId;
        }

        private ArquivoRegistrado(Anexo anexo, string anoReferencia, string mesReferencia, string observacoes, string dataCadastro, int id = 0)
        {
            Id = id;
            AnoReferencia = anoReferencia;
            MesReferencia = mesReferencia;
            Observacoes = observacoes;
            DataCadastro = dataCadastro;
            Anexo = anexo;
        }

        public static ArquivoRegistrado Criar(int colaboradorId, string anoReferencia, string mesReferencia, int tipoArquivo, string observacoes, string extensao)
        {
            return new ArquivoRegistrado(colaboradorId, Anexo.Criar(tipoArquivo, extensao), anoReferencia, mesReferencia, observacoes, DateTime.Now.Date.ToString("dd/MM/yyy"));
        }

        public static ArquivoRegistrado Retornar(int id, string anoReferencia, string mesReferencia, int tipoArquivo, string codigoAnexo, string extensao, string observacoes, string dataCadastro)
        {
            return new ArquivoRegistrado(Anexo.Retornar(tipoArquivo, codigoAnexo, extensao), anoReferencia, mesReferencia, observacoes, dataCadastro, id);
        }
    }
}