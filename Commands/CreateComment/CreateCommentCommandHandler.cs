using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Nomad;
using Backend.Challenge.Data.Comment;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Challenge.Commands.CreateComment
{
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand, EmptyCommandResult>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateCommentCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<Either<IAmAnError, EmptyCommandResult>> Handle(CreateCommentCommand command)
        {
            if (string.IsNullOrEmpty(command.Text))
                return new ValidationErrorResult()
                {
                    Errors = new List<ValidationErrors>() 
                    {
                        ValidationErrors.EmptyCommentText
                    }
                };

            var comment = new Comment
            {
                AuthorId = command.AuthorId,
                EntityId = command.EntityId,
                Text = command.Text,
                PublishedDate = DateTime.UtcNow
            };

            await _session.StoreAsync(comment);
            await _session.SaveChangesAsync();

            return new EmptyCommandResult();
        }
    }
}