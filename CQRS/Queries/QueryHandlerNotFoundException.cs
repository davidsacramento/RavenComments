using System;

namespace Backend.Challenge.CQRS
{
    public class QueryHandlerNotFoundException : Exception
    {
        public Type QueryType { get; set; }

        public QueryHandlerNotFoundException()
        {
            QueryType = GetType();
        }

        public QueryHandlerNotFoundException(Type queryType, Exception innerException) : base(GetErrorMessage(queryType),
            innerException)
        {
            QueryType = queryType;
        }

        private static string GetErrorMessage(Type queryType)
        {
            return $"No query handler found for '{queryType}'.";
        }
    }
}