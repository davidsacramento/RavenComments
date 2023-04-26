namespace Backend.Challenge.Dtos
{
    public class CreateCommentRequest
    {
        public string EntityId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
    }
}
