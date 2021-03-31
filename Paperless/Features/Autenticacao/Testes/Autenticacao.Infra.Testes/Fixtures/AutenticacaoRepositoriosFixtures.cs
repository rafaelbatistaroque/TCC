using Autenticacao.Business.Models;
using Autenticacao.Infra.Repositorios;
using Moq.AutoMock;
using Paperless.Fixtures.Autenticacao;
using Paperless.Shared.Erros;

namespace Autenticacao.Infra.Testes.Fixtures
{
    public class AutenticacaoRepositoriosFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get; }

        public AutenticacaoRepositoriosFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticacaoRepository GerarSUT()
            => Mocker.CreateInstance<AutenticacaoRepository>();

        public UsuarioDoSistemaModel GerarUsuarioModel()
         => new UsuarioDoSistemaModel()
         {
             UsuarioNome = USUARIO_NOME_VALIDO,
             UsuarioSenha = SENHA_BASE64_VALIDA,
             UsuarioIdentificacao = USUARIO_IDENTIFICADOR_VALIDO,
             EhUsuarioAtivo = USUARIO_ATIVO_VALIDO,
             UsuarioPerfilNome = USUARIO_PERFIL_VALIDO
         };

        public ErroBase GerarErrogenerico() => ErroGenerico();
    }
}
