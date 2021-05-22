using Autenticacao.Business.Contracts;
using Autenticacao.Business.Erros;
using Autenticacao.Business.Models;
using Autenticacao.Business.Testes.Fixtures;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Autenticacao.Business.Testes.Services
{
    public class AutenticarUsuarioHandlerTestes
    {
        private const string NAO_INVOCADO = "Método não invocado";

        private readonly AutenticacaoServicesFixtures _fixtures;
        private readonly IAutenticarUsuario _sut;

        public AutenticarUsuarioHandlerTestes()
        {
            _fixtures = new AutenticacaoServicesFixtures();
            _sut = _fixtures.GerarSUT();

        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData(null, null)]
        [InlineData("1", "or 1=1")]
        [InlineData("12", "drop")]
        [InlineData("112", "drop")]
        [InlineData("112R", "drop")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(string usuarioIdentificador, string senha)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarAutenticarUsuarioCommandInvalido(usuarioIdentificador, senha);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Erro ao obter caso usuário não existir")]
        public void AoInvocarHandle_QuandoNaoExistirUsuario_DeveRetornarErroNenhumUsuarioencontrado()
        {
            // Arrange
            var commandValido = _fixtures.GerarAutenticarUsuarioCommandValido();
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns((UsuarioDoSistemaModel)null);

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retorna erro caso senha não coincidir.")]
        public void AoInvocarHandler_QuandoSenhasNaoCoincidirem_DeveRetornaErroEspecífico()
        {
            var commandValido = _fixtures.GerarAutenticarUsuarioCommandSenhaInvalida();
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioModel());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEqual(_fixtures.GerarUsuarioModel().UsuarioSenha, commandValido.UsuarioSenha);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroAutenticacaoUsuario>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retorna usuário autenticado depois de receber token")]
        public void AoInvocarHandler_AposObterUsuario_DeveInvocarGerarTokenERetornarUsuarioAutenticado()
        {
            var commandValido = _fixtures.GerarAutenticarUsuarioCommandValido();
            _fixtures.Mocker.GetMock<IJWT>().Setup(r => r.GerarToken(It.IsAny<string>(), It.IsAny<string>())).Returns(_fixtures.GerarTokenFake());
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioModel());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.Equal(_fixtures.GerarTokenBearerFake(), resultado.Sucesso.Token);
            Assert.Equal(_fixtures.GerarUsuarioModel().UsuarioNome, resultado.Sucesso.NomeUsuario);
            Assert.IsType<UsuarioAutenticado>(resultado.Sucesso);
            _fixtures.Mocker.GetMock<IJWT>().Verify(r => r.GerarToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once, NAO_INVOCADO);
        }
    }
}
