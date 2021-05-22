using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Business.Services;
using Arquivo.Business.Testes.Fixtures;
using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Arquivo.Business.Testes.Services
{
    public class CriarArquivoHandlerTestes : IClassFixture<ArquivoServicesFixtures>
    {
        private readonly ArquivoServicesFixtures _fixtures;
        private readonly ICriarArquivo _sut;

        public CriarArquivoHandlerTestes(ArquivoServicesFixtures fixture)
        {
            _fixtures = fixture;
            _sut = _fixtures.CriarSUT<CriarArquivoHandler>();
        }

        [Trait("Arquivo.Business.Services", "CriarArquivoHandler")]
        [Theory(DisplayName = "Command Inválido")]
        [InlineData(0, "","",-1,null,"")]
        [InlineData(-1, " "," ",0,null," ")]
        [InlineData(0, null, null,-1, null, null)]
        [InlineData(-1, "drop", "drop",-1, null, "drop")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornarErrosDeValidacao(int colaboradorId, string refMes, string refAno, int tipoArquivo, IFormFile anexo, string observacoes)
        {
            // Arrange
            var command = _fixtures.GerarCriarArquivoCommandInvalido(colaboradorId, refMes, refAno, tipoArquivo, anexo, observacoes);

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroValidacaoCommandQuery>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "CriarArquivoHandler")]
        [Fact(DisplayName = "Retornar erro se colaborador não existir")]
        public void AoInvocarHandler_QuandoColaboradorNaoExistir_DeveRetornarErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(false);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarCriarArquivoCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "CriarArquivoHandler")]
        [Fact(DisplayName = "Retornar erro proveniente se erro ao salvar anexo em diretório")]
        public void AoInvocarHandler_QuandoErroAoSalvarAnexoDiretorio_DeveRetornarErroProveniente()
        {
            // Arrange
            var command = _fixtures.GerarCriarArquivoCommandValido();
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IAnexoFacade>().Setup(d => d.SalvarAnexoEmDiretorio(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "CriarArquivoHandler")]
        [Fact(DisplayName = "Retornar erro se nenhum registro modificado ao persistir arquivo")]
        public void AoInvocarHandler_QuandoFalseAoPersistirArquivo_DeveRetornarErroNenhumRegistroModificado()
        {
            // Arrange
            var command = _fixtures.GerarCriarArquivoCommandValido();
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IAnexoFacade>().Setup(d => d.SalvarAnexoEmDiretorio(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns(true);
            _fixtures.Mocker.GetMock<IArquivoAdapter>().Setup(d => d.DeArquivoRegistadoParaArquivoModel(It.IsAny<ArquivoRegistrado>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.PersistirArquivo(It.IsAny<ArquivoModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroModificado>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "CriarArquivoHandler")]
        [Fact(DisplayName = "Retornar booleano true nenhum erro oorrer ao invocar handler")]
        public void AoInvocarHandler_QuandoNenhumErroOcorrer_DeveBooleanoTrue()
        {
            // Arrange
            var command = _fixtures.GerarCriarArquivoCommandValido();
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ExisteColaborador(It.IsAny<int>())).Returns(true);
            _fixtures.Mocker.GetMock<IAnexoFacade>().Setup(d => d.SalvarAnexoEmDiretorio(It.IsAny<IFormFile>(), It.IsAny<string>())).Returns(true);
            _fixtures.Mocker.GetMock<IArquivoAdapter>().Setup(d => d.DeArquivoRegistadoParaArquivoModel(It.IsAny<ArquivoRegistrado>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.PersistirArquivo(It.IsAny<ArquivoModel>())).Returns(true);

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
        }
    }
}
