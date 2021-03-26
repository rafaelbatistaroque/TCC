using Autenticacao.Business.Models;
using Autenticacao.Infra.Repositorios;
using Moq.AutoMock;
using Paperless.Init.Fixtures;
using Paperless.Shared.Erros;

namespace Autenticacao.Infra.Testes.Fixtures
{
    public class AutenticacaoRepositoriosFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get; }

        public AutenticacaoRepositoriosFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticacaoRepository GerarSUT()
            => Mocker.CreateInstance<AutenticacaoRepository>();

        public UsuarioModel GerarUsuarioModel()
         => new UsuarioModel()
         {
             NomeUsuario = USUARIO_NOME_VALIDO,
             Senha = SENHA_VALIDA,
             UsuarioIdentificador = USUARIO_IDENTIFICADOR_VALIDO,
             EhUsuarioAtivo = USUARIO_ATIVO_VALIDO,
             Perfil = USUARIO_PERFIL_VALIDO
         };

        public ErroBase GerarErrogenerico() => ErroGenerico();
    }
}
