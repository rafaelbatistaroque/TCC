using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Business.Services;
using Colaborador.Business.Testes.Fixtures;
using Colaborador.Domain.CasosDeUso.AlterarColaborador;
using Colaborador.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Colaborador.Business.Testes.Services
{
    public class AlterarColaboradorHandlerTestes : IClassFixture<ColaboradorServicesFixtures>
    {
        private readonly ColaboradorServicesFixtures _fixtures;
        private readonly IAlterarColaborador _sut;

        public AlterarColaboradorHandlerTestes(ColaboradorServicesFixtures fixtures)
        {
            _fixtures = fixtures;
            _sut = _fixtures.GerarSUT<AlterarColaboradorHandler>();
        }

        [Trait("Colaborador.Business.Services", "AlterarColaboradorHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData(0, "", "", -1)]
        [InlineData(-1, " ", " ", 0)]
        [InlineData(0, null, null, 11)]
        [InlineData(-1, "PrimeiroNome", "sobrenome valido", 0)]
        [InlineData(-1, "PrimeiroNome", "sobrenome valido", 2)]
        [InlineData(-1, "3211 12", "6945s", 0)]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(int id, string primeiroNome, string sobrenome, int colaboradorFuncaoEmpresa)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarAlterarColaboradorCommandInvalido(id, primeiroNome, sobrenome, colaboradorFuncaoEmpresa);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroValidacaoCommandQuery>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "AlterarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se colaborador não existir")]
        public void AoInvocarHandler_QuandoColaboradorNaoExistir_DeveRetornarErroNenhumRegistroEncontrado()
        {
            // Arrange
            var commandValido = _fixtures.GerarAlterarColaboradorCommandValido();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(false);

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Colaborador.Business.Services", "AlterarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se nenhum registro modificado ao alterar colaborador")]
        public void AoInvocarHandler_QuandoRetornoNenhumRegistroAfetado_DeveRetornarBooleanoErroNehumRegistroFoiSalvo()
        {
            // Arrange
            var commandValido = _fixtures.GerarAlterarColaboradorCommandValido();
            Expression<Func<ColaboradorModel, bool>> criterios =
                x => x.Id == commandValido.Id
                && x.Nome.PrimeiroNome == commandValido.PrimeiroNome
                && x.Nome.Sobrenome == commandValido.Sobrenome
                && x.Funcao.FuncaoId == commandValido.FuncaoId;
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(a => a.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(a => a.AlterarColaborador(It.IsAny<ColaboradorModel>())).Returns(false);
            _fixtures.Mocker.GetMock<IColaboradorAdapters>().Setup(a => a.DeColaboradorParaColaboradorModel(It.IsAny<ColaboradorEmpresa>())).Returns(_fixtures.GerarColaboradorModelAlterado());

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroModificado>(resultado.Falha);
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Verify(x => x.AlterarColaborador(It.Is(criterios)), "Valores da model não são as mesmas enviadas pelo command.");
        }

        [Trait("Colaborador.Business.Services", "AlterarColaboradorHandlerTestes")]
        [Fact(DisplayName = "Retornar booleano true após alterar colaborador na base de dados")]
        public void AoInvocarHandler_QuandoNaoOcorrerErroAoAlterarColaborador_DeveRetornarBooleanoTrue()
        {
            // Arrange
            var commandValido = _fixtures.GerarAlterarColaboradorCommandValido();
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IColaboradorRepository>().Setup(r => r.AlterarColaborador(It.IsAny<ColaboradorModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(commandValido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
        }
    }
}
