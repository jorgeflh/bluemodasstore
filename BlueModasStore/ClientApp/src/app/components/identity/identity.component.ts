import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/customer';
import { CustomerService } from '../../services/customer.service';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-identity',
  templateUrl: './identity.component.html',
  styleUrls: ['./identity.component.css']
})
export class IdentityComponent implements OnInit {

  public customer: Customer = {
    id: 0,
    email: "",
    name: "",
    phone: ""
  }
  public orderId;

  constructor(
    private customerService: CustomerService,
    private orderService: OrderService,
    private router: Router
  ) { }

  ngOnInit() {
    this.orderId = localStorage.getItem("OrderId");
  }

  onSubmit(value: any) {
    this.customer.name = value['name'];
    this.customer.email = value['email'];
    this.customer.phone = value['phone'];
    this.customerService.IdentifyCustomer(this.customer).subscribe((data) => {
      console.log(data);
      this.customer.id = data.id;
      localStorage.setItem("CustomerId", data.id.toString());

      this.orderService.FinishOrder(this.orderId, this.customer.id)
        .subscribe((data) => {
          console.log(data);
          this.router.navigateByUrl('/checkout');
        });
    });
  }
}
