using Arquivo.Fixtures;
using Moq.AutoMock;

namespace Arquivo.Business.Testes.Fixtures
{
    public class ArquivoFacadesFixtures : ArquivoFixtures
    {
        public AutoMocker Mocker { get; }

        public ArquivoFacadesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public T CriarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();
    }
}
