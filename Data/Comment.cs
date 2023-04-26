using System;
using Backend.Challenge.Data;

namespace Backend.Challenge.Data.Comment
{
    public class Comment
    {
        public string Id { get; }
        public string EntityId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
