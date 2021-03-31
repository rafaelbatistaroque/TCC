using Colaborador.Business.Adapter;
using Colaborador.Business.Models;
using Colaborador.Domain.Entidades;
using Moq.AutoMock;
using Paperless.Fixtures.Colaborador;
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
