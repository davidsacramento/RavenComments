using Backend.Challenge.CQRS.Commands;
using System.Collections.Generic;

namespace Backend.Challenge.Commands.MarkCommentsSeen
{
    public class MarkCommentsSeenCommand : AbstractCommand<EmptyCommandResult>
    {
        public string UserId { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public IEnumerable<string> Comments { get; set; } = new List<string>();
    }
}