using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Domain
{
	public interface ILedgerRepository
	{
		Invoice AddInvoice(Invoice invoice);
		Invoice FindInvoiceById(ObjectId id);
		Invoice FindInvoiceByInvoiceNumber(string invoiceNumber);
	}
}
