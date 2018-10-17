using Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace DomainTests
{
	public class LedgerTests
	{
		[Fact]
		public void When_AddInvoice_Then_ItShouldNonZeroId()
		{
			
			var ledger = new Ledger(null);
			var invoice = new Invoice();
			var savedInvoice = ledger.AddInvoice(invoice);

			savedInvoice.Id.Should().BePositive();
		}

		[Fact]
		public void When_AddInvoice_Then_ItShouldBeAddedToLedger()
		{
			var ledger = new Ledger(null);
			var invoice = (ledger.AddInvoice(new Invoice()));
			var result = ledger.GetInvoiceById(invoice.Id);
			Assert.Equal(invoice, result);
			result.Should().Be(invoice);
		}

		[Fact]
		public void When_AddInvoice_Then_ShouldBeAbleToSearchByInvoiceNumber()
		{
			var ledger = new Ledger(null);
			var invoice = new Invoice()
			{
				Ammount = 10m,
				InvoiceNumber = "ABC/2018"
			};

			ledger.AddInvoice(invoice);
			var addedInvoice = ledger.FindByInvoiceNumber(invoice.InvoiceNumber);
			addedInvoice.Should().NotBeNull();
			addedInvoice.InvoiceNumber.Should().Be(invoice.InvoiceNumber);
		}

		[Fact]
		public void When_AddInvoice_Then_InvoiceStoredInPersistanceLayer()
		{
			var ledgerRepositoryMoq = new Mock<ILedgerRepository>();
			var invoice = new Invoice(123)
			{
				InvoiceNumber = "abc/2018"
			};
			ledgerRepositoryMoq.Setup(foo => foo.AddInvoice(It.IsAny<Invoice>())).Returns(invoice);
			var ledger = new Ledger(ledgerRepositoryMoq.Object);
			var returnedInvoice = ledger.AddInvoice(invoice);
			returnedInvoice.Id.Should().Be(123);
			ledgerRepositoryMoq.VerifyAll();

		}
	}
}
