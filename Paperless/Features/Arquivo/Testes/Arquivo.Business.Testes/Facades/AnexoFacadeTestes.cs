using Arquivo.Business.Contracts;
using Arquivo.Business.Facades;
using Arquivo.Business.Testes.Fixtures;
using Xunit;

namespace Arquivo.Business.Testes.Facades
{
    public class AnexoFacadeTestes : IClassFixture<ArquivoFacadesFixtures>
    {
        private readonly ArquivoFacadesFixtures _fixtures;
        private readonly IAnexoFacade _sut;

        public AnexoFacadeTestes(ArquivoFacadesFixtures fixture)
        {
            _fixtures = fixture;
            _sut = _fixtures.CriarSUT<AnexoFacade>();
        }
    }
}
