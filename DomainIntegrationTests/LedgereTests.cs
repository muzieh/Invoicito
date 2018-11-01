using Domain;
using Raven.Client.Documents;
using System;
using Xunit;

namespace DomainIntegrationTests
{
	public class LedgereTests : IDisposable
	{
		private ILedgerRepository ledgerRepository;
		private IDocumentStore store;

		public LedgereTests()
		{
			store = new DocumentStore()
			{
				Urls = new[] { "http://192.168.43.30:8080" },
				Database = "Invoicito"
			}.Initialize();
			this.ledgerRepository = new LedgerRepository(store);
		}

		public void Dispose()
		{
			this.store.Dispose();
		}

		[Fact]
		public void When_AddInvoice_AddedToDatabase()
		{
			var invoice = new Invoice()
			{
				InvoiceNumber = "abcdef"
			};
			var ledger = new Ledger(ledgerRepository);
			var savedInvoice = ledger.AddInvoice(invoice);


		}
	}
}
