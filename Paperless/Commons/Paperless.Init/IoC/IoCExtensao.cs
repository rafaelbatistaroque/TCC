using Arquivo.Business.Adapters;
using Arquivo.Business.Contracts;
using Arquivo.Business.Facades;
using Arquivo.Business.Services;
using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.CasosDeUso.ObterArquivos;
using Arquivo.Infra.EF;
using Arquivo.Infra.Repositorios;
using Autenticacao.Business.Contracts;
using Autenticacao.Business.Services;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Infra.EF;
using Autenticacao.Infra.Repositorios;
using Autenticacao.Infra.TokenServico;
using Colaborador.Business.Adapter;
using Colaborador.Business.Contracts;
using Colaborador.Business.Services;
using Colaborador.Domain.CasosDeUso.AlterarColaborador;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.CasosDeUso.DeletarColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaboradores;
using Colaborador.Infra.EF;
using Colaborador.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Business.Adapters;
using Usuario.Business.Contracts;
using Usuario.Business.Services;
using Usuario.Domain.CasosDeUso.AlterarStatusUsuario;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Domain.CasosDeUso.ObterUsuarios;
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
            servico.AddDbContext<ArquivoContext>(ObterStringConexaoSQL);
            servico.AdicionarAutenticacaoIoC();
            servico.AdicionarUsuarioIoC();
            servico.AdicionarColaboradorIoC();
            servico.AdicionarArquivoIoC();
        }

        public static void AdicionarAutenticacaoIoC(this IServiceCollection servico)
        {
            servico.AddScoped<AutenticacaoContext>();
            servico.AddScoped<IAutenticarUsuario, AutenticarUsuarioHandler>();
            servico.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();
            servico.AddScoped<IJWT, JWTServico>();
        }

        public static void AdicionarUsuarioIoC(this IServiceCollection servico)
        {
            servico.AddScoped<UsuarioContext>();
            servico.AddScoped<ICriarUsuario, CriarUsuarioHandler>();
            servico.AddScoped<IObterUsuarios, ObterUsuariosHandler>();
            servico.AddScoped<IAlterarStatusUsuario, AlterarStatusUsuarioHandler>();
            servico.AddScoped<IUsuarioRepository, UsuarioRepository>();
            servico.AddScoped<IUsuarioAdapters, UsuarioAdapters>();
        }

        public static void AdicionarColaboradorIoC(this IServiceCollection servico)
        {
            servico.AddScoped<ColaboradorContext>();
            servico.AddScoped<ICriarColaborador, CriarColaboradorHandler>();
            servico.AddScoped<IObterColaboradores, ObterColaboradoresHandler>();
            servico.AddScoped<IObterColaborador, ObterColaboradorHandler>();
            servico.AddScoped<IDeletarColaborador, DeletarColaboradorHandler>();
            servico.AddScoped<IAlterarColaborador, AlterarColaboradorHandler>();
            servico.AddScoped<IColaboradorAdapters, ColaboradorAdapters>();
            servico.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }

        public static void AdicionarArquivoIoC(this IServiceCollection servico)
        {
            servico.AddScoped<ArquivoContext>();
            servico.AddScoped<ICriarArquivo, CriarArquivoHandler>();
            servico.AddScoped<IObterArquivosDeColaborador, ObterArquivosDeColaboradorHandler>();
            servico.AddScoped<IArquivoRepository, ArquivoRepository>();
            servico.AddScoped<IAnexoFacade, AnexoFacade>();
            servico.AddScoped<IArquivoAdapter, ArquivoAdapter>();
        }
    }
}
