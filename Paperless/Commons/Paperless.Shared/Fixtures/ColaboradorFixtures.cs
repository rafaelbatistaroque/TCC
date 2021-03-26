using Paperless.Shared.Erros;

namespace Paperless.Shared.Fixtures
{
    public abstract class ColaboradorFixtures
    {
        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
