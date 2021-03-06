using Paperless.Shared.Erros;

namespace Autenticacao.Fixtures
{
    public abstract class AutenticacaoFixtures
    {
        protected const string SENHA_BASE64_VALIDA = "Z2RmcjQ1";
        protected const string SENHA_VALIDA = "gdfr45";
        protected const string FAKE_TOKEN = "AASDFASDFASDFADSF.ASDFASDFASDF.ASDFASDFASDFSADF";
        protected const string USUARIO_IDENTIFICADOR_VALIDO = "D57FI";
        protected const string USUARIO_NOME_VALIDO = "Pedro João Tiago";
        protected const string USUARIO_PERFIL_VALIDO = "Administrador";
        protected const int USUARIO_PERFIL_ID_ADM = 1;
        protected const string USUARIO_SENHA_VALIDO = "123456";
        protected const bool USUARIO_ATIVO_VALIDO = true;
        protected const bool USUARIO_INATIVO_VALIDO = false;

        protected ErroBase ErroGenerico() => new ErroGenericoTestes();
    }
}
