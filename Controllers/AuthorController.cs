using System.Threading.Tasks;
using Backend.Challenge.Commands.CreateAuthor;
using Backend.Challenge.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using Backend.Challenge.Helpers;
using Backend.Challenge.Dtos;

namespace Backend.Challenge.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AuthorController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequest request)
        {
            var command = new CreateAuthorCommand
            {
                Name = request.Name,
                Email= request.Email
            };

            var result = await _commandDispatcher.Dispatch<CreateAuthorCommand, StringCommandResult>(command);

            return result.ProcessRightResult()
                .ProcessValidationErrors()
                .ProcessOtherErrors();            
        }
    }
}