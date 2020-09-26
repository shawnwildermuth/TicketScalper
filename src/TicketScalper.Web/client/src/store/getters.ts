import IState from './IState';
import BasketItem from '@/models/BasketItem';
import Show from '@/models/Show';

export default {
  getShow: (state: IState) => (id: number): Show | undefined => {
    return state.shows.find(s => s.id == id);
  },
  isLoaded: (state: IState): boolean => state.shows.length > 0,
  basketTotal: (state: IState): Number => {
    return state.basket.length === 0 ? 0 : state.basket.reduce((a, v) => a + Number(v.price), 0);
  },
  hasTicket: (state: IState)=> (ticket: BasketItem): boolean  => state.basket.findIndex(t => t.id === ticket.id) > -1,
  isAuthenticated: (state: IState): boolean => {
    return (state.token && state.tokenExpiration >= Date.now()) ? true : false;
  },
  hasCustomer: (state: IState): boolean => state.customer ? true : false
};
