using System;
using System.Collections.Generic;

namespace Fray_c.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RecordDate { get; set; }
    }
}