import { Item } from "./item";

export class Order {
  id: number;
  customerId: number;
  status: string;
  items: Item[];
}
