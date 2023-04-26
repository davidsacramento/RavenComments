using Backend.Challenge.CQRS.Commands;

namespace Backend.Challenge.Commands.CreateIdea
{
    public class CreateIdeaCommand : AbstractCommand<StringCommandResult>
    {
        public string AuthorId { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}