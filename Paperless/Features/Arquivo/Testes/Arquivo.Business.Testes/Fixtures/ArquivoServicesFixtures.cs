using Arquivo.Business.Models;
using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.Entidades;
using Arquivo.Fixtures;
using Microsoft.AspNetCore.Http;
using Moq.AutoMock;
using Paperless.Shared.Erros;
using System.Collections.Generic;

namespace Arquivo.Business.Testes.Fixtures
{
    public class ArquivoServicesFixtures : ArquivoFixtures
    {
        public AutoMocker Mocker { get; }

        public ArquivoServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public T CriarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        public CriarArquivoCommand GerarCriarArquivoCommandInvalido(int ColaboradorId, string refMes, string refAno, int tipoArquivo, IFormFile anexo, string observacoes)
           => new CriarArquivoCommand() { ColaboradorId = ColaboradorId, ReferenciaMes = refMes, ReferenciaAno = refAno, TipoArquivo = tipoArquivo, Anexo = anexo, Observacoes = observacoes };

        public CriarArquivoCommand GerarCriarArquivoCommandValido()
            => new CriarArquivoCommand() { ColaboradorId = COLABORADOR_ID_VALIDO, ReferenciaMes = REFERENCIA_MES_VALIDA, ReferenciaAno = REFERENCIA_ANO_VALIDA, TipoArquivo = TIPO_ARQUIVO_VALIDO, Anexo = ANEXO_VALIDO, Observacoes = OBSERVACAO_VALIDA };

        public ArquivoModel GerarArquivoModel() => ArquivoModel();

        public ArquivoRegistrado GerarArquivoRegistrado()
            => ArquivoRegistrado.Criar(COLABORADOR_ID_VALIDO,REFERENCIA_ANO_VALIDA,REFERENCIA_MES_VALIDA,TIPO_ARQUIVO_VALIDO,OBSERVACAO_VALIDA, EXTENSAO_VALIDA);

        public int GerarColaboradorIdInvalido() => COLABORADOR_ID_INVALIDO;

        public int GerarColaboradorIdValido() => COLABORADOR_ID_VALIDO;

        public List<ArquivoModel> GeraListaArquivoModel() => new List<ArquivoModel>() { ArquivoModel() };

        public List<ArquivoRegistrado> GeraListaArquivoRegistrado() => new List<ArquivoRegistrado>() { GerarArquivoRegistrado() };

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
