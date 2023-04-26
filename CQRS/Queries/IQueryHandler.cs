using System.Threading.Tasks;

namespace Backend.Challenge.CQRS.Queries
{
	public interface IQueryHandler<in TQuery, TResult>	where TQuery : IQuery<TResult>
	{
		Task<TResult> Handle(TQuery query);
	}
}
