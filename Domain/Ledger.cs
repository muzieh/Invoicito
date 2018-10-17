using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public class Ledger : AggregateRoot
	{
		private readonly ILedgerRepository ledgerRepository;

		public List<Invoice> invoices { get; private set; } = new List<Invoice>();
		public Ledger(ILedgerRepository ledgerRepository)
		{
			this.ledgerRepository = ledgerRepository;
		}

		public Invoice AddInvoice(Invoice invoice)
		{
			//var nextId = invoices.Count == 0 ? 1 : invoices.Max(i => i.Id);
			//var persistedInvoice = new Invoice(nextId) {
			//	Ammount = invoice.Ammount,
			//	DueDate = invoice.DueDate,
			//	InvoiceNumber = invoice.InvoiceNumber,
			//	InvoiceDate = invoice.InvoiceDate,
			//	Quantity = invoice.Quantity,
			//	Status = invoice.Status
			//};
			//invoices.Add(persistedInvoice);
			var savedInvoice = ledgerRepository.AddInvoice(invoice);
			return savedInvoice;
		}

		public object GetInvoiceById(int id)
		{
			return invoices.FirstOrDefault(i => i.Id == id);
		}

		public Invoice FindByInvoiceNumber(string invoiceNumber)
		{
			return invoices.FirstOrDefault(i => i.InvoiceNumber == invoiceNumber);
		}
	}
}
