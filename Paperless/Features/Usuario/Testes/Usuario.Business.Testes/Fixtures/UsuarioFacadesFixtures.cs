using Moq.AutoMock;
using Paperless.Fixtures.Usuario;
using Usuario.Business.Models;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Testes.Fixtures
{
    public class UsuarioFacadesFixtures : UsuarioFixtures
    {
        public AutoMocker Mocker { get; }

        public UsuarioFacadesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public UsuarioDoSistema GerarUsuarioDoSistema()
            => UsuarioDoSistema.Criar(USUARIO_NOME_VALIDO, SENHA_VALIDA, USUARIO_PERFIL_ADM_VALIDO);

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

        public string GerarNomeValido() => USUARIO_NOME_VALIDO;
        public string GerarSenhaValida() => SENHA_VALIDA;
        public int GerarPerfilAdmIdValido() => USUARIO_PERFIL_ADM_VALIDO;

        public string GerarSenhaBase64() => SENHA_BASE64_VALIDA;

        public T GerarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        //public string GerarPerfilAdmValido() => ;
    }
}
