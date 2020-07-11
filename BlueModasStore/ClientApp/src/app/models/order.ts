import { Item } from "./item";
import { Customer } from "./customer";

export class Order {
  id: number;
  customer: Customer;
  status: string;
  items: Item[];
  total: number;
}
