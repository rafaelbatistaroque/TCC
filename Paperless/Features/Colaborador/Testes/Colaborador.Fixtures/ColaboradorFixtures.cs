using Paperless.Shared.Erros;

namespace Colaborador.Fixtures
{
    public abstract class ColaboradorFixtures
    {
        protected const string COLABORADOR_PRIMEIRO_NOME = "Pedro";
        protected const string COLABORADOR_SOBRENOME = "João Tiago";
        protected const string COLABORADOR_CPF = "123.456.789-10";
        protected const int COLABORADOR_ID_INVALIDO = 0;
        protected const int COLABORADOR_ID_VALIDO = 2;
        protected const string COLABORADOR_PRIMEIRO_NOME_ALTERAR = "João";
        protected const string COLABORADOR_SOBRENOME_ALTERAR = "Crisóstomo";
        protected const int COLABORADOR_ID_VALIDO_ALTERAR = 2;

        protected ErroBase ErroGenerico() => new ErroGenericoTestes();
    }
}
