using Paperless.Shared.Erros;

namespace Paperless.Fixtures.Colaborador
{
    public abstract class ColaboradorFixtures
    {
        protected const string COLABORADOR_PRIMEIRO_NOME = "Pedro";
        protected const string COLABORADOR_SOBRENOME = "João Tiago";
        protected const string COLABORADOR_CPF = "123.456.789-10";

        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
