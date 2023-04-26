using Backend.Challenge.CQRS.Commands;

namespace Backend.Challenge.Commands.CreateComment
{
    public class CreateCommentCommand : AbstractCommand<EmptyCommandResult>
    {
        public string EntityId { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}