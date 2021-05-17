using Moq.AutoMock;
using Usuario.Fixtures;
using Paperless.Shared.Erros;
using System.Collections.Generic;
using Usuario.Business.Models;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Domain.Entidades;
using Usuario.Domain.CasosDeUso.AlterarStatusUsuario;

namespace Usuario.Business.Testes.Fixtures
{
    public class UsuarioServicesFixtures : UsuarioFixtures
    {
        public AutoMocker Mocker { get; }
        public UsuarioServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public T GerarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        public CriarUsuarioCommand GerarCriarUsuarioCommandInvalido(string usuarioNome, string usuarioSenha, int usuarioPerfil)
            => new CriarUsuarioCommand() { UsuarioNome = usuarioNome, UsuarioSenha = usuarioSenha, UsuarioPerfil = usuarioPerfil };

        public CriarUsuarioCommand GerarCriarUsuarioCommandValido()
           => new CriarUsuarioCommand() { UsuarioNome = USUARIO_NOME_VALIDO, UsuarioSenha = SENHA_VALIDA, UsuarioPerfil = USUARIO_PERFIL_ADM_VALIDO };

        public UsuarioDoSistema GerarUsuarioDoSistema()
            => UsuarioDoSistema.Criar(USUARIO_NOME_VALIDO, SENHA_VALIDA, USUARIO_PERFIL_ADM_VALIDO);

        public AlterarStatusUsuarioCommand GerarAlterarStatusUsuarioCommandInvalido(string codigo)
         => new AlterarStatusUsuarioCommand() { UsuarioCodigo = codigo};

        public AlterarStatusUsuarioCommand GerarAlterarStatusUsuarioCommandValido()
            => new AlterarStatusUsuarioCommand() { UsuarioCodigo = USUARIO_CODIGO_VALIDO };

        public UsuarioDoSistemaModel GerarUsuarioDoSistemaModel()
        {
            var u = GerarUsuarioDoSistema();
            return new UsuarioDoSistemaModel()
            {
                EhUsuarioAtivo = u.EhUsuarioAtivo,
                UsuarioIdentificacao = u.UsuarioIdentificacao,
                UsuarioNome = u.UsuarioNome,
                UsuarioPerfil = u.UsuarioPerfil,
                UsuarioSenha = u.UsuarioSenha
            };
        }

        public List<UsuarioDoSistemaModel> GerarListaUsuarioDoSistemaModel()
            => new List<UsuarioDoSistemaModel>() { GerarUsuarioDoSistemaModel() };

        public List<UsuarioDoSistema> GerarListaGerarUsuarioDoSistema()
            => new List<UsuarioDoSistema>() { GerarUsuarioDoSistema() };

        public string GerarSenhaBase64() => SENHA_BASE64_VALIDA;
     
        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
