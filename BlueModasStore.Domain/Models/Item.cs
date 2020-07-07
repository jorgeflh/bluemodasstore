using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModasStore.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
