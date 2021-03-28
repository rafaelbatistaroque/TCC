using Paperless.Shared.Erros;

namespace Paperless.Fixtures.Colaborador
{
    public abstract class ColaboradorFixtures
    {
        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
