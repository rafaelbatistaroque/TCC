using Autenticacao.Business.Contracts;
using Autenticacao.Business.Contracts.Extensoes;
using Autenticacao.Business.Erros;
using Autenticacao.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;

namespace Autenticacao.Business.Facades
{
    public class AutenticacaoFacades : IAutenticacaoFacades
    {
        private readonly IAutenticacaoRepository _repositorio;

        public AutenticacaoFacades(IAutenticacaoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        Either<ErroBase, UsuarioDoSistemaModel> IObterUsuarioFacades.ObterUsuarioFacades(string codigoIdentificacao)
        {
            var existeEsteUsuario = _repositorio.UsuarioExiste(codigoIdentificacao);
            if(existeEsteUsuario.EhFalha || existeEsteUsuario?.Sucesso == false)
                return new ErroAutenticacaoUsuario(AutenticacaoTextosInformativos.USUARIO_NAO_ENCONTRADO);

            var usuario = _repositorio.ObterUsuario(codigoIdentificacao);
            if(usuario.EhFalha)
                return new ErroAutenticacaoUsuario(AutenticacaoTextosInformativos.ERRO_COMUNICACAO_COM_BASE);

            return usuario;
        }
    }
}
