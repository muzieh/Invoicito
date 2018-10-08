using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public class Ledger
	{
		public List<Invoice> invoices { get; private set; } = new List<Invoice>();
		public Ledger()
		{
		}
		public Invoice AddInvoice(Invoice invoice)
		{
			var nextId = invoices.Count == 0 ? 1 : invoices.Max(i => i.Id);
			var persistedInvoice = new Invoice(nextId) { };
			invoices.Add(persistedInvoice);
			return persistedInvoice;
		}

		public object GetInvoiceById(int id)
		{
			return invoices.FirstOrDefault(i => i.Id == id);
		}
	}
}
