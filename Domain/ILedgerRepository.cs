using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
	public interface ILedgerRepository
	{
		Invoice AddInvoice(Invoice invoice);
		Invoice FindInvoiceById(string invoiceNumber);
	}
}
