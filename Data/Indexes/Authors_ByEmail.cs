using Raven.Client.Documents.Indexes;
using System;
using System.Linq;

namespace Backend.Challenge.Data.Indexes
{
    public class Authors_ByEmail : AbstractIndexCreationTask<Author>
    {
        public Authors_ByEmail()
        {
            Map = authors => from author in authors
                             select new
                             {
                                 Email = author.Email
                             };   
        }
    }
}
