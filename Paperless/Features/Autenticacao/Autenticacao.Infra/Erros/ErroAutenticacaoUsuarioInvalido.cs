using Paperless.Shared.Erros;

namespace Autenticacao.Infra.Erros
{
    public class ErroAutenticacaoUsuarioInvalido : ErroBase
    {
        public ErroAutenticacaoUsuarioInvalido(string mensagemErro) : base(mensagemErro)
        {
        }
    }
}
