using OrderManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Entities
{

    public class Invoice : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
    }
}
