using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class ObterColaboradorHandlerTestes
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly IObterColaborador _sut;

        public ObterColaboradorHandlerTestes()
        {
            _fixtures = new ColaboradorServicesFixtures();
            _sut = _fixtures.GerarSUT<ObterColaboradorHandler>();
        }

        [Trait("Colaborador.Business.Services", "ObterColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se erro ao verificar se colaborador existe")]
        public void AoInvocarHandler_QuandoErroRetornoRepositorio_DeveRetornarErroespecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "ObterColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se colaborador não existir")]
        public void AoInvocarHandler_QuandoColaboradorNaoExistir_DeveRetornarErroespecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(false);
            
            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "ObterColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro proveniente se erro ao obter colaborador")]
        public void AoInvocarHandler_QuandoErroAoObterColaborador_DeveRetornarErroProveniente()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }


        [Trait("Colaborador.Business.Services", "ObterColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar colaborador caso não ocorrer erro ao obter colaborador")]
        public void AoInvocarHandler_QuandoNaoOcorrerErroAoObterColaborador_DeveRetornarColaborador()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IColaboradorRepository>().InSequence(sequencia).Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(r => r.DeColaboradorModelParaColaborador(It.IsAny<ColaboradorModel>())).Returns(_fixtures.GerarColaboradorEmpresa());

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<ColaboradorEmpresa>(resultado.Sucesso);
        }
    }
}
