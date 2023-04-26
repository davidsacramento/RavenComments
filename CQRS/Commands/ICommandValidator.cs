using System.Collections.Generic;

namespace Backend.Challenge.CQRS.Commands
{
    public interface ICommandValidator<in TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : ICommandResult
    {
        List<string> Verify(TCommand command);
    }
}