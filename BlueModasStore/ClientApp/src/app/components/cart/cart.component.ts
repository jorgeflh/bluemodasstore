import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public orderId;
  public order: Order;

  constructor(
    private orderService: OrderService,
  ) { }

  ngOnInit() {
    this.orderId = localStorage.getItem("OrderId");

    if (this.orderId !== null) {
      this.getOrder();
    }
  }

  updateQuantity(item, value) {
    this.orderService.UpdateItem(item.id, value).subscribe((data) => {
      this.getOrder();
    });
  }

  removeItem(itemId) {
    this.orderService.RemoveItem(itemId).subscribe((data) => {
      this.getOrder();
    })
  }

  getOrder() {
    this.orderService.GetOrder(this.orderId).subscribe((data) => {
      this.order = data;
    });
  }
}
