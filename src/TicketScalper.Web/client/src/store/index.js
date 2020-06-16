import { createStore } from "vuex";
import mutations from "./mutations";
import actions from "./actions";
import getters from "./getters";

export default createStore({
  strict: true,
  state: {
    shows: [],
    busy: false,
    basket: [],
    error: ""
  },
  mutations,
  actions,
  getters,
  token: "",
  tokenExpiration: Date()
});