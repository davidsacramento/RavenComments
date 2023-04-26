using System;

namespace Backend.Challenge.CQRS.Commands
{
    public class EmptyCommandResult : ICommandResult
    {
        public static EmptyCommandResult Instance = new();
    }

    public static class CommandResult
    {

        public static EmptyCommandResult Empty = EmptyCommandResult.Instance;
        public static GuidCommandResult FromGuid(Guid guid) => new GuidCommandResult(guid);
    }
}
