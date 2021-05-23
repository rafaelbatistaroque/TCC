using Moq;
using Paperless.Shared.Erros;
using System.Collections.Generic;
using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Business.Services;
using Usuario.Business.Testes.Fixtures;
using Usuario.Domain.CasosDeUso.ObterUsuarios;
using Usuario.Domain.Entidades;
using Xunit;

namespace Usuario.Business.Testes.Services
{
    public class ObterUsuariosHandlerTestes : IClassFixture<UsuarioServicesFixtures>
    {
        private readonly UsuarioServicesFixtures _fixtures;
        private readonly IObterUsuarios _sut;

        public ObterUsuariosHandlerTestes(UsuarioServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<ObterUsuariosHandler>();
        }

        [Trait("Usuario.Business.Services", "ObterUsuariosHandlerTestes")]
        [Fact(DisplayName = "Retornar lista de usuários caso não ocorrer erro no retorno do repositório.")]
        public void AoInvocarHandler_QuandoSucessoRetornoRepositorio_DeveRetornarListaUsuariosSistema()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IUsuarioRepository>().Setup(r => r.ObterUsuarios()).Returns(_fixtures.GerarListaUsuarioDoSistemaModel());
            _fixtures.Mocker.GetMock<IUsuarioAdapters>().Setup(r => r.DeListaUsuarioDoSistemaModelParaListaUsuarioDoSistema(It.IsAny<IReadOnlyCollection<UsuarioDoSistemaModel>>())).Returns(_fixtures.GerarListaGerarUsuarioDoSistema());

            // Act
            var resultado = _sut.Handler();

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.True(resultado.Sucesso is IReadOnlyCollection<UsuarioDoSistema>);
        }
    }
}
