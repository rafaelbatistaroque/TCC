using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.ObterColaboradores;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Colaborador.Business.Services
{
    public class ObterColaboradoresHandler : IObterColaboradores
    {
        private readonly IColaboradorRepository _repositorio;
        private readonly IColaboradorAdapters _adapter;

        public ObterColaboradoresHandler(IColaboradorRepository repositorio, IColaboradorAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, IReadOnlyCollection<ColaboradorEmpresa>> Handler()
        {
            var colaboradoresModel = _repositorio.ObterColaboradores();
            var colaboradores = _adapter.DeListaColaboradorModelParaListaColaboradorEmpresa(colaboradoresModel);

            return colaboradores.ToList();
        }
    }
}
