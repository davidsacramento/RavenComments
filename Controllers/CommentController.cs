using System.Threading.Tasks;
using Backend.Challenge.Commands.CreateAuthor;
using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Backend.Challenge.Helpers;
using Backend.Challenge.Data.Comment;
using Microsoft.AspNetCore.Http;
using System;
using Backend.Challenge.Commands.CreateComment;
using Backend.Challenge.Queries.EntityComments;
using System.Collections.Generic;
using Backend.Challenge.Commands.MarkCommentsSeen;
using System.Linq;
using Backend.Challenge.Queries.UnseenEntityComments;
using Backend.Challenge.Dtos;

namespace Backend.Challenge.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CommentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher; 
        }

        public async Task<IActionResult> ListUnseen(string entityId)
        {
            var query = new UnseenEntityCommentsQuery { EntityId = entityId, UserId = "users/1-A" };
            var result = await _queryDispatcher.Dispatch<UnseenEntityCommentsQuery, IEnumerable<Comment>>(query);

            // Mark comments as seen
            var command = new MarkCommentsSeenCommand
            {
                EntityId = entityId,
                // TODO: use current user
                UserId = "users/1-A",
                Comments = result.Select(r => r.Id)
            };

            await _commandDispatcher.Dispatch<MarkCommentsSeenCommand, EmptyCommandResult>(command);

            return Ok(result);
        }

        public async Task<IActionResult> List(string entityId)
        {
            var query = new EntityCommentsQuery { EntityId = entityId };
            var result = await _queryDispatcher.Dispatch<EntityCommentsQuery, IEnumerable<Comment>>(query);

            // Mark comments as seen
            var command = new MarkCommentsSeenCommand
            {
                EntityId = entityId,
                // TODO: use current user
                UserId = "users/1-A",
                Comments = result.Select(r => r.Id)
            };

            await _commandDispatcher.Dispatch<MarkCommentsSeenCommand, EmptyCommandResult>(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequest request)
        {
            var command = new CreateCommentCommand
            {
                EntityId = request.EntityId,
                AuthorId = request.AuthorId,
                Text = request.Text
            };

            var result = await _commandDispatcher.Dispatch<CreateCommentCommand, EmptyCommandResult>(command);

            return result.ProcessRightResult()
                .ProcessValidationErrors()
                .ProcessOtherErrors();            
        }
    }
}