namespace Autenticacao.Business.Contracts
{
    public interface IJWT
    {
        string GerarToken(string identificador, string perfil);
    }
}
