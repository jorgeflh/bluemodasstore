import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit, OnDestroy {

  public orderId;
  public order;

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderId = localStorage.getItem("OrderId");

    this.orderService.GetOrder(this.orderId).subscribe((data) => {
      this.order = data;
    });
  }

  ngOnDestroy() {
    localStorage.clear();
  }

}
