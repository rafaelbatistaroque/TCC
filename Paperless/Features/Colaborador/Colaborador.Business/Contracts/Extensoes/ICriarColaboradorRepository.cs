using Colaborador.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Colaborador.Business.Contracts.Extensoes
{
    public interface ICriarColaboradorRepository
    {
        Either<ErroBase, bool> CriarColaborado(ColaboradorModel colaborador);
    }
}
