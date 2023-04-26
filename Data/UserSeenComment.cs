using System;
using Backend.Challenge.Data;

namespace Backend.Challenge.Data.UserSeenComment
{
    public class UserSeenComment
    {
        public string Id { get; }
        public string UserId { get; set; }
        public string EntityId { get; set; }
        public string CommentId { get; set; }
        public DateTime SeenDate { get; set; }
    }
}
