import axios from "axios";
const http = axios.create({
  baseURL: "https://localhost:5999/"
});

export default {
  async loadShows({ commit }) {
    try {
      commit("setBusy");
      const result = await http.get("shows/latest");
      if (result.status === 200) {
        commit("setShows", result.data);
      }
    } catch (e) {
      commit("setError", "Could not load shows")
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
    } catch (e) {
      commit("setError", "Failed to load tickets")
    } finally {
      commit("clearBusy");
    }
  },
  async processPayment({ state, commit }, payment) {
    try {
      commit("setBusy");
      const result = await http.post("customer/1/sales", {
        creditCard: payment.creditCard,
        expirationMonth: payment.expirationMonth,
        expirationYear: payment.expirationYear,
        validationCode: payment.validationCode,
        postalCode: payment.postalCode,
        ticketIds: state.basket.reduce(t => t.id)
      });

      if (result.status === 201) {
        return true;        
      }
    } catch (e) {
      commit("setError", "Could not process payment")
    } finally {
      commit("clearBusy");
    }
    return false;
  }
};
