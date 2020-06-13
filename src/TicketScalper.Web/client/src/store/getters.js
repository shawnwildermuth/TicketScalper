export default {
  getShow: (state) => (id) => {
    return state.shows.find(s => s.id == id);
  },
  isLoaded: (state) => state.shows.length > 0
};
