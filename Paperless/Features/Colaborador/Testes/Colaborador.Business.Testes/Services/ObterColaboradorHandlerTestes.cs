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
        [Fact(DisplayName = "Retornar erro proveniente se erro ao obter colaborador")]
        public void AoInvocarHandler_QuandoErroAoObterColaborador_DeveRetornarErroProveniente()
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

        [Trait("Colaborador.Business.Services", "ObterColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar colaborador caso não ocorrer erro ao obter colaborador")]
        public void AoInvocarHandler_QuandoNaoOcorrerErroAoObterColaborador_DeveRetornarColaborador()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ObterColaborador(It.IsAny<int>())).Returns(_fixtures.GerarColaboradorModel());
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
