import BasketItem from "../models/BasketItem";
import IState from './IState';
import { MutationTree } from 'vuex';
import Ticket from '@/models/Ticket';
import Show from '@/models/Show';
import Customer from '@/models/Customer';

const mutations: MutationTree<IState> = {
  setShows(state, shows: Array<Show>) {
    state.shows = shows;
  },
  setBusy(state): void {
    state.busy = true;
  },
  clearBusy(state): void {
    state.busy = false;
  },
  setTicketsForShow(state, data: TicketsForShow) {
    data.show.tickets = data.tickets;
  },
  addToBasket(state, data: ShowTicket) {
    let index = state.basket.findIndex(i => i.id === data.ticket.id);
    if (index === -1) {
      let item = {} as BasketItem;
      item.show = data.show.name;
      item.seat = data.ticket.seat
      state.basket.push(item);
    } 
  },
  removeFromBasket(state, ticket: Ticket) {
    let index = state.basket.findIndex(i => i.id === ticket.id);
    if (index > -1) state.basket.splice(index, 1);
  },
  clearBasket(state) {
    state.basket = [];
  },
  setError(state, error: any) {
    if (error instanceof Error) {
      if (!error.message) {
        state.error = error.name;
      } else {
        state.error = `${error.name}: ${error.message}`;
      }
    } else {
      state.error = error;
    }
  },
  clearError(state) {
    state.error = ""
  },
  setToken(state, { token, expiration }) {
    state.token = token;
    state.tokenExpiration = Date.parse(expiration);
  },
  setCustomer(state, customer: Customer) {
    state.customer = customer;
  }
};

interface TicketsForShow {
  show: Show;
  tickets: Array<Ticket>
}

interface ShowTicket {
  show: Show;
  ticket: Ticket;
}

export default mutations;
