using Paperless.Shared.Erros;

namespace Paperless.Shared.Fixtures
{
    public abstract class AutenticacaoFixtures
    {
        protected const string SENHA_VALIDA = "12.adD";
        protected const int USUARIO_IDENTIFICADOR_VALIDO = 2158;

        protected ErroBase ErroGenerico() => new GradeErroGenerico("Erro generico gerado");
    }

    public class GradeErroGenerico : ErroBase
    {
        public GradeErroGenerico(string mensagem = null) : base(mensagem) { }
    }
}
