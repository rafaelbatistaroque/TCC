using Moq;
using Usuario.Business.Contracts;
using Usuario.Business.Facades;
using Usuario.Business.Testes.Fixtures;
using Xunit;

namespace Usuario.Business.Testes.Facades
{
    public class UsuarioFacadesTestes
    {
        private const string NAO_INVOCADO = "Método não invocado";

        private readonly UsuarioFacadesFixtures _fixtures;
        private readonly IUsuarioFacades _sut;

        public UsuarioFacadesTestes()
        {
            _fixtures = new UsuarioFacadesFixtures();
            _sut = _fixtures.GerarSUT<UsuarioFacades>();
        }

        [Trait("Usuario.Business.Facades", "UsuarioFacadesTestes")]
        [Fact(DisplayName = "Garantir que factory de perfil seja chamado e retornado perfil correto.")]
        public void AoInvocarCriarNovoUsuarioFacades_QuandoArgumentoIgualAUm_DeveCriarPerfilDeUsuarioAdministradorPorMeioDaFactoryEspecifica()
        {
            // Arrange
            var perfilAdmValido = _fixtures.GerarPerfilADM();
            _fixtures.Mocker.GetMock<IUsuarioFactories>().Setup(f => f.ObterPerfilUsuarioFactory(It.IsAny<int>())).Returns(perfilAdmValido);

            // Act
            var resultado = _sut.CriarNovoUsuarioFacades(It.IsAny<string>(), _fixtures.GerarSenhaValida(), It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(perfilAdmValido, resultado.UsuarioPerfil);
            _fixtures.Mocker.GetMock<IUsuarioFactories>().Verify(f => f.ObterPerfilUsuarioFactory(It.IsAny<int>()), Times.Once, NAO_INVOCADO);
        }
    }
}
