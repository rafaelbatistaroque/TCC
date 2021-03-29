using Autenticacao.Business.Contracts;
using Autenticacao.Business.Erros;
using Autenticacao.Business.Models;
using Autenticacao.Business.Testes.Fixtures;
using Moq;
using Paperless.Shared.TextosInformativos;
using Xunit;

namespace Autenticacao.Business.Testes.Facades
{
    public class AutenticacaoFacadesTestes
    {
        private readonly AutenticacaoFacadesFixtures _fixtures;
        private readonly IAutenticacaoFacades _sut;

        public AutenticacaoFacadesTestes()
        {
            _fixtures = new AutenticacaoFacadesFixtures();
            _sut = _fixtures.GerarSUT();

        }

        [Trait("Autenticacao.Business.Facades", "AutenticacaoFacadesTestes")]
        [Fact(DisplayName = "Retorna erro quando usuário não encontrado ou erro na conexão com base de dados")]
        public void AoInvocarObterUsuarioFacades_QuandoUsuarioNaoEncontradoOuErroNaConexao_DeveRetornaErroEspecifico()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.UsuarioExiste(It.IsAny<string>())).Returns(false);
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.UsuarioExiste(It.IsAny<string>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.ObterUsuarioFacades(It.IsAny<string>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.Equal(AutenticacaoTextosInformativos.USUARIO_NAO_ENCONTRADO, resultado.Falha.MensagensErro[0]);
            Assert.IsType<ErroAutenticacaoUsuario>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Facades", "AutenticacaoFacadesTestes")]
        [Fact(DisplayName = "Retorna erro proveniente ao buscar usuário na base de dados.")]
        public void AoInvocarObterUsuarioFacades_QuandoErroAoBuscarUsuarioNaBaseDeDados_DeveRetornaErroProveniente()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.UsuarioExiste(It.IsAny<string>())).Returns(true);
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarErroGenerico());

            // Act
            var resultado = _sut.ObterUsuarioFacades(It.IsAny<string>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsType<ErroAutenticacaoUsuario>(resultado.Falha);
        }

        [Trait("Autenticacao.Business.Facades", "AutenticacaoFacadesTestes")]
        [Fact(DisplayName = "Retorna sucesso ao obter usuário proveniente da base de dados")]
        public void AoInvocarObterUsuarioFacades_QuandoUsuarioEncontradoNaBaseDeDados_DeveRetornarUsuarioEncontrado()
        {
            // Arrange
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.UsuarioExiste(It.IsAny<string>())).Returns(true);
            _fixtures.Mocker.GetMock<IAutenticacaoRepository>().Setup(r => r.ObterUsuario(It.IsAny<string>())).Returns(_fixtures.GerarUsuarioModel());

            // Act
            var resultado = _sut.ObterUsuarioFacades(It.IsAny<string>());

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhSucesso);
            Assert.IsType<UsuarioDoSistemaModel>(resultado.Sucesso);
        }
    }
}
