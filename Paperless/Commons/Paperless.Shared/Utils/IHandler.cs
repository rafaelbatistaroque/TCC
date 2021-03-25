using Paperless.Shared.Erros;

namespace Paperless.Shared.Utils
{
    public interface IHandler<I, O> where I : ICommandBase
    {
        Either<ErroBase, O> Handler(I command);
    }
}
