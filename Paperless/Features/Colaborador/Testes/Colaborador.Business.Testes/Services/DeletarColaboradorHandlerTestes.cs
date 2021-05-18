using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.DeletarColaborador;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class DeletarColaboradorHandlerTestes : IClassFixture<ColaboradorServicesFixtures>
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly IDeletarColaborador _sut;

        public DeletarColaboradorHandlerTestes(ColaboradorServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<DeletarColaboradorHandler>();
        }

        [Trait("Colaborador.Business.Services", "DeletarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se erro ao obter colaborador")]
        public void AoInvocarHandler_QuandoErroRetornoRepositorio_DeveRetornarErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "DeletarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se colaborador não existir")]
        public void AoInvocarHandler_QuandoColaboradorNaoExistir_DeveRetornarErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns((ColaboradorModel)null);

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "DeletarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro proveniente se erro ao deletar colaborador")]
        public void AoInvocarHandlers_QuandoErroAoDeletarColaborador_DeveRetornarErroProveniente()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.DeletarColaborador(It.IsAny<ColaboradorModel>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "DeletarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se nenhum registro modificado ao deletar colaborador")]
        public void AoInvocarHandler_QuandoNenhumRegistroModificado_DeveRetornarNenhumRegistroModificado()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.DeletarColaborador(It.IsAny<ColaboradorModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroModificado>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "DeletarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar booleano true após deletar colaborador na base de dados")]
        public void AoInvocarHandler_QuandoNaoOcorrerErroAoDeletarColaborador_DeveRetornarBooleanoTrue()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.DeletarColaborador(It.IsAny<ColaboradorModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
        }
    }
}
