//using Backend.Challenge.CQRS.Queries;
//using Backend.Challenge.Data.Author;
//using Backend.Challenge.Dtos;
//using Raven.Client.Documents;
//using Raven.Client.Documents.Session;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Backend.Challenge.Queries
//{
//    public class GetAuthorsQueryHandler : IQueryHandler<GetAuthorsQuery, List<GetAuthorsQuery.Author>>
//    {

//        private readonly IAsyncDocumentSession _session;

//        public GetAuthorsQueryHandler(IAsyncDocumentSession session)
//        {
//            _session = session;
//        }

//        public async Task<List<GetAuthorsQuery.Author>> Handle(GetAuthorsQuery query)
//        {
//            return await _session
//                .Query<Author>()
//                .ToListAsync();
//        }
//    }
//}