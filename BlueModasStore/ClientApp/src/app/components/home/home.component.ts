import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { OrderService } from '../../services/order.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public products;
  public orderId;
  public order;

  constructor(
    private productService: ProductService,
    private orderService: OrderService,
    private router: Router
  ) { }

  ngOnInit() {
    this.productService.getProducts()
      .subscribe((data) => {
        console.log(data);
        this.products = data;
      });
  }

  addToCart(event, item) {
    this.orderId = localStorage.getItem("OrderId");
    console.log("OrderId: " + this.orderId);
    this.orderService.AddItem(item.id, this.orderId, 1).subscribe((data) => {
      console.log(data);
      this.order = data;
      localStorage.setItem('OrderId', data.id.toString());
      this.router.navigateByUrl('/cart');
    });
  }

}
