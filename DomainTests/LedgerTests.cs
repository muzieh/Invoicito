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
		public void When_AddInvoice_Then_ItShouldBeAddedToLedger()
		{
			var ledgerRepositoryMock = new Mock<ILedgerRepository>();
			var invoice = new Invoice();
			ledgerRepositoryMock.Setup(lr => lr.AddInvoice(invoice)).Returns(invoice);
			var ledger = new Ledger(ledgerRepositoryMock.Object);
			var addedInvoice = (ledger.AddInvoice(invoice));
			addedInvoice.Should().Be(invoice);
			ledgerRepositoryMock.Verify();
		}

		[Fact]
		public void When_AddInvoice_Then_ShouldBeAbleToSearchByInvoiceNumber()
		{
			var ledgerRepositoryMock = new Mock<ILedgerRepository>();
			var invoiceNumber = "abc/2018";
			ledgerRepositoryMock.Setup(x => x.FindInvoiceById(invoiceNumber)).Returns(new Invoice()
			{
				InvoiceNumber = invoiceNumber
			});
			var ledger = new Ledger(ledgerRepositoryMock.Object);

			var foundInvoice = ledger.FindByInvoiceNumber(invoiceNumber);
			foundInvoice.InvoiceNumber.Should().Be(invoiceNumber);
		}

		[Fact]
		public void When_AddInvoice_Then_InvoiceStoredInPersistanceLayer()
		{
			var ledgerRepositoryMoq = new Mock<ILedgerRepository>();
			var id = "invoice/5-A";
			var invoice = new Invoice(id)
			{
				InvoiceNumber = "abc/2018"
			};
			ledgerRepositoryMoq.Setup(foo => foo.AddInvoice(It.IsAny<Invoice>())).Returns(invoice);
			var ledger = new Ledger(ledgerRepositoryMoq.Object);
			var returnedInvoice = ledger.AddInvoice(invoice);
			returnedInvoice.Id.Should().Be(id);
			ledgerRepositoryMoq.VerifyAll();
		}

		[Fact]
		public void When_SearchForInvoiceById_Should_CallRepository()
		{
			var ledgerRepositoryMoq = new Mock<ILedgerRepository>();
			var ledger = new Ledger(ledgerRepositoryMoq.Object);
			ledger.GetInvoiceById("abcd");
			ledgerRepositoryMoq.Verify(x => x.FindInvoiceById("abcd"));
		}
	}
}
