using Autenticacao.Business.Contracts;
using Autenticacao.Business.Erros;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Autenticacao.Business.Services
{
    public class AutenticarUsuarioHandler : IAutenticarUsuario
    {
        private readonly IJWT _tokenServico;
        private readonly IAutenticacaoRepository _repositorio;

        public AutenticarUsuarioHandler(IJWT tokenServico, IAutenticacaoRepository repositorio)
        {
            _tokenServico = tokenServico;
            _repositorio = repositorio;
        }

        public Either<ErroBase, UsuarioAutenticado> Handler(AutenticarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var usuario = _repositorio.ObterUsuario(command.UsuarioIdentificacao);
            if(usuario is null)
                return new ErroRegistroNaoEncontrado(AutenticacaoTextosInformativos.USUARIO_NAO_ENCONTRADO);

            string senhaDescriptografada = Padronizacoes.DescriptografarDeBase64(usuario.UsuarioSenha);
                
            if(command.UsuarioSenha.Equals(senhaDescriptografada) == false)
                return new ErroAutenticacaoUsuario(AutenticacaoTextosInformativos.SENHA_INVALIDA);

            var token = _tokenServico.GerarToken(usuario.UsuarioIdentificacao.ToUpper(), Padronizacoes.ObterNomePerfil(usuario.UsuarioPerfilId));
            var usuarioAutenticado = UsuarioAutenticado.Criar(usuario.UsuarioNome, usuario.UsuarioPerfilId, token);

            return usuarioAutenticado;
        }
    }
}
