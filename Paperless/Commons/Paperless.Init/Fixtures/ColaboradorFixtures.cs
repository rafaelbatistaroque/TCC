using Paperless.Shared.Erros;

namespace Paperless.Init.Fixtures
{
    public abstract class ColaboradorFixtures
    {
        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
