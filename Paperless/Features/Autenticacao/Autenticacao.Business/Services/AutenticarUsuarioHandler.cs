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
        private readonly IAutenticacaoFacades _facades;
        private readonly IJWT _tokenServico;

        public AutenticarUsuarioHandler(IAutenticacaoFacades facades, IJWT tokenServico)
        {
            _facades = facades;
            _tokenServico = tokenServico;
        }

        public Either<ErroBase, UsuarioAutenticado> Handler(AutenticarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var usuario = _facades.ObterUsuarioFacades(command.UsuarioIdentificacao);
            if(usuario.EhFalha)
                return usuario.Falha;

            string senhaDescriptografada = Padronizacoes.DescriptografarDeBase64(usuario.Sucesso.UsuarioSenha);
                
            if(command.UsuarioSenha.Equals(senhaDescriptografada) == false)
                return new ErroAutenticacaoUsuario(AutenticacaoTextosInformativos.SENHA_INVALIDA);

            var token = _tokenServico.GerarToken(usuario.Sucesso.UsuarioIdentificacao.ToUpper(), Padronizacoes.ObterNomePerfil(usuario.Sucesso.UsuarioPerfilId));
            var usuarioAutenticado = UsuarioAutenticado.Criar(usuario.Sucesso.UsuarioNome, usuario.Sucesso.UsuarioPerfilId, token);

            return usuarioAutenticado;
        }
    }
}
