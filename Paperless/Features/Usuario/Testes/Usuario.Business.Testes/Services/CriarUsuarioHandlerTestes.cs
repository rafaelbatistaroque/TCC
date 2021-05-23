using Moq;
using Paperless.Shared.Erros;
using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Business.Services;
using Usuario.Business.Testes.Fixtures;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Domain.Entidades;
using Xunit;

namespace Usuario.Business.Testes.Services
{
    public class CriarUsuarioHandlerTestes : IClassFixture<UsuarioServicesFixtures>
    {
        private const string NAO_INVOCADO = "Método não invocado";

        private readonly UsuarioServicesFixtures _fixtures;
        private readonly ICriarUsuario _sut;

        public CriarUsuarioHandlerTestes(UsuarioServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<CriarUsuarioHandler>();
        }

        [Trait("Usuario.Business.Services", "CriarUsuarioHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData("", "", -1)]
        [InlineData(" ", " ", 0)]
        [InlineData(null, null, 3)]
        [InlineData("drop", "drop", 0.5)]
        [InlineData("or 1=1", "or 1=1", 12)]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(string usuarioNome, string usuarioSenha, int usuarioPerfil)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarCriarUsuarioCommandInvalido(usuarioNome, usuarioSenha, usuarioPerfil);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroValidacaoCommandQuery>(resultado.Falha);
        }

        [Trait("Usuario.Business.Services", "CriarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Erro no retorno do repositório após criado novo usuário válido")]
        public void AoInvocarHandle_AposCriadoUsuarioValidoEOcorrerErroNoRetornoDoRepositorio_DeveRetornarErroProveniente()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IUsuarioAdapters>().Setup(f => f.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(It.IsAny<UsuarioDoSistema>())).Returns(_fixtures.GerarUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.CriarUsuario(It.IsAny<UsuarioDoSistemaModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarCriarUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumArquivoArmazenado>(resultado.Falha);
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Verify(r => r.CriarUsuario(It.IsAny<UsuarioDoSistemaModel>()), Times.Once, NAO_INVOCADO);
        }

        [Trait("Usuario.Business.Services", "CriarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Garantir retorno de sucesso quando usuário for persistido")]
        public void AoInvocarHandle_QuandoUsuarioPersitidoNoBanco_DeveRetornarValorBooleanoTrue()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IUsuarioAdapters>().Setup(f => f.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(It.IsAny<UsuarioDoSistema>())).Returns(_fixtures.GerarUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.CriarUsuario(It.IsAny<UsuarioDoSistemaModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarCriarUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.True(resultado.Sucesso);
        }
    }
}
