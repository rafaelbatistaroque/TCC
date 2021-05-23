using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;
using Usuario.Business.Contracts;
using Usuario.Domain.CasosDeUso.AlterarStatusUsuario;

namespace Usuario.Business.Services
{
    public class AlterarStatusUsuarioHandler : IAlterarStatusUsuario
    {
        private readonly IUsuarioRepository _repositorio;

        public AlterarStatusUsuarioHandler(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Either<ErroBase, bool> Handler(AlterarStatusUsuarioCommand commandQuery)
        {
            commandQuery.Validar();
            if(commandQuery.Invalid)
                return new ErroValidacaoCommandQuery(commandQuery.Notifications.Select(e => e.Message).ToArray());

            var usuarioModel = _repositorio.ObterUsuario(commandQuery.UsuarioCodigo);
            if(usuarioModel is null)
                return new ErroRegistroNaoEncontrado(UsuarioTextosInformativos.USUARIO_NAO_ENCONTRADO);

            usuarioModel.EhUsuarioAtivo = !usuarioModel.EhUsuarioAtivo;

            var respostaUsuarioAtualizado = _repositorio.AtualizarUsuario(usuarioModel);
            if(respostaUsuarioAtualizado is false)
                return new ErroNenhumRegistroModificado(UsuarioTextosInformativos.NENHUM_REGISTRO_SALVO_ATUALIZADO);

            return respostaUsuarioAtualizado;
        }
    }
}
