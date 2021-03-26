using Autenticacao.Business.Contracts;
using Autenticacao.Business.Models;
using Autenticacao.Infra.Contracts;
using Autenticacao.Infra.EF;
using Autenticacao.Infra.Erros;
using Autenticacao.Infra.Queries;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Autenticacao.Infra.Repositorios
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly IAutenticacaoContext _context;

        public AutenticacaoRepository(IAutenticacaoContext context)
        {
            _context = context;
        }

        public Either<ErroBase, UsuarioModel> ObterUsuario(int usuarioIdentificador, string senha)
        {
            var existeEsteUsuario = _context.Usuarios.Any(Query.UsuarioAtivoComEsteIdentificador(usuarioIdentificador));
            if(existeEsteUsuario == false)
                return new ErroAutenticacaoUsuarioInvalido(AutenticacaoTextosInformativos.USUARIO_NAO_ENCONTRADO);

            var usuario = _context.Usuarios.FirstOrDefault(Query.UsuarioAtivoComEsteIdentificador(usuarioIdentificador));
            string senhaDescriptografada = PaperlessPadronizacoes.DescriptografarDeBase64(usuario.Senha);

            if(senha.Equals(senhaDescriptografada) == false)
                return new ErroAutenticacaoUsuarioInvalido(AutenticacaoTextosInformativos.USUARIO_SENHA_INVALIDOS);

            return usuario;
        }
    }
}
