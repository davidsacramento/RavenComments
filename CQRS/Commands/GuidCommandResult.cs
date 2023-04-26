using System;

namespace Backend.Challenge.CQRS.Commands
{
    public class GuidCommandResult : ICommandResult
    {
        public Guid Value { get; set; }

        public GuidCommandResult()
        {
            Value = Guid.Empty;
        }

        public GuidCommandResult(Guid value)
        {
            Value = value;
        }

        public static implicit operator GuidCommandResult(Guid value) => new GuidCommandResult(value);
    }
}
