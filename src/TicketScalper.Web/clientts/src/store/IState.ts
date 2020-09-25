import Customer from '@/models/Customer';
import BasketItem from '@/models/BasketItem';
import Show from '@/models/Show';

export default interface IState {
  shows: Array<Show>;
  busy: boolean;
  basket: Array<BasketItem>;
  error: string;
  customer: Customer;
  token: string;
  tokenExpiration: number;  
}