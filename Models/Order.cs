using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        // ✅ Foreign Key
        public int UserID { get; set; }

        [Column(TypeName = "datetime2")] // ✅ SQL Server uses datetime2 for DateTime values
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(10,2)")] // ✅ SQL Server uses decimal(10,2) instead of NUMBER(10,2)
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        // ✅ Navigation Properties
        public User User { get; set; }  // No need for ForeignKey attribute

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
