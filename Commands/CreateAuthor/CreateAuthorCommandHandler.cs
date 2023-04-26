using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Nomad;
using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data;
using Backend.Challenge.Queries.AuthorEmailExists;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Challenge.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, StringCommandResult>
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IQueryDispatcher _queryDispatcher;

        public CreateAuthorCommandHandler(IAsyncDocumentSession session, IQueryDispatcher queryDispatcher)
        {
            _session = session;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<Either<IAmAnError, StringCommandResult>> Handle(CreateAuthorCommand command)
        {
            // Check if email is unique
            var emailUniqueCheckResult = await VerifEmailUnique(command);
            if (emailUniqueCheckResult != null) return emailUniqueCheckResult;

            var author = new Author 
            { 
                Name = command.Name,
                Email = command.Email,
                ProfilePictureUrl = command.ProfilePictureUrl,
                CreatedDate = DateTime.UtcNow
            };

            await _session.StoreAsync(author);
            await _session.SaveChangesAsync();

            return new StringCommandResult(author.Id);
        }

        private async Task<ValidationErrorResult> VerifEmailUnique(CreateAuthorCommand command)
        {
            var emailExists = await _queryDispatcher.Dispatch<AuthorEmailExistsQuery, bool>(new AuthorEmailExistsQuery()
            {
                Email = command.Email
            });

            if (emailExists)
            {
                return new ValidationErrorResult()
                {
                    Errors = new List<ValidationErrors>()
                {
                    ValidationErrors.EmailNotUnique
                }
                };
            }

            return default;
        }
    }
}