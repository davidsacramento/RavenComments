using Raven.Client.Documents.Operations;
using Raven.Client.Documents;
using Raven.Client.Exceptions.Database;
using Raven.Client.Exceptions;
using Raven.Client.ServerWide.Operations;
using Raven.Client.ServerWide;
using System.Threading.Tasks;
using System;

namespace Backend.Challenge.Data
{
    public interface IEntity 
    {
        string Id { get; }
        string AuthorId { get; set; }
        DateTime PublishedDate { get; set; }
    }

}