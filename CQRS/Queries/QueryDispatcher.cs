using System;
using System.Threading.Tasks;

namespace Backend.Challenge.CQRS.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IResolver _resolver;

        public QueryDispatcher(IResolver resolver)
        {
            _resolver = resolver;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            IQueryHandler<TQuery, TResult> handler;
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            try
            {
                handler = (IQueryHandler<TQuery, TResult>)_resolver.Resolve(handlerType);
            }
            catch (Exception ex)
            {
                throw new QueryHandlerNotFoundException(query.GetType(), ex);
            }

            var queryResult = await handler.Handle(query);
            return queryResult;
        }
    }
}