using BlueModasStore.Domain.Enum;
using BlueModasStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModasStore.Domain.ViewModels
{
    public class OrderCartViewModel
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public OrderEnum Status { get; set; }
        public List<ItemCartViewModel> Items { get; set; }
        public decimal Total { get; set; }
    }
}
