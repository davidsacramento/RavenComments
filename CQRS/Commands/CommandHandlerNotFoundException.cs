using System;

namespace Backend.Challenge.CQRS.Commands
{
    public class CommandHandlerNotFoundException : Exception
    {
        public Type CommandType { get; set; }

        public CommandHandlerNotFoundException()
        {
            CommandType = GetType();
        }
        public CommandHandlerNotFoundException(object command, Exception innerException)
            : base(GetErrorMessage(command.GetType()), innerException)
        {
            CommandType = command.GetType();
        }

        private static string GetErrorMessage(Type commandType)
        {
            return $"No command handler found for '{commandType}'.";
        }
    }
}
