using Backend.Challenge.CQRS.Commands;

namespace Backend.Challenge.Commands.CreateAuthor
{
    public class CreateAuthorCommand : AbstractCommand<StringCommandResult>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
    }
}