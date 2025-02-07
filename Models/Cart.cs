using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        // ✅ Foreign Keys
        public int UserID { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; } = 1;

        // ✅ Navigation Properties
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
