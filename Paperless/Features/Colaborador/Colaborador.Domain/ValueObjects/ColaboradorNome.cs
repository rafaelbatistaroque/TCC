namespace Colaborador.Domain.ValueObjects
{
    public sealed class ColaboradorNome
    {
        public string PrimeiroNome { get; }
        public string Sobrenome { get; }
        public string NomeCompleto { get; }

        private ColaboradorNome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        private ColaboradorNome(string primeiroNome, string sobrenome) : this(ObterNomeCompleto(primeiroNome, sobrenome))
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        public static ColaboradorNome Criar(string primeiroNome, string sobrenome)
        {
            return new ColaboradorNome(primeiroNome, sobrenome);
        }

        public static ColaboradorNome Retornar(string nomeCompleto)
        {
            return new ColaboradorNome(nomeCompleto);
        }

        private static string ObterNomeCompleto(string primeiroNome, string sobrenome)
        {
            return $"{primeiroNome} {sobrenome}";
        }
    }
}
