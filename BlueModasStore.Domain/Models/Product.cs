using System;

namespace BlueModasStore.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Byte[] Image { get; set; }
    }
}
