import { createRouter, createWebHashHistory } from 'vue-router';
import Home from '../views/Home';
import Tickets from "../views/Tickets";
import store from "../store";

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: "/tickets/:id",
    name: "Tickets",
    component: Tickets,
    props: true,
    beforeEnter(to, from, next) {
      if (store.getters.isLoaded) next();
      else next('/');
    }
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
