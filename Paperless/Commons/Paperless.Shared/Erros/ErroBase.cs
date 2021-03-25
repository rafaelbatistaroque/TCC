namespace Paperless.Shared.Erros
{
    public abstract class ErroBase
    {
        public string[] MensagensErro { get; }

        public ErroBase(string mensagemErro)
        {
            MensagensErro ??= new string[] { mensagemErro };
        }

        public ErroBase(string[] mensagensErro)
        {
            MensagensErro = mensagensErro;
        }
    }
}
