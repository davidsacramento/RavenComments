using System;

namespace Backend.Challenge.Data
{
    public class Idea : IEntity
    {
        public string Id { get; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
