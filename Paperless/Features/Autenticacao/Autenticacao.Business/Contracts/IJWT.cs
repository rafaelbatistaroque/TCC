namespace Autenticacao.Business.Contracts
{
    public interface IJWT
    {
        string GerarToken(int identificador, string perfil);
    }
}
