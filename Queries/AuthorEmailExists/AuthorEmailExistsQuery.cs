using Backend.Challenge.CQRS.Queries;
using System.Collections.Generic;

namespace Backend.Challenge.Queries.AuthorEmailExists
{

    public class AuthorEmailExistsQuery : IQuery<bool>
    {
        public string Email { get; set; }
    }
}
