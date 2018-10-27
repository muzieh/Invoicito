using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
	public class LedgerRepository : Repository<Ledger>, ILedgerRepository
	{
		public Invoice AddInvoice(Invoice invoice)
		{
			throw new NotImplementedException();
		}

		public Invoice FindInvoiceById(string invoiceNumber)
		{
			throw new NotImplementedException();
		}
	}
}
