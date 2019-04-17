using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Domain
{
	public class LedgerRepository : Repository<Ledger>, ILedgerRepository
	{
		private IMongoCollection<Invoice> invoices;
		
		public LedgerRepository(IMongoDatabase db)
		{
			this.invoices = db.GetCollection<Invoice>("invoices");
		}

		public Invoice AddInvoice(Invoice invoice)
		{
			invoices.InsertOne( invoice );
			return invoice;
		}

		public Invoice FindInvoiceById(ObjectId id)
		{
			return invoices.FindSync(i => i.Id == id, null).Single();
		}

		public Invoice FindInvoiceByInvoiceNumber(string invoiceNumber)
		{
			throw new NotImplementedException();
		}
	}
}
