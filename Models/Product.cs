using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(4000)")] // ✅ Use nvarchar instead of VARCHAR2
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")] // ✅ SQL Server uses decimal(10,2)
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [Column(TypeName = "nvarchar(255)")] // ✅ Use nvarchar instead of VARCHAR2
        public string Category { get; set; }

        public string ImageURL { get; set; }

        [Column(TypeName = "bit")] // ✅ SQL Server uses bit for boolean
        public bool Availability { get; set; }

        // ✅ Navigation Properties
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
