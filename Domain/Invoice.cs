using System;

namespace Domain
{
	public class Invoice : Entity
	{
		public decimal Ammount { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime InvoiceDate { get; set; }
		public int Status { get; set; }
		public decimal Quantity { get; set; }
		public string InvoiceNumber { get; set; }

		public Invoice():base()
		{

		}
		public Invoice(int id):base(id)
		{

		}
	}
}
