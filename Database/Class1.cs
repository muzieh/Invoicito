using Domain;
using Raven.Client.Documents;
using System;

namespace Database
{
	public class LedgerRepository : ILedgerRepository
	{
		private readonly IDocumentStore store;

		public LedgerRepository(IDocumentStore store)
		{
			this.store = store;
		}

		public Invoice AddInvoice(Invoice invoice)
		{
			using (var session = store.OpenSession())
			{
				session.Store(invoice);
				session.SaveChanges();
				return invoice;
			}
		}

		public Invoice FindInvoiceById(string invoiceNumber)
		{
			throw new NotImplementedException();
		}
	}
}
