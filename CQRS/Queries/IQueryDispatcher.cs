using System.Threading.Tasks;

namespace Backend.Challenge.CQRS.Queries
{

    /// <summary>
    ///     Finds the correct query handler, executes the query and returns the result
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        ///     Finds the correct query handler, executes the query and returns the result
        /// </summary>
        /// <typeparam name="TQuery">Type of the query</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="query">The query</param>
        /// <returns>An awaitable task returning the result of the query</returns>
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}