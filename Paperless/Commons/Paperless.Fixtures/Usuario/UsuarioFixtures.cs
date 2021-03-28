using Paperless.Shared.Erros;

namespace Paperless.Fixtures.Usuario
{
    public abstract class UsuarioFixtures
    {
        protected const string SENHA_VALIDA = "12.adD";
        protected const string USUARIO_NOME_VALIDO = "Pedro João Tiago";
        protected const int USUARIO_PERFIL_ADM_VALIDO = 1;

        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
