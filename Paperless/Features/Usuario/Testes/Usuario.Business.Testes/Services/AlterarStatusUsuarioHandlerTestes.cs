using Moq;
using Paperless.Shared.Erros;
using System;
using System.Linq.Expressions;
using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Business.Services;
using Usuario.Business.Testes.Fixtures;
using Usuario.Domain.CasosDeUso.AlterarStatusUsuario;
using Xunit;

namespace Usuario.Business.Testes.Services
{
    public class AlterarStatusUsuarioHandlerTestes : IClassFixture<UsuarioServicesFixtures>
    {
        private readonly UsuarioServicesFixtures _fixtures;
        private readonly IAlterarStatusUsuario _sut;

        public AlterarStatusUsuarioHandlerTestes(UsuarioServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<AlterarStatusUsuarioHandler>();
        }

        [Trait("Usuario.Business.Services", "AlterarStatusUsuarioHandlerTestes")]
        [Theory(DisplayName = "Command inválido")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("drop")]
        [InlineData("or 1=1")]
        [InlineData("EEEE")]
        [InlineData("EEEEEE")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornarErros(string codigo)
        {
            // Arrange
            var command = _fixtures.GerarAlterarStatusUsuarioCommandInvalido(codigo);

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroValidacaoCommandQuery>(resultado.Falha);
        }

        [Trait("Usuario.Business.Services", "AlterarStatusUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retornar erro proveniente caso retorno erro repositorio.")]
        public void AoInvocarHandler_QuandoErroRetornoRepositorio_DeveRetornarErroProveniente()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(_fixtures.GerarAlterarStatusUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Usuario.Business.Services", "AlterarStatusUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retornar erro proveniente de repositório ao atualizar usuário")]
        public void AoInvocarHandler_QuandoErroAoAtualizarUsuario_DeveRetornarErroProveniente()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.AtualizarUsuario(It.IsAny<UsuarioDoSistemaModel>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(_fixtures.GerarAlterarStatusUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Usuario.Business.Services", "AlterarStatusUsuarioHandlerTestes")]
        [Fact(DisplayName = "Retornar erro de nenhum registro atualizado retorno de repositorio for false.")]
        public void AoInvocarHandler_QuandoRetornarFalsoAPosAtualizar_DeveRetornarErroNenhumaRegistroAtualizado()
        {
            // Arrange
            var criterio =
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.AtualizarUsuario(It.IsAny<UsuarioDoSistemaModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarAlterarStatusUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroFoiSalvoOuAtualizado>(resultado.Falha);
        }

        [Trait("Usuario.Business.Services", "AlterarStatusUsuarioHandlerTestes")]
        [Fact(DisplayName = "Atualizar usuário garantindo que a propriedade EhUsuarioAtivo, passada por parametro, é inversa à atual.")]
        public void AoInvocarHandler_QuandoGarantidoQuePropriedadePassadaPorParametroEhInversaAAtual_DeveAtualizarUsuarioERetornarBooleano()
        {
            // Arrange
            Expression<Func<UsuarioDoSistemaModel, bool>> criterio = u => u.EhUsuarioAtivo == !_fixtures.GerarUsuarioDoSistemaModel().EhUsuarioAtivo;
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.AtualizarUsuario(It.IsAny<UsuarioDoSistemaModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarAlterarStatusUsuarioCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Verify(r => r.AtualizarUsuario(It.Is(criterio)), "Status usuário não foi modificado");
        }
    }
}
