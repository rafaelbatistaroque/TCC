using Paperless.Shared.Erros;

namespace Usuario.Fixtures
{
    public abstract class UsuarioFixtures
    {
        protected const string SENHA_BASE64_VALIDA = "Z2RmcjQ1";
        protected const string SENHA_VALIDA = "gdfr45";
        protected const string USUARIO_NOME_VALIDO = "Pedro João Tiago";
        protected const int USUARIO_PERFIL_ADM_VALIDO = 1;
        protected const string USUARIO_CODIGO_VALIDO = "ER90C";

        protected ErroBase ErroGenerico() => new ErroGenericoTestes();
    }
}
