using Backend.Challenge.Commands.MarkCommentsSeen;
using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS.Nomad;
using Backend.Challenge.Data.UserSeenComment;
using Raven.Client.Documents;
using Raven.Client.Documents.BulkInsert;
using System;
using System.Threading.Tasks;

namespace Backend.Challenge.Commands.MarkCommentSeen
{
    public class MarkCommentsSeenCommandHandler : ICommandHandler<MarkCommentsSeenCommand, EmptyCommandResult>
    {
        private readonly IDocumentStore _store;

        public MarkCommentsSeenCommandHandler(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<Either<IAmAnError, EmptyCommandResult>> Handle(MarkCommentsSeenCommand command)
        {
            using (var bulk = _store.BulkInsert(new BulkInsertOptions
            {
                SkipOverwriteIfUnchanged = true
            }))
            {
                foreach(var comment in command.Comments)
                {
                    await bulk.StoreAsync(new UserSeenComment
                    {
                        EntityId = command.EntityId,
                        UserId = command.UserId,
                        CommentId = comment,
                        SeenDate = DateTime.UtcNow
                    });
                }
            }

            return new EmptyCommandResult();
        }
    }
}