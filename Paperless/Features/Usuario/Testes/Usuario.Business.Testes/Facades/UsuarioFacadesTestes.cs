using Moq;
using Usuario.Business.Contracts;
using Usuario.Business.Facades;
using Usuario.Business.Testes.Fixtures;
using Usuario.Domain.Entidades;
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
        [Fact(DisplayName = "Garantir que informações de usuário esteja na model usuário.")]
        public void AoInvocarCriarNovoUsuarioFacades_QuandoArgumentoValidos_DeveAdaptarConteudoAModelCorrespondente()
        {
            // Arrange
            var usuarioDoSistemaModel = _fixtures.GerarUsuarioDoSistemaModel();
            _fixtures.Mocker.GetMock<IUsuarioAdapters>().Setup(f => f.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(It.IsAny<UsuarioDoSistema>())).Returns(usuarioDoSistemaModel);

            // Act
            var resultado = _sut.CriarNovoUsuarioFacades(_fixtures.GerarNomeValido(), _fixtures.GerarSenhaValida(), _fixtures.GerarPerfilAdmIdValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(usuarioDoSistemaModel.UsuarioIdentificacao.Codigo, resultado.UsuarioIdentificacao.Codigo);
            Assert.Equal(usuarioDoSistemaModel.UsuarioPerfil.PerfilNome, resultado.UsuarioPerfil.PerfilNome);
            Assert.Equal(usuarioDoSistemaModel.UsuarioPerfil.PerfilId, resultado.UsuarioPerfil.PerfilId);
            Assert.Equal(_fixtures.GerarSenhaBase64(), resultado.UsuarioSenha.Senha);
            _fixtures.Mocker.GetMock<IUsuarioAdapters>().Verify(f => f.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(It.IsAny<UsuarioDoSistema>()), Times.Once, NAO_INVOCADO);
        }
    }
}
