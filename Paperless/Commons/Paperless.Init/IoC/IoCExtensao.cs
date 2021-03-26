using Autenticacao.Infra.Contracts;
using Autenticacao.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Paperless.Init.IoC
{
    public static class IoCExtensao
    {
        public static void AdicionarIoCPaperless(this IServiceCollection servico, IConfiguration config)
        {
            servico.AdicionarAutenticacaoIoC(config);
        }

        public static void AdicionarAutenticacaoIoC(this IServiceCollection servico, IConfiguration config)
        {
            servico.AddDbContext<AutenticacaoContext>(o => o.UseSqlServer(config.GetConnectionString("conn_TCC")));
            servico.AddScoped<IAutenticacaoContext, AutenticacaoContext>();
        }
    }
}
