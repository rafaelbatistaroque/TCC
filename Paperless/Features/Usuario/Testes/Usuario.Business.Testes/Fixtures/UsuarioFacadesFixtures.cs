using Moq.AutoMock;
using Paperless.Fixtures.Usuario;
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

        public T GerarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        public Perfil GerarPerfilADM() => Perfil.CriarPerfilUsuario();

        public string GerarSenhaValida() => SENHA_VALIDA;
    }
}
