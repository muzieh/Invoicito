using Domain;
using FluentAssertions;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace DomainIntegrationTests
{
	public class LedgereTests : IDisposable
	{
		private ILedgerRepository ledgerRepository;
		private IMongoClient client;
		private IMongoDatabase db;

		public LedgereTests()
		{
			var connectionString = "mongodb://localhost:27017";
			var databaseName = "invoicito_test";
			
			this.client = new MongoClient(connectionString);
			this.db = this.client.GetDatabase(databaseName);
			this.ledgerRepository = new LedgerRepository(this.db);
		}

		public void Dispose()
		{
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
			savedInvoice.Id.Should().NotBe(ObjectId.Empty);
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
