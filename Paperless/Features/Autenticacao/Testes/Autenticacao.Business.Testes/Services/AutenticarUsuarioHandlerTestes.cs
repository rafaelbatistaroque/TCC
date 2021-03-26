using Autenticacao.Business.Contracts;
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
        [InlineData(-1, "")]
        [InlineData(0, " ")]
        [InlineData(22, null)]
        [InlineData(333, "drop")]
        [InlineData(4444, "or 1=1")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(int usuarioIdentificador, string senha)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarAutenticarUsuarioCommand(usuarioIdentificador, senha);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retorna erro quando usuário é inválido")]
        public void AoInvocarHandler_QuandoFalhaAoObterUsuario_DeveRetornaErroProvenienteDoRepositorio()
        {
            // Arrange
            var commandValido = _fixtures.GerarAutenticarUsuarioCommandValido();
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<int>(), It.IsAny<string>())).Returns(_fixtures.GerarErrogenerico());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Services", "AutenticarUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retorna usuário autenticado depois de receber token")]
        public void AoInvocarHandler_AposObterUsuario_DeveInvocarGerarTokenERetornarUsuarioAutenticado()
        {
            var commandValido = _fixtures.GerarAutenticarUsuarioCommandValido();
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<int>(), It.IsAny<string>())).Returns(_fixtures.GerarUsuarioModel());
            _fixtures.Mocker.GetMock<IJWT>().Setup(r => r.GerarToken(It.IsAny<int>(), It.IsAny<string>())).Returns(_fixtures.GerarTokeFake());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.Equal(_fixtures.GerarTokeFake(), resultado.Sucesso.Token);
            Assert.Equal(_fixtures.GerarUsuarioModel().NomeUsuario, resultado.Sucesso.NomeUsuario);
            Assert.IsType<UsuarioAutenticado>(resultado.Sucesso);
            _fixtures.Mocker.GetMock<IJWT>().Verify(r => r.GerarToken(It.IsAny<int>(), It.IsAny<string>()), Times.Once, NAO_INVOCADO);
        }
    }
}
