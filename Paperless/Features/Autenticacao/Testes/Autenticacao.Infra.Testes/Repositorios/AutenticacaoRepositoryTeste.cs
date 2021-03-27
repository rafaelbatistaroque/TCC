using Autenticacao.Business.Contracts;
using Autenticacao.Infra.Testes.Fixtures;

namespace Autenticacao.Infra.Testes.Repositorios
{
    public class AutenticacaoRepositoryTeste
    {

        //private readonly AutenticacaoRepositoriosFixtures _fixtures;
        //private readonly IAutenticacaoRepository _sut;

        //public AutenticacaoRepositoryTeste()
        //{
        //    _fixtures = new AutenticacaoRepositoriosFixtures();
        //    _sut = _fixtures.GerarSUT();
        //}

        //[Trait("Autenticacao.Infra.Repositorios", "AutenticacaoRepositoryTeste")]
        //[Fact(DisplayName = "Retorna erro caso usuário não for encontrado")]
        //public void AoInvocarObterUsuario_QuandoNaoEncontrarUsuario_DeveRetornarErroEspecifico()
        //{
        //    // Arrange
        //    _fixtures.Mocker.GetMock<IContextAggregate>().Setup(x => x.Usuarios.Any()).Returns(false);

        //    // Act
        //    var resultado = _sut.ObterUsuario(It.IsAny<int>(), It.IsAny<string>());

        //    // Assert
        //    Assert.NotNull(resultado);
        //    Assert.True(resultado.EhFalha);
        //    Assert.IsType<ErroAutenticacaoUsuarioInvalido>(resultado.Falha);
        //}
    }
}
