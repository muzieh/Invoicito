using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
	public class LedgerRepository : Repository<Ledger>, ILedgerRepository
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

		public Invoice FindInvoiceById(string id)
		{
			using(var session = store.OpenSession())
			{
				return session.Load<Invoice>(id);
			}
		}
	}
}
