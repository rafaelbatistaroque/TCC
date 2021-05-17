using Colaborador.Business.Adapter;
using Colaborador.Domain.Entidades;
using Colaborador.Fixtures;
using Moq.AutoMock;
using Paperless.Shared.Enums;

namespace Colaborador.Business.Testes.Fixtures
{
    public class ColaboradorAdaptersFixtures : ColaboradorFixtures
    {
        public AutoMocker Mocker { get; }

        public ColaboradorAdaptersFixtures()
        {
            Mocker = new AutoMocker();
        }

        public ColaboradorAdapters GerarSUT()
            => Mocker.CreateInstance<ColaboradorAdapters>();

        public ColaboradorEmpresa GerarColaboradorEmpresa()
         => ColaboradorEmpresa.Criar(COLABORADOR_PRIMEIRO_NOME, COLABORADOR_SOBRENOME, COLABORADOR_CPF, (int)EColaboradorFuncao.PROGRAMADOR);
    }
}
