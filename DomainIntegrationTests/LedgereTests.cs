using Domain;
using FluentAssertions;
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
				Urls = new[] { "http://192.168.1.113:8080" },
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
			savedInvoice.Id.Should().NotBe(String.Empty);
		}


		[Fact]
		public void When_AddInvoice_ShouldBeAbleToSearchForit()
		{
			var invoice = new Invoice()
			{
				InvoiceNumber = "abcdef"
			};
			var ledger = new Ledger(ledgerRepository);
			var savedInvoice = ledger.AddInvoice(invoice);
			var searchedInvoice = ledger.GetInvoiceById(savedInvoice.Id);
			searchedInvoice.Id.Should().Be(savedInvoice.Id);

		}
	}
}
