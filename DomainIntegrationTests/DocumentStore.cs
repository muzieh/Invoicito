using System;
using Domain;

namespace DomainIntegrationTests
{
    public class DocumentStore : IDocumentStore
    {
        public ISession OpenSession()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}