import createHttp from "@/services/http";
import Customer from "@/models/customer";

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
      if (!(state.customer.id)) {
        commit("setError", "Customer is invalid");
        return false;
      }
      commit("setBusy");
      const http = createHttp();
      const result = await http.post(`customers/${state.customer.id}/sales/ticketrequest`, {
        creditCard: payment.creditCard,
        expirationMonth: Number(payment.expirationMonth),
        expirationYear: Number(payment.expirationYear),
        validationCode: payment.validationCode,
        postalCode: payment.postalCode,
        ticketIds: state.basket.map(t => Number(t.id))
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
      commit("setError", error);
    } finally {
      commit("clearBusy");
    }
    return false;
  },
  async loadCustomer({ commit }){
    try {
      commit("setBusy");
      const http = createHttp();
      const result = await http.get("/customers");
      if (result.status === 200) {
        commit("setCustomer", new Customer(result.data));
        return true;
      }      
    } catch (error) {
      commit("setError", error);
    } finally {
      commit("clearBusy");
    }
    return false;
  },
  logout({commit}) {
    commit("setToken", { token: "", expiration: Date() });
  },
  async createLogin({commit, dispatch}, credentials) {
    try {
      commit("setBusy");
      const http = createHttp(false);
      const result = await http.post("/auth/users", credentials);
      if (result.status === 201) {
          return result.data;
      } else {
        commit("setError", "Failed to create user.");
      }     
    } catch (error) {
      commit("setError", error);
    }
    finally
    {
      commit("clearBusy");
    }
    return undefined;
  },
  async saveCustomer({state, commit}, cust) {
    try {
      commit("setBusy");
      const http = createHttp();
      let result;
      if (cust.id === 0) { // new
        result = await http.post("/customers", cust);
      } else {
        result = await http.put(`/customers/${cust.id}`, cust);
      }
      if (result.status === 201 || result.status === 200) {
        commit("setCustomer", result.data);
        return true;
      }      
    } catch (error) {
      commit("setError", error);
    }
    finally
    {
      commit("clearBusy");
    }
    return undefined;
  }
};
