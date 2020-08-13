import Customer from '@/models/Customer';
import BasketItem from '@/models/BasketItem';

export default interface IState {
  shows: Array<any>;
  busy: boolean;
  basket: Array<BasketItem>;
  error: string;
  customer: Customer;
  token: string;
  tokenExpiration: number;  
}