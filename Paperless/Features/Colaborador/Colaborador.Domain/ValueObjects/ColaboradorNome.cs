namespace Colaborador.Domain.ValueObjects
{
    public sealed class ColaboradorNome
    {
        public string PrimeiroNome { get; }
        public string Sobrenome { get; }
        public string NomeCompleto => ObterNomeCompleto();

        private ColaboradorNome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        public static ColaboradorNome Criar(string primeiroNome, string sobrenome)
        {
            return new ColaboradorNome(primeiroNome, sobrenome);
        }

        public string ObterNomeCompleto()
        {
            return $"{PrimeiroNome} {Sobrenome}";
        }
    }
}
