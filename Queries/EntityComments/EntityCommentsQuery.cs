using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data.Comment;
using System.Collections.Generic;

namespace Backend.Challenge.Queries.EntityComments
{
    public class EntityCommentsQuery : IQuery<IEnumerable<Comment>>
    {
        public string EntityId { get; set; }
    }
}
