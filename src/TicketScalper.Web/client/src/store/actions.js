import axios from "axios";

const http = axios.create({
  baseURL: "https://localhost:5001/"
});

export default {
  async loadShows({ commit }) {
    try {
      commit("setBusy");
      const result = await http.get("shows/latest");
      if (result.status === 200) {
        commit("setShows", result.data);
      }
    }
    finally {
      commit("clearBusy");
    }
  },
  async loadTickets({ commit, getters }, id) {
    try {
      commit("setBusy");
      const result = await http.get(`shows/${id}/tickets`);
      if (result.status === 200) {
        const show = getters.getShow(id);
        commit("setTicketsForShow", { show: show, tickets: result.data });
      }
    } finally {
      commit("clearBusy");
    }
  }
};
