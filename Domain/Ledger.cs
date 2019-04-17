using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

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

		public Invoice GetInvoiceById(ObjectId id)
		{
			return this.ledgerRepository.FindInvoiceById(id);
		}

		public Invoice GetInvoiceByInvoiceNumber(string invoiceNumber)
		{
			return this.ledgerRepository.FindInvoiceByInvoiceNumber(invoiceNumber);
		}

		public Invoice FindByInvoiceNumber(string invoiceNumber)
		{
			return this.ledgerRepository.FindInvoiceByInvoiceNumber(invoiceNumber);
			//return invoices.FirstOrDefault(i => i.InvoiceNumber == invoiceNumber);
		}
	}
}
