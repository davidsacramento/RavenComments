using System.Collections.Generic;
using Backend.Challenge.CQRS.Nomad;

namespace Backend.Challenge.CQRS.Commands
{

    public class ValidationErrorResult : IAmAnError
    {
        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}