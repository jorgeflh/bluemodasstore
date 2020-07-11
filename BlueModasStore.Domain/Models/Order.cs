using BlueModasStore.Domain.Enum;
using System.Collections.Generic;

namespace BlueModasStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderEnum Status { get; set; }
        public List<Item> Items { get; set; }
    }
}
