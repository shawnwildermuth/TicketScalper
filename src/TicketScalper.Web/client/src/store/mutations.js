import BasketItem from "../models/basketItem";

export default {
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
  setError(state, error) {
    if (error instanceof Error) {
      if (error.response) {
        state.error = error.response.data;
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
    state.customer = customer;
  }
};
