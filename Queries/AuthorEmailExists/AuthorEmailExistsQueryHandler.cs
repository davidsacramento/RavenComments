using Backend.Challenge.CQRS.Queries;
using Backend.Challenge.Data;
using Backend.Challenge.Data.Indexes;
using Backend.Challenge.Queries.AuthorEmailExists;
using Backend.Challenge.Queries.EntityComments;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.Queries
{
    public class AuthorEmailExistsQueryHandler : IQueryHandler<AuthorEmailExistsQuery, bool>
    {

        private readonly IAsyncDocumentSession _session;

        public AuthorEmailExistsQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<bool> Handle(AuthorEmailExistsQuery query)
        {
            return await _session.Query<Author, Authors_ByEmail>()
                .Where(a => a.Email == query.Email)
                .AnyAsync();
        }
    }
}