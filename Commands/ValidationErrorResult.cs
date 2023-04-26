using Backend.Challenge.CQRS.Nomad;
using System.Collections.Generic;

namespace Backend.Challenge.Commands
{
    public enum ValidationErrors : int
    {
        EmailNotUnique = 0,
        EmptyCommentText = 1
    }

    public class ValidationErrorResult : IAmAnError
    {
        public List<ValidationErrors> Errors { get; set; } = new List<ValidationErrors>();
    }
}