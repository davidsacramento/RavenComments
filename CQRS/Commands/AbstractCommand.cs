using System;

namespace Backend.Challenge.CQRS.Commands
{
    public abstract class AbstractCommand<TResult> : ICommand<TResult>
    where TResult : ICommandResult
    {
    }
}
