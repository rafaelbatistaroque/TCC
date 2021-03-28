using Paperless.Shared.Erros;

namespace Usuario.Infra.Erros
{
    public class ErroComunicacaoBancoDeDados : ErroBase
    {
        public ErroComunicacaoBancoDeDados(string mensagemErro) : base(mensagemErro)
        {
        }
    }
}
