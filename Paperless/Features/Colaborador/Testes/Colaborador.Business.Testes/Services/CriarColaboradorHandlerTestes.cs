using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class CriarColaboradorHandlerTestes : IClassFixture<ColaboradorServicesFixtures>
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly ICriarColaborador _sut;

        public CriarColaboradorHandlerTestes(ColaboradorServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<CriarColaboradorHandler>();
        }

        [Trait("Colaborador.Business.Services", "CriarColaboradorHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData("", "", "", -1)]
        [InlineData(" ", " ", " ", 0)]
        [InlineData(null, null, null, 11)]
        [InlineData("PrimeiroNome", "sobrenome valido", "123", 0)]
        [InlineData("PrimeiroNome", "sobrenome valido", "1231234561212122", 0)]
        [InlineData("3211 12", "6945s", "00000000000", 0)]
        [InlineData("PrimeiroNome", "sobrenome valido", "00000000000", 0)]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(string primeiroNome, string sobrenome, string colaboradorCpf, int colaboradorFuncaoEmpresa)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarCriarColaboradorCommand(primeiroNome, sobrenome, colaboradorCpf, colaboradorFuncaoEmpresa);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "CriarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro quando retornar falha no repositório")]
        public void AoInvocarHandler_QuandoFalhaNoretornoDoRepositorio_DeveRetornarErroProveniente()
        {
            // Arrange
            var commandValido = _fixtures.GerarCriarColaboradorCommand();
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(a => a.DeColaboradorParaColaboradorModel(It.IsAny<ColaboradorEmpresa>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(a => a.CriarColaborador(It.IsAny<ColaboradorModel>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "CriarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se nenhum registro foi salvo na base de dados")]
        public void AoInvocarHandler_QuandoRetornoNenhumRegistroAfetado_DeveRetornarBooleanoErroNehumRegistroFoiSalvo()
        {
            // Arrange
            var commandValido = _fixtures.GerarCriarColaboradorCommand();
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(a => a.DeColaboradorParaColaboradorModel(It.IsAny<ColaboradorEmpresa>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(a => a.CriarColaborador(It.IsAny<ColaboradorModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroModificado>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "CriarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar booleano true após persistir colaborador na base de dados")]
        public void AoInvocarHandler_QuandoRetornoSemFalhaDoRepositorio_DeveRetornarBooleanoTrue()
        {
            // Arrange
            var commandValido = _fixtures.GerarCriarColaboradorCommand();
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(a => a.DeColaboradorParaColaboradorModel(It.IsAny<ColaboradorEmpresa>())).Returns(_fixtures.GerarColaboradorModel());
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(a => a.CriarColaborador(It.IsAny<ColaboradorModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
        }
    }
}
