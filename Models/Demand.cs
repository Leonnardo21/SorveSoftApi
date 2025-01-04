using SorveSoftApi.Utils.Enums;

namespace SorveSoftApi.Models
{
    public class Demand
    {
        public int Id { get; set; }
        public DateTime DateHourDemand { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalValue { get; set; }
        public EOrderStatus Status { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
