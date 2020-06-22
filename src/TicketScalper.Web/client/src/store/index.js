import { createStore } from "vuex";
import mutations from "./mutations";
import actions from "./actions";
import getters from "./getters";
import VuexPersistence from "vuex-persist";

const vuexLocal = new VuexPersistence({
  storage: window.sessionStorage
});

export default createStore({
  strict: true,
  state: {
    shows: [],
    busy: false,
    basket: [],
    error: "",
    customer: null,
    token: "",
    tokenExpiration: Date()
  },
  mutations,
  actions,
  getters,
  plugins: [vuexLocal.plugin]
});