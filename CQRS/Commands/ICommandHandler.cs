using Backend.Challenge.CQRS.Nomad;
using System.Threading.Tasks;

namespace Backend.Challenge.CQRS.Commands
{
    public interface ICommandHandler<in T, TResult>
        where T : ICommand<TResult> 
        where TResult : ICommandResult
    {
		Task<Either<IAmAnError, TResult>> Handle(T command);
	}
}
