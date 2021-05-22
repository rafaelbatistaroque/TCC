using Arquivo.Business.Contracts;
using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Arquivo.Business.Services
{
    public class CriarArquivoHandler : ICriarArquivo
    {
        private readonly IArquivoRepository _repositorio;
        private readonly IAnexoFacade _anexoFacade;
        private readonly IArquivoAdapter _adapter;

        public CriarArquivoHandler(IArquivoRepository repositorio, IAnexoFacade anexoFacade, IArquivoAdapter adapter)
        {
            _repositorio = repositorio;
            _anexoFacade = anexoFacade;
            _adapter = adapter;
        }

        public Either<ErroBase, bool> Handler(CriarArquivoCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var respostaColaboradorExiste = _repositorio.ExisteColaborador(command.ColaboradorId);
            if(respostaColaboradorExiste is false)
                return new ErroRegistroNaoEncontrado(ArquivoTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var extensaoAnexo = Padronizacoes.ExtrairExtensaoAnexo(command.Anexo);

            var arquivoRegitrado = ArquivoRegistrado.Criar(
                    command.ColaboradorId,
                    command.ReferenciaAno,
                    command.ReferenciaMes,
                    command.TipoArquivo,
                    command.Observacoes,
                    extensaoAnexo);

            var respostaAnexoSalvo = _anexoFacade.SalvarAnexoEmDiretorio(command.Anexo, arquivoRegitrado.Anexo.Codigo);
            if(respostaAnexoSalvo.EhFalha)
                return respostaAnexoSalvo.Falha;

            var arquivoModel = _adapter.DeArquivoRegistadoParaArquivoModel(arquivoRegitrado);
            
            var respostaArquivoCriado = _repositorio.PersistirArquivo(arquivoModel);
            if(respostaArquivoCriado is false)
                return new ErroNenhumRegistroModificado(ArquivoTextosInformativos.NENHUM_REGISTRO_MODIFICADO);

            return respostaArquivoCriado;
        }
    }
}