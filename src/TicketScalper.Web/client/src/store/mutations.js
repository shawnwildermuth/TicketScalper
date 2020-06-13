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
  addToBasket(state, ticket) {
    let index = state.basket.indexOf(ticket);
    if (index === -1) state.basket.push(ticket);
  },
  removeFromBasket(state, ticket) {
    let index = state.basket.indexOf(ticket);
    if (index > -1) state.basket.splice(index, 1);
  }
};
