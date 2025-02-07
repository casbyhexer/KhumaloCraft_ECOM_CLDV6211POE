namespace OrderProcessingFunctionApp.Models
{
    public class Order
    {
        public int Id { get; set; } // ✅ Ensure OrderId exists (use `Id` if `OrderId` isn't defined)
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}
