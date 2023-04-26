namespace Backend.Challenge.Dtos
{
    public class CreateIdeaRequest
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
    }
}
