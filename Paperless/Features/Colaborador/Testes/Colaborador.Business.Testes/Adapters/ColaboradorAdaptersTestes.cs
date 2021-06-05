using Colaborador.Business.Contracts;
using Colaborador.Business.Testes.Fixtures;
using Xunit;

namespace Colaborador.Business.Testes.Adapters
{
    public class ColaboradorAdaptersTestes
    {
        private readonly IColaboradorAdapters _sut;
        private readonly ColaboradorAdaptersFixtures _fixtures;

        public ColaboradorAdaptersTestes()
        {
            _fixtures = new ColaboradorAdaptersFixtures();
            _sut = _fixtures.GerarSUT();
        }

        [Trait("Colaborador.Business.Adapters", "ColaboradorAdaptersTestes")]
        [Fact(DisplayName = "Garantir mesmo conteúdo entre entidade ColaboradorEmpresa e ColaboradorModel")]
        public void AoInvocarHandle_QuandoCommandValido_GarantirQueInstanciaDeColaboradorEmpresaEhAMesmaAdaptadaemColaboradorModel()
        {
            // Arrange
            var colaborador = _fixtures.GerarColaboradorEmpresa();

            // Act
            var resultado = _sut.DeColaboradorParaColaboradorModel(colaborador);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(colaborador.ColaboradorCPF.NumeroCPF, resultado.ColaboradorCPF.NumeroCPF);
            Assert.Equal(colaborador.Funcao.FuncaoId, resultado.FuncaoId);
            Assert.Equal(colaborador.ColaboradorNome.NomeCompleto, resultado.Nome.NomeCompleto);
        }
    }
}
