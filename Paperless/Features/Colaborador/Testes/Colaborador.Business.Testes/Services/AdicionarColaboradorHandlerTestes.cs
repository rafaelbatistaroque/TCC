using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.AdicionarColaborador;
using Paperless.Shared.Erros;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class AdicionarColaboradorHandlerTestes
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly IAdicionarColaborador _sut;

        public AdicionarColaboradorHandlerTestes()
        {
            _fixtures = new ColaboradorServicesFixtures();
            _sut = _fixtures.GerarSUT<AdicionarColaboradorHandler>();
        }

        [Trait("Colaborador.Business.Services", "AdicionarColaboradorHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData("", "", "")]
        [InlineData(" ", " ", " ")]
        [InlineData(null, null, null)]
        [InlineData("Nome válido ", "123", "Função válida")]
        [InlineData("Nome válido", "1231234561212122", "Função válida")]
        [InlineData("3211 12", "00000000000", "Função válida")]
        [InlineData("Nome válido", "00000000000", "12345")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(string colaboradorNome, string colaboradorCpf, string colaboradorFuncaoEmpresa)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarAdicionarColaboradorCommand(colaboradorNome, colaboradorCpf, colaboradorFuncaoEmpresa);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "AdicionarColaboradorHandlerTestes")]
        [Fact(DisplayName = "NomeDoTeste")]
        public void AoRealizarDeterminadaAcao_QuandoNaCondicao_DeveFazer()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
