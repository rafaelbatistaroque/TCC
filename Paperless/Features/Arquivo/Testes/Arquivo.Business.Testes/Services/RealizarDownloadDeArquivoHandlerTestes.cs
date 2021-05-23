using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Business.Services;
using Arquivo.Business.Testes.Fixtures;
using Arquivo.Domain.CasosDeUso.DownloadArquivo;
using Arquivo.Domain.Entidades;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Arquivo.Business.Testes.Services
{
    public class RealizarDownloadDeArquivoHandlerTestes : IClassFixture<ArquivoServicesFixtures>
    {
        private readonly ArquivoServicesFixtures _fixtures;
        private readonly IRealizarDownloadDeArquivo _sut;

        public RealizarDownloadDeArquivoHandlerTestes(ArquivoServicesFixtures fixture)
        {
            _fixtures = fixture;
            _sut = _fixtures.CriarSUT<RealizarDownloadDeArquivoHandler>();
        }

        [Trait("Arquivo.Business.Services", "RealizarDownloadDeArquivoHandlerTestes")]
        [Theory(DisplayName = "Command Inválido")]
        [InlineData(0, "")]
        [InlineData(-1, " ")]
        [InlineData(0, null)]
        [InlineData(-1, "drop")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornarErrosDeValidacao(int id, string arquivoCodigo)
        {
            // Arrange
            var command = _fixtures.GerarRealizarDownloadArquivoCommandInvalido(id, arquivoCodigo);

            // Act
            var resultado = _sut.Handler(command);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroValidacaoCommandQuery>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "RealizarDownloadDeArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar erro caso não exista arquivo regitrado")]
        public void AoInvocarHandler_QuandoNaoExistirRegistroDeArquivo_DeveRetornarErro()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(x => x.ObterArquivo(It.IsAny<int>(), It.IsAny<string>())).Returns((ArquivoModel)null);

            // Act
            var resultado = _sut.Handler(_fixtures.GerarRealizarDownloadArquivoCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "RealizarDownloadDeArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar erro caso não exista arquivo no diretorio")]
        public void AoInvocarHandler_QuandoErroAoObterArquivoNoDiretorio_DeveRetornarErroProveniente()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(x => x.ObterArquivo(It.IsAny<int>(), It.IsAny<string>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IDiretorioServico>().Setup(x => x.ObterArquivoEmDiretorio(It.IsAny<string>(), It.IsAny<string>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.Handler(_fixtures.GerarRealizarDownloadArquivoCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "RealizarDownloadDeArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar arquivo em byte[] caso encontrado em diretório")]
        public void AoInvocarHandler_QuandoEncontradoEmDiretorio_DeveRetornarEmArrayDeByte()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(x => x.ObterArquivo(It.IsAny<int>(), It.IsAny<string>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IDiretorioServico>().Setup(x => x.ObterArquivoEmDiretorio(It.IsAny<string>(), It.IsAny<string>())).Returns(_fixtures.GerarArquivoEmByteFake());

            // Act
            var resultado = _sut.Handler(_fixtures.GerarRealizarDownloadArquivoCommandValido());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<ArquivoDownload>(resultado.Sucesso);
        }
    }
}
