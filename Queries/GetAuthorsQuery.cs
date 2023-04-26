using Backend.Challenge.CQRS.Queries;
using System.Collections.Generic;

namespace Backend.Challenge.Queries
{

    public class GetAuthorsQuery : IQuery<List<GetAuthorsQuery.Author>>
    {

        public class Author
        {
            public string AuthorId { get; set; }
            public string AuthorName { get; set; }
            public string Email { get; set; }
            public string ProfilePictureUrl { get; set; }
        }
    }
}
