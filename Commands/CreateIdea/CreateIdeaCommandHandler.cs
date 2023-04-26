using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Nomad;
using Backend.Challenge.Data;
using Raven.Client.Documents.Session;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Commands.CreateIdea
{
    public class CreateIdeaCommandHandler : ICommandHandler<CreateIdeaCommand, StringCommandResult>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateIdeaCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<Either<IAmAnError, StringCommandResult>> Handle(CreateIdeaCommand command)
        {
            var idea = new Idea
            { 
                AuthorId = command.AuthorId,
                Subject = command.Subject,
                Text = command.Text,
                PublishedDate = DateTime.UtcNow
            };

            await _session.StoreAsync(idea);
            await _session.SaveChangesAsync();

            return new StringCommandResult(idea.Id);
        }
    }
}