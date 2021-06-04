using Arquivo.Business.Models;
using Arquivo.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Paperless.Shared.Erros;
using System.IO;
using System.Text;

namespace Arquivo.Fixtures
{
    public class ArquivoFixtures
    {
        protected const string REFERENCIA_MES_VALIDA = "05";
        protected const string REFERENCIA_ANO_VALIDA = "2021";
        protected const int TIPO_ARQUIVO_VALIDO = 1;
        protected const int ARQUIVO_ID_VALIDO = 1;
        protected const string ARQUIVO_CODIGO_VALIDO = "F48FAE74AD";
        protected const int COLABORADOR_ID_VALIDO = 1;
        protected const int COLABORADOR_ID_INVALIDO = -1;
        protected IFormFile ANEXO_VALIDO = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("CONTEUDO_ANEXO_FAKE")), 0, 1, "Data", "ANEXO_FAKE.txt");
        protected const string OBSERVACAO_VALIDA = "OBS";
        protected const string EXTENSAO_VALIDA = "PDF";
        protected const string DIRETORIO_FAKE = @"C:\";

        protected ArquivoModel ArquivoModel() => new ArquivoModel() { Anexo = Anexo.Retornar(TIPO_ARQUIVO_VALIDO, ARQUIVO_CODIGO_VALIDO, ARQUIVO_ID_VALIDO, EXTENSAO_VALIDA) };

        protected ErroBase ErroGenerico() => new ErroGenericoTestes();
    }
}
