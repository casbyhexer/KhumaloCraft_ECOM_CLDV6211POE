using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        // ✅ Foreign Keys
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")] // ✅ SQL Server uses decimal(10,2)
        public decimal Price { get; set; }

        // ✅ Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
