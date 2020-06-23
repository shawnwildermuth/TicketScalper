import { createStore } from "vuex";
import mutations from "./mutations";
import actions from "./actions";
import getters from "./getters";
import VuexPersistence from "vuex-persist";
import Customer from "../models/customer";

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
    customer: new Customer(),
    token: "",
    tokenExpiration: Date()
  },
  mutations,
  actions,
  getters,
  plugins: [vuexLocal.plugin]
});