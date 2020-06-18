import createHttp from "@/services/http";

export default {
  async loadShows({ commit }) {
    try {
      commit("setBusy");
      const http = createHttp(false);
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
      const http = createHttp(false);
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
      const http = createHttp();
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
  },
  async login({ commit }, credentials){
    try {
      commit("setBusy");
      const http = createHttp(false);
      const result = await http.post("/auth/connect", credentials);
      if (result.status === 201) {
        commit("setToken", result.data);
        return true;
      }      
    } catch (error) {
      console.error(error);
    } finally {
      commit("clearBusy");
    }
    return false;
  },
  logout({commit}) {
    commit("setToken", { token: "", expiration: Date() });
  }
};
