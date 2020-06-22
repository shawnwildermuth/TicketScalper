export default {
  getShow: (state) => (id) => {
    return state.shows.find(s => s.id == id);
  },
  isLoaded: (state) => state.shows.length > 0,
  basketTotal: (state) => {
    return state.basket.length === 0 ? 0 : state.basket.reduce((a, v) => a + Number(v.price), 0);
  },
  hasTicket: (state) => (ticket) => state.basket.findIndex(t => t.id === ticket.id) > -1,
  isAuthenticated: (state) => {
    return (state.token && state.tokenExpiration >= Date.now()) ? true : false;
  },
  hasCustomer: (state) => state.customer
};
