import { createStore } from "vuex";
import axios from "axios";

const http = axios.create({
  baseURL: "https://localhost:5001/"
});

const state = {
  shows: [], 
  busy: false
};

const mutations = {
  setShows(state, shows) {
    state.shows = shows;
  },
  setBusy(state) {
    state.busy = true;
  },
  clearBusy(state) {
    state.busy = false;
  }
}

const actions = {
  async loadShows({ commit }) {
    try {
      commit("setBusy");
      const result = await http.get("shows/latest");
      if (result.status === 200) {
        commit("setShows", result.data);
      }
    } finally {
      commit("clearBusy");
    }
  }
}

export default createStore({
  strict: true,
  state,
  mutations,
  actions
});