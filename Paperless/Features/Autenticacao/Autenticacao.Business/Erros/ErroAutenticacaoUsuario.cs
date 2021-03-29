using Paperless.Shared.Erros;

namespace Autenticacao.Business.Erros
{
    public class ErroAutenticacaoUsuario : ErroBase
    {
        public ErroAutenticacaoUsuario(string mensagemErro) : base(mensagemErro)
        {
        }
    }
}
