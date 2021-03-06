using Arquivo.Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System;
using System.IO;

namespace Arquivo.Infra.Diretorio
{
    public class DiretorioServico : IDiretorioServico
    {
        private readonly IConfiguration _config;

        public DiretorioServico(IConfiguration config)
        {
            _config = config;
        }

        public Either<ErroBase, bool> SalvarAnexoEmDiretorio(IFormFile anexo, int colaboradorId, string arquivoCodigo)
        {
            try
            {
                var diretorioRaiz = _config.GetSection("diretorio_armazenamento_anexo").Value;
                var diretorio = Path.Combine(diretorioRaiz, $"{colaboradorId}");

                if(Directory.Exists(diretorio) == false)
                    Directory.CreateDirectory(diretorio);

                var anexoExtensao = Padronizacoes.ExtrairExtensaoAnexo(anexo);
                var caminhoComArquivo = Path.Combine(diretorio, $"{arquivoCodigo}.{anexoExtensao}");
                
                using var stream = new FileStream(caminhoComArquivo, FileMode.Create);
                anexo.CopyTo(stream);

                return true;
            }
            catch(Exception e)
            {
                return new ErroNenhumArquivoArmazenado(e.Message);
            }
        }

        public Either<ErroBase, byte[]> ObterArquivoEmDiretorio(int colaboradorId, string arquivoCodigo, string extensao)
        {
            var diretorioRaiz = _config.GetSection("diretorio_armazenamento_anexo").Value;
            var diretorio = Path.Combine(diretorioRaiz, $"{colaboradorId}");

            var arquivo = Path.Combine(diretorio, $"{arquivoCodigo}.{extensao}");
            if(File.Exists(arquivo) == false)
                return new ErroNenhumArquivoArmazenado(ArquivoTextosInformativos.NENHUM_ARQUIVO_ARMAZENADO);

            return File.ReadAllBytes(arquivo);
        }

        public void DeletarArquivoEmDiretorio(int colaboradorId, string arquivoCodigo, string extensao)
        {
            var diretorioRaiz = _config.GetSection("diretorio_armazenamento_anexo").Value;
            var diretorio = Path.Combine(diretorioRaiz, $"{colaboradorId}");

            var arquivo = Path.Combine(diretorio, $"{arquivoCodigo}.{extensao}");
            if(File.Exists(arquivo) == false)
                return;

            File.Delete(arquivo);

            return;
        }
    }
}