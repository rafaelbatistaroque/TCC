using Autenticacao.Business.Contracts;
using Autenticacao.Business.Facades;
using Autenticacao.Business.Services;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Infra.EF;
using Autenticacao.Infra.Repositorios;
using Autenticacao.Infra.TokenServico;
using Colaborador.Business.Adapter;
using Colaborador.Business.Contracts;
using Colaborador.Business.Services;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Infra.EF;
using Colaborador.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Business.Adapters;
using Usuario.Business.Contracts;
using Usuario.Business.Facades;
using Usuario.Business.Services;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Infra.EF;
using Usuario.Infra.Repositorios;

namespace Paperless.Init.IoC
{
    public static class IoCExtensao
    {
        public static void AdicionarIoCPaperless(this IServiceCollection servico, IConfiguration _config)
        {
            void ObterStringConexaoSQL(DbContextOptionsBuilder o) => o.UseSqlServer(_config.GetConnectionString("connTCC"));
            servico.AddDbContext<AutenticacaoContext>(ObterStringConexaoSQL);
            servico.AddDbContext<UsuarioContext>(ObterStringConexaoSQL);
            servico.AddDbContext<ColaboradorContext>(ObterStringConexaoSQL);
            servico.AdicionarAutenticacaoIoC();
            servico.AdicionarUsuarioIoC();
            servico.AdicionarColaboradorIoC();
        }

        public static void AdicionarAutenticacaoIoC(this IServiceCollection servico)
        {
            servico.AddScoped<AutenticacaoContext>();
            servico.AddScoped<IAutenticarUsuario, AutenticarUsuarioHandler>();
            servico.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();
            servico.AddScoped<IJWT, JWTServico>();
            servico.AddScoped<IAutenticacaoFacades, AutenticacaoFacades>();
        }

        public static void AdicionarUsuarioIoC(this IServiceCollection servico)
        {
            servico.AddScoped<UsuarioContext>();
            servico.AddScoped<ICriarUsuario, CriarUsuarioHandler>();
            servico.AddScoped<IUsuarioRepository, UsuarioRepository>();
            servico.AddScoped<IUsuarioAdapters, UsuarioAdapters>();
            servico.AddScoped<IUsuarioFacades, UsuarioFacades>();
        }

        public static void AdicionarColaboradorIoC(this IServiceCollection servico)
        {
            servico.AddScoped<ColaboradorContext>();
            servico.AddScoped<ICriarColaborador, CriarColaboradorHandler>();
            servico.AddScoped<IColaboradorAdapters, ColaboradorAdapters>();
            servico.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }
    }
}
