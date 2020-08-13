import { createStore } from 'vuex'
import mutations from './mutations'
import actions from './actions'
import getters from './getters'
import VuexPersistence from "vuex-persist";
import Customer from "../models/Customer";
import IState from './IState';

const vuexLocal = new VuexPersistence({
  storage: window.sessionStorage
});


export default createStore<IState>({
  strict: true,
  state: {
    shows: [],
    busy: false,
    basket: [],
    error: "",
    customer: new Customer(),
    token: "",
    tokenExpiration: 0  
  },
  mutations: mutations, 
  actions: actions,
  getters: getters,
  plugins: [vuexLocal.plugin]
})
