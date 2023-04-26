using Raven.Client.Documents.Indexes;
using System;
using System.Linq;

namespace Backend.Challenge.Data.Indexes
{
    public class Entities_ById : AbstractMultiMapIndexCreationTask
    {
        public Entities_ById()
        {
            AddMap<Idea>(idea => from i in idea select new { i.Id });
        }
    }
}
