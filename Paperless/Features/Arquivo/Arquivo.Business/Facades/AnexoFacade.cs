using Arquivo.Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.IO;

namespace Arquivo.Business.Facades
{
    public class AnexoFacade : IAnexoFacade
    {
        private readonly IConfiguration _config;

        public AnexoFacade(IConfiguration config)
        {
            _config = config;
        }

        public Either<ErroBase, bool> SalvarAnexoEmDiretorio(IFormFile anexo, string arquivoCodigo)
        {
            try
            {
                var diretorio = _config.GetSection("diretorio_armazenamento_anexo").Value;
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
    }
}
