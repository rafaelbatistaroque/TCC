using Autenticacao.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Paperless.Init.IoC
{
    public static class IoCExtensao
    {
        public static void AdicionarIoCPaperless(this IServiceCollection servico, IConfiguration _config)
        {
            servico.AddDbContext<AutenticacaoContext>(o => o.UseSqlServer(_config.GetConnectionString("connTCC")));
            servico.AdicionarAutenticacaoIoC();
        }

        public static void AdicionarAutenticacaoIoC(this IServiceCollection servico)
        {
            servico.AddScoped<AutenticacaoContext, AutenticacaoContext>();
        }
    }
}
