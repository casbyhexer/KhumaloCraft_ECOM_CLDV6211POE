using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        // ✅ Foreign Keys
        public int OrderID { get; set; }
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "datetime2")] // ✅ SQL Server uses datetime2
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(10,2)")] // ✅ SQL Server uses decimal(10,2)
        public decimal Amount { get; set; }

        // ✅ Navigation Properties
        public Order Order { get; set; }
        public User User { get; set; }
    }
}
