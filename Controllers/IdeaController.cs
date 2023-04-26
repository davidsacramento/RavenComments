using System.Threading.Tasks;
using Backend.Challenge.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using Backend.Challenge.Helpers;
using Backend.Challenge.Commands.CreateIdea;
using Backend.Challenge.Dtos;

namespace Backend.Challenge.Controllers
{
    public class IdeaController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public IdeaController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIdeaRequest request)
        {
            var command = new CreateIdeaCommand
            {
                AuthorId = request.AuthorId,
                Subject = request.Subject,
                Text = request.Text
            };

            var result = await _commandDispatcher.Dispatch<CreateIdeaCommand, StringCommandResult>(command);

            return result.ProcessRightResult()
                .ProcessValidationErrors()
                .ProcessOtherErrors();            
        }
    }
}