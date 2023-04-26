using Raven.Client.Documents.Indexes;
using System;
using System.Linq;

namespace Backend.Challenge.Data.Indexes
{
    public class UserSeenComments_ByUserId_EntityId : AbstractIndexCreationTask<UserSeenComment.UserSeenComment>
    {
        public UserSeenComments_ByUserId_EntityId()
        {
            Map = comments => from comment in comments
                             select new
                             {
                                 comment.UserId,
                                 comment.EntityId
                             };
        }
    }
}
