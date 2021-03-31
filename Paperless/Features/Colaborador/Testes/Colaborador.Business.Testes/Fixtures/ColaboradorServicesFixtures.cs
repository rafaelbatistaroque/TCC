using Colaborador.Business.Models;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.Entidades;
using Colaborador.Domain.ValueObjects;
using Moq.AutoMock;
using Paperless.Fixtures.Colaborador;
using Paperless.Shared.Enums;
using Paperless.Shared.Erros;

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

        public ColaboradorNome GerarColaboradorNome()
            => ColaboradorNome.Criar(COLABORADOR_PRIMEIRO_NOME, COLABORADOR_SOBRENOME);

        public ColaboradorCPF GerarColaboradorCPF()
            => ColaboradorCPF.Criar(COLABORADOR_CPF);


        public ColaboradorFuncao GerarColaboradorFuncao()
            => ColaboradorFuncao.Criar((int)EColaboradorFuncao.PROGRAMADOR);

        public ColaboradorEmpresa GerarColaboradorEmpresa()
         => ColaboradorEmpresa.Criar(COLABORADOR_PRIMEIRO_NOME, COLABORADOR_SOBRENOME, COLABORADOR_CPF, (int)EColaboradorFuncao.PROGRAMADOR);

        public ColaboradorModel GerarColaboradoModel()
        {
            var c = GerarColaboradorEmpresa();
            return new ColaboradorModel()
            {
                ColaboradorCPF = c.ColaboradorCPF,
                Funcao = c.Funcao,
                Nome = c.ColaboradorNome
            };

        }

        public CriarColaboradorCommand GerarCriarColaboradorCommand(string primeiroNome, string sobrenome, string colaboradorCpf, int colaboradorFuncaoEmpresa)
            => new CriarColaboradorCommand() { ColaboradorPrimeiroNome = primeiroNome, ColaboradorSobrenome = sobrenome,  ColaboradorCPF = colaboradorCpf, ColaboradorFuncaoEmpresa = colaboradorFuncaoEmpresa };

        public CriarColaboradorCommand GerarCriarColaboradorCommand()
          => new CriarColaboradorCommand() { ColaboradorPrimeiroNome = COLABORADOR_PRIMEIRO_NOME, ColaboradorSobrenome = COLABORADOR_SOBRENOME, ColaboradorCPF = COLABORADOR_CPF, ColaboradorFuncaoEmpresa = (int)EColaboradorFuncao.PROGRAMADOR };

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
