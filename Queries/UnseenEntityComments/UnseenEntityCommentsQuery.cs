using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data.Comment;
using System.Collections.Generic;

namespace Backend.Challenge.Queries.UnseenEntityComments
{
    public class UnseenEntityCommentsQuery : IQuery<IEnumerable<Comment>>
    {
        public string EntityId { get; set; }
        public string UserId { get; set; }
    }
}
