namespace Backend.Challenge.CQRS.Commands
{
    public interface ICommand<TResult>
        where TResult : ICommandResult
    {
    }

}
