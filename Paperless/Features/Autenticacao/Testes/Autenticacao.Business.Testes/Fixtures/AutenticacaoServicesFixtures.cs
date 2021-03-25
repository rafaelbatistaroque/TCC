using Autenticacao.Business.Services;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Moq.AutoMock;
using Paperless.Shared.Erros;
using Paperless.Shared.Fixtures;

namespace Autenticacao.Business.Testes.Fixtures
{
    public class AutenticacaoServicesFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get;}
        public AutenticacaoServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticarUsuarioHandler GerarSUT()
            => Mocker.CreateInstance<AutenticarUsuarioHandler>();

        public AutenticarUsuarioCommand GerarCommand(int usuarioIdentificador, string senha)
            => new AutenticarUsuarioCommand() { UsuarioIdentificador = usuarioIdentificador, Senha=senha};

        public ErroBase GerarErrogenerico() => ErroGenerico();
    }
}
