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
  }
};
