using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.ObterColaboradores;
using Colaborador.Domain.Entidades;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class ObterColaboradoresHandlerTestes : IClassFixture<ColaboradorServicesFixtures>
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly IObterColaboradores _sut;

        public ObterColaboradoresHandlerTestes(ColaboradorServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<ObterColaboradoresHandler>();
        }

        [Trait("Colaborador.Business.Services", "ObterColaboradoresHandlerTestes")]
        [Fact(DisplayName = "Retornar lista de colaboradores caso não ocorrer erro no retorno do repositório.")]
        public void AoInvocarHandler_QuandoSucessoRetornoRepositorio_DeveRetornarListaColaboradores()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ObterColaboradores()).Returns(_fixtures.GerarListaColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(r => r.DeListaColaboradorModelParaListaColaboradorEmpresa(It.IsAny<IReadOnlyCollection<ColaboradorModel>>())).Returns(_fixtures.GerarListaColaboradorEmpresa());

            // Act
            var resultado = _sut.Handler();

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.All(resultado.Sucesso, x => Assert.Matches(_fixtures.GerarPatternCPFComCaracteresEspeciais(), resultado.Sucesso.First().ColaboradorCPF.NumeroCPF));
            Assert.True(resultado.Sucesso is IReadOnlyCollection<ColaboradorEmpresa>);
        }
    }
}
