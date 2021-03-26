using Colaborador.Domain.CasosDeUso.AdicionarColaborador;
using Moq.AutoMock;
using Paperless.Shared.Erros;
using Paperless.Shared.Fixtures;

namespace Colaborador.Business.Testes.Fixtures
{
    public class ColaboradorServicesFixtures : ColaboradorFixtures
    {
        public AutoMocker Mocker { get; }
        public ColaboradorServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public T GerarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        public AdicionarColaboradorCommand GerarAdicionarColaboradorCommand(string colaboradorNome, string colaboradorCpf, string colaboradorFuncaoEmpresa)
            => new AdicionarColaboradorCommand() { ColaboradorNome = colaboradorNome, ColaboradorCPF = colaboradorCpf, ColaboradorFuncaoEmpresa = colaboradorFuncaoEmpresa };

        public ErroBase GerarErrogenerico() => ErroGenerico();
    }
}
