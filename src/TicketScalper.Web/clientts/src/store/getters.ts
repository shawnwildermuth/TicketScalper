import IState from './IState';
import BasketItem from '@/models/BasketItem';

export default {
  getShow: (state: IState) => (id: number) => {
    return state.shows.find(s => s.id == id);
  },
  isLoaded: (state: IState) => state.shows.length > 0,
  basketTotal: (state: IState) => {
    return state.basket.length === 0 ? 0 : state.basket.reduce((a, v) => a + Number(v.price), 0);
  },
  hasTicket: (state: IState) => (ticket: BasketItem) => state.basket.findIndex(t => t.id === ticket.id) > -1,
  isAuthenticated: (state: IState) => {
    return (state.token && state.tokenExpiration >= Date.now()) ? true : false;
  },
  hasCustomer: (state: IState) => state.customer
};
