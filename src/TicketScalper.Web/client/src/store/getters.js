export default {
  getShow: (state) => (id) => {
    return state.shows.find(s => s.id == id);
  },
  isLoaded: (state) => state.shows.length > 0,
  basketTotal: (state) => {
    return state.basket.length === 0 ? 0 : state.basket.reduce((a, v) => a + Number(v.currentPrice), 0);
  },
  hasTicket: (state) => (ticket) => state.basket.indexOf(ticket) > -1
};
