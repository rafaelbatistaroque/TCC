using Autenticacao.Domain.Entidades;
using Paperless.Shared.Erros;

namespace Paperless.Init.Fixtures
{
    public abstract class AutenticacaoFixtures
    {
        protected const string SENHA_VALIDA = "12.adD";
        protected const string FAKE_TOKEN = "AASDFASDFASDFADSF.ASDFASDFASDF.ASDFASDFASDFSADF";
        protected const int USUARIO_IDENTIFICADOR_VALIDO = 2158;
        protected const string USUARIO_NOME_VALIDO = "Pedro João Tiago";
        protected const string USUARIO_PERFIL_VALIDO = "Administrador";
        protected const string USUARIO_SENHA_VALIDO = "123456";
        protected const bool USUARIO_ATIVO_VALIDO = true;
        protected const bool USUARIO_INATIVO_VALIDO = false;

        protected ErroBase ErroGenerico() => new ErroGenericoTestes("Erro generico gerado");
    }
}
