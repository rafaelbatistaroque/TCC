using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Business.Services;
using Arquivo.Business.Testes.Fixtures;
using Arquivo.Domain.CasosDeUso.ObterArquivos;
using Arquivo.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using System.Collections.Generic;
using Xunit;

namespace Arquivo.Business.Testes.Services
{
    public class ObterArquivosDeColaboradorHandlerTestes : IClassFixture<ArquivoServicesFixtures>
    {
        private readonly ArquivoServicesFixtures _fixtures;
        private readonly IObterArquivosDeColaborador _sut;

        public ObterArquivosDeColaboradorHandlerTestes(ArquivoServicesFixtures fixture)
        {
            _fixtures = fixture;
            _sut = _fixtures.CriarSUT<ObterArquivosDeColaboradorHandler>();
        }

        [Trait("Arquivo.Business.Services", "ObterArquivosDeColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se colaborador não existir")]
        public void AoInvocarHandler_QuandoColaboradorNaoExistir_DeveRetornarErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(false);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarColaboradorIdInvalido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }


        [Trait("Arquivo.Business.Services", "ObterArquivosDeColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar lista de arquivos vinculados ao id de colaborador")]
        public void AoInvocarHandler_QuandoNaoOcorrerErros_DeveRetornarRetornarListaDeArquivosVinculadoAoColaborador()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ObterArquivos(It.IsAny<int>())).Returns(_fixtures.GeraListaArquivoModel());
            _fixtures.Mocker.GetMock<IArquivoAdapter>().Setup(r => r.DeListaArquivoModelParaListaArquivoRegistado(It.IsAny<IReadOnlyCollection<ArquivoModel>>())).Returns(_fixtures.GeraListaArquivoRegistrado());

            // Act
            var resultado = _sut.Handler(_fixtures.GerarColaboradorIdValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.True(resultado.Sucesso is IReadOnlyCollection<ArquivoRegistrado>);
        }
    }
}
