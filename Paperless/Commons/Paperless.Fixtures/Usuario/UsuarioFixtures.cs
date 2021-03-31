using Paperless.Shared.Erros;

namespace Paperless.Fixtures.Usuario
{
    public abstract class UsuarioFixtures
    {
        protected const string SENHA_BASE64_VALIDA = "Z2RmcjQ1";
        protected const string SENHA_VALIDA = "gdfr45";
        protected const string USUARIO_NOME_VALIDO = "Pedro João Tiago";
        protected const int USUARIO_PERFIL_ADM_VALIDO = 1;

        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
