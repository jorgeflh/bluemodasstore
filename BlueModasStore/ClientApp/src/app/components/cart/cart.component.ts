import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order';
import { OrderService } from '../../services/order.service';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';

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
    private router: Router
  ) { }

  ngOnInit() {
    this.orderId = localStorage.getItem("OrderId");

    if (this.orderId !== null) {
      this.getOrder();
    }

    console.log("Order length: " + this.order.items.length);
  }

  updateQuantity(item, value) {
    console.log(item);
    console.log(value);
    this.orderService.UpdateItem(item.id, value).subscribe((data) => {
      console.log(data);
      this.getOrder();
    });
  }

  removeItem(itemId) {
    console.log(itemId);
    this.orderService.RemoveItem(itemId).subscribe((data) => {
      console.log(data);
      this.getOrder();
    })
  }

  getOrder() {
    this.orderService.GetOrder(this.orderId).subscribe((data) => {
      console.log(data);
      this.order = data;
    });
  }
}
