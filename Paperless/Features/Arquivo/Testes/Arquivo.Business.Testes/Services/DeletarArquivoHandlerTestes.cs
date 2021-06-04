using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Business.Services;
using Arquivo.Business.Testes.Fixtures;
using Arquivo.Domain.CasosDeUso.DeletarArquivo;
using Moq;
using Paperless.Shared.Erros;
using Xunit;

namespace Arquivo.Business.Testes.Services
{
    public class DeletarArquivoHandlerTestes : IClassFixture<ArquivoServicesFixtures>
    {
        private readonly ArquivoServicesFixtures _fixtures;
        private readonly IDeletarArquivo _sut;

        public DeletarArquivoHandlerTestes(ArquivoServicesFixtures fixture)
        {
            _fixtures = fixture;
            _sut = _fixtures.CriarSUT<DeletarArquivoHandler>();
        }


        [Trait("Arquivo.Business.Services", "DeletarArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se arquivo não existir")]
        public void AoInvocarHandler_QuandoArquivoNaoExistir_DeveRetornarErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ObterArquivo(It.IsAny<int>())).Returns((ArquivoModel)null);

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroRegistroNaoEncontrado>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "DeletarArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar erro se nenhum registro modificado ao deletar arquivo")]
        public void AoInvocarHandler_QuandoNenhumRegistroModificado_DeveRetornarNenhumRegistroModificado()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.ObterArquivo(It.IsAny<int>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IArquivoRepository>().Setup(r => r.DeletarArquivo(It.IsAny<ArquivoModel>())).Returns(false);

            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroNenhumRegistroModificado>(resultado.Falha);
        }

        [Trait("Arquivo.Business.Services", "DeletarArquivoHandlerTestes")]
        [Fact(DisplayName = "Retornar booleano true após deletar arquivo na base de dados")]
        public void AoInvocarHandler_QuandoNaoOcorrerErroAoDeletarArquivo_DeveRetornarBooleanoTrue()
        {
            // Arrange
            var sequencia = new MockSequence();
            _fixtures.Mocker.GetMock<IArquivoRepository>().InSequence(sequencia).Setup(r => r.ObterArquivo(It.IsAny<int>())).Returns(_fixtures.GerarArquivoModel());
            _fixtures.Mocker.GetMock<IArquivoRepository>().InSequence(sequencia).Setup(r => r.DeletarArquivo(It.IsAny<ArquivoModel>())).Returns(true);
            _fixtures.Mocker.GetMock<IDiretorioServico>().Setup(x => x.DeletarArquivoEmDiretorio(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
            // Act
            var resultado = _sut.Handler(It.IsAny<int>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<bool>(resultado.Sucesso);
            _fixtures.Mocker.GetMock<IDiretorioServico>().Verify(x => x.DeletarArquivoEmDiretorio(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once, "Método não invocado");
        }
    }
}
