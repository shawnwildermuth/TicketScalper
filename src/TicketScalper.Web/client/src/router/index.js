import { createRouter, createWebHashHistory } from 'vue-router';
import Views from '../views';
import store from "../store";

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Views.Home
  },
  {
    path: "/tickets/:id",
    name: "Tickets",
    component: Views.Tickets,
    props: true,
    beforeEnter(to, from, next) {
      if (store.getters.isLoaded) next();
      else next('/');
    }
  },
  {
    path: "/checkout",
    name: "Checkout",
    component: Views.Checkout,
    beforeEnter(to, from, next) {
      if (store.state.basket.length > 0) next();
      else next('/');
    }
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
