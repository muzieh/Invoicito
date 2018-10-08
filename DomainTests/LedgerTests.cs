using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DomainTests
{
	public class LedgerTests
	{
		[Fact]
		public void When_AddInvoice_Then_ItShouldNonZeroId()
		{
			var ledger = new Ledger();
			var invoice = new Invoice();
			var savedInvoice = ledger.AddInvoice(invoice);
			Assert.True(savedInvoice.Id > 0);
		}

		[Fact]
		public void When_AddInvoice_Then_ItShouldBeAddedToLedger()
		{
			var ledger = new Ledger();
			var invoice = (ledger.AddInvoice(new Invoice()));
			var result = ledger.GetInvoiceById(invoice.Id);
			Assert.Equal(invoice, result);
		}
	}
}
