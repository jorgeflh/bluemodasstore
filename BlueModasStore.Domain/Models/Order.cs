using BlueModasStore.Domain.Enum;

namespace BlueModasStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderEnum Status { get; set; }
    }
}
