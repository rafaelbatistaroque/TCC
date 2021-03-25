using Autenticacao.Business.Testes.Fixtures;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Paperless.Shared.Erros;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Autenticacao.Business.Testes.Services
{
    public class AutenticarUsuarioHandlerTestes
    {
        private readonly AutenticacaoServicesFixtures _fixtures;
        private readonly IAutenticarUsuario _sut;

        public AutenticarUsuarioHandlerTestes()
        {
            _fixtures = new AutenticacaoServicesFixtures();
            _sut = _fixtures.GerarSUT();

        }

        [Trait("Autenticacao.business.Services", "AutenticarUsuarioHandlerTestes")]
        [Theory(DisplayName = "Lista de erro caso command inválido")]
        [InlineData(-1,"")]
        [InlineData(0," ")]
        [InlineData(22, null)]
        [InlineData(333,"drop")]
        [InlineData(4444,"or 1=1")]
        public void AoInvocarHandler_QuandoCommandInvalido_DeveRetornaListaDeErrosEspecificos(int usuarioIdentificador, string senha)
        {
            // Arrange
            var commandInvalido = _fixtures.GerarCommand(usuarioIdentificador, senha);

            // Act
            var resultado = _sut.Handler(commandInvalido);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.EhFalha);
            Assert.IsAssignableFrom<ErroBase>(resultado.Falha);
        }
    }
}
