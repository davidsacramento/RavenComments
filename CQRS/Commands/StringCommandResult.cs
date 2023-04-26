using System;

namespace Backend.Challenge.CQRS.Commands
{
    public class StringCommandResult : ICommandResult
    {
        public string Value { get; set; }

        public StringCommandResult()
        {
            Value = string.Empty;
        }

        public StringCommandResult(string value)
        {
            Value = value;
        }

        public static implicit operator StringCommandResult(string value) => new StringCommandResult(value);
    }
}
