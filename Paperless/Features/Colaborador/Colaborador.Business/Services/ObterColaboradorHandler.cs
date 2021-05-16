using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colaborador.Business.Services
{
    public class ObterColaboradorHandler : IObterColaborador
    {
        private readonly IColaboradorRepository _repositorio;
        private readonly IColaboradorAdapters _adapter;

        public ObterColaboradorHandler(IColaboradorRepository repositorio, IColaboradorAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, ColaboradorEmpresa> Handler(int id)
        {
            var respostaColaboradorExiste = _repositorio.ExisteColaborador(id);
            if(respostaColaboradorExiste.EhFalha)
                return respostaColaboradorExiste.Falha;

            if(respostaColaboradorExiste.Sucesso == false)
                return new ErroRegistroNaoEncontrado(ColaboradorTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var colaboradorModel = _repositorio.ObterColaborador(id); 
            if(colaboradorModel.EhFalha)
                return colaboradorModel.Falha;

            var colaborador = _adapter.DeColaboradorModelParaColaborador(colaboradorModel.Sucesso);

            return colaborador;
        }
    }
}
