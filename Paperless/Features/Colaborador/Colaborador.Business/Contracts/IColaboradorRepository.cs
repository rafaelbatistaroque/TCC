using Colaborador.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Collections.Generic;

namespace Colaborador.Business.Contracts
{
    public interface IColaboradorRepository
    {
        Either<ErroBase, bool> CriarColaborador(ColaboradorModel colaborador);
        Either<ErroBase, IReadOnlyCollection<ColaboradorModel>> ObterColaboradores();
        Either<ErroBase, ColaboradorModel> ObterColaborador(int id);
        Either<ErroBase, bool> ExisteColaborador(int id);
        Either<ErroBase, bool> DeletarColaborador(ColaboradorModel colaborador);
        Either<ErroBase, bool> AlterarColaborador(ColaboradorModel colaborador);
    }
}
