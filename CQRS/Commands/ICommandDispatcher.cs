using System.Threading.Tasks;
using Backend.Challenge.CQRS.Nomad;

namespace Backend.Challenge.CQRS.Commands
{

    /// <summary>
    ///     Dispatches commands to their proper handler
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        ///     Dispatches commands to their proper handler
        /// </summary>
        /// <typeparam name="TCommand">Type of command to be dispatched</typeparam>
        /// <typeparam name="TResult">The return type of the happy path</typeparam>
        /// <param name="command">Command to be dispatched</param>
        /// <returns></returns>
        Task<Either<IAmAnError, TResult>> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : ICommandResult;
    }
}