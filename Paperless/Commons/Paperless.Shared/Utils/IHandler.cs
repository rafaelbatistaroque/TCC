using Paperless.Shared.Erros;

namespace Paperless.Shared.Utils
{
    public interface IHandler<I, O> where I : ICommandQueryBase
    {
        Either<ErroBase, O> Handler(I commandQuery);
    }

    public interface IHandlerPrimitive<I, O> where I : struct
    {
        Either<ErroBase, O> Handler(I parameter);
    }

    public interface IHandler<O>
    {
        Either<ErroBase, O> Handler();
    }
}
