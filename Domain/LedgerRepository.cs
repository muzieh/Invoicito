using System;

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

	public interface IDocumentStore : IDisposable
	{
		ISession OpenSession();
		void Dispose();
	}

	public interface ISession : IDisposable
	{
		void Store(Invoice invoice);
		void SaveChanges();
		T Load<T>(string id);
	}
}
