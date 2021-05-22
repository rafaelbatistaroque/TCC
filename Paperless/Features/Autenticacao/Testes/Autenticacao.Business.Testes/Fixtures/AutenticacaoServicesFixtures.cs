using Autenticacao.Business.Models;
using Autenticacao.Business.Services;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Fixtures;
using Moq.AutoMock;
using Paperless.Shared.Erros;

namespace Autenticacao.Business.Testes.Fixtures
{
    public class AutenticacaoServicesFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get; }
        public AutenticacaoServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticarUsuarioHandler GerarSUT()
            => Mocker.CreateInstance<AutenticarUsuarioHandler>();

        public AutenticarUsuarioCommand GerarAutenticarUsuarioCommandInvalido(string usuarioIdentificador, string senha)
            => new AutenticarUsuarioCommand() { UsuarioIdentificacao = usuarioIdentificador, UsuarioSenha = senha };

        public AutenticarUsuarioCommand GerarAutenticarUsuarioCommandValido()
            => new AutenticarUsuarioCommand() { UsuarioIdentificacao = USUARIO_IDENTIFICADOR_VALIDO, UsuarioSenha = SENHA_VALIDA };

        public AutenticarUsuarioCommand GerarAutenticarUsuarioCommandSenhaInvalida()
            => new AutenticarUsuarioCommand() { UsuarioIdentificacao = USUARIO_IDENTIFICADOR_VALIDO, UsuarioSenha = "SenhaInvalida" };

        public UsuarioDoSistemaModel GerarUsuarioModel()
            => new UsuarioDoSistemaModel()
            {
                UsuarioNome = USUARIO_NOME_VALIDO,
                UsuarioSenha = SENHA_BASE64_VALIDA,
                UsuarioIdentificacao = USUARIO_IDENTIFICADOR_VALIDO,
                EhUsuarioAtivo = USUARIO_ATIVO_VALIDO,
                UsuarioPerfilId = USUARIO_PERFIL_ID_ADM
            };

        public string GerarTokenFake() => FAKE_TOKEN;

        public string GerarTokenBearerFake() => $"Bearer {FAKE_TOKEN}";

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
