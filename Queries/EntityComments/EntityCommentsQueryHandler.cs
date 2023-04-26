using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data.Comment;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.Queries.EntityComments
{
    public class EntityCommentsQueryHandler : IQueryHandler<EntityCommentsQuery, IEnumerable<Comment>>
    {
        private readonly IAsyncDocumentSession _session;

        public EntityCommentsQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Comment>> Handle(EntityCommentsQuery query)
        {
            return await _session
                .Query<Comment>()
                .Where(x => x.EntityId == query.EntityId)
                .ToListAsync();
        }
    }
}