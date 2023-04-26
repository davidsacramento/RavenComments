using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data.Comment;
using Backend.Challenge.Data.Indexes;
using Backend.Challenge.Data.UserSeenComment;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.Queries.UnseenEntityComments
{
    public class UnseenEntityCommentsQueryHandler : IQueryHandler<UnseenEntityCommentsQuery, IEnumerable<Comment>>
    {
        private readonly IAsyncDocumentSession _session;

        public UnseenEntityCommentsQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Comment>> Handle(UnseenEntityCommentsQuery query)
        {
            var seenComments = await _session
                .Query<UserSeenComment, UserSeenComments_ByUserId_EntityId>()
                .Customize(x => x.NoTracking())
                .Where(x => x.EntityId == query.EntityId && x.UserId == query.UserId)
                .Select(x => x.CommentId)
                .ToListAsync();

            return await _session.Query<Comment>()
                .Where(x => x.EntityId == query.EntityId && !x.Id.In(seenComments))
                .ToListAsync();
        }
    }
}