import BasketItem from "../models/BasketItem";
import Customer from "../models/Customer";
import IState from './IState';
import { MutationTree } from 'vuex';

const mutations: MutationTree<IState> = {
  setShows(state, shows) {
    state.shows = shows;
  },
  setBusy(state) {
    state.busy = true;
  },
  clearBusy(state) {
    state.busy = false;
  },
  setTicketsForShow(state, { show, tickets }) {
    show.tickets = tickets;
  },
  addToBasket(state, { ticket, show }) {
    let index = state.basket.findIndex(i => i.id === ticket.id);
    if (index === -1) state.basket.push(new BasketItem(ticket, show));
  },
  removeFromBasket(state, ticket) {
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
  setCustomer(state, customer) {
    if (customer instanceof Customer) state.customer = customer;
    state.customer = new Customer(customer);
  }
};

export default mutations;
