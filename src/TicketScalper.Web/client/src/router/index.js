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
      if (store.state.basket.length > 0) {
        if (store.getters.isAuthenticated) {
          next();
        } else {
          next("/shipping")
        }
      }
      else next('/');
    }
  },
  {
    path: "/login",
    name: "Login",
    component: Views.Login,
    beforeEnter(to, from, next) {
      if (store.getters.isAuthenticated) next("/");
      next();
    }
  },
  {
    path: "/shipping",
    name: "Shipping",
    component: Views.Shipping,
    beforeEnter(to, from, next) {
      if (store.state.basket.length > 0) {
          next();
      } else {
        next('/');
      }
    }
  },
  {
    path: "/:catchAll(.*)",
    redirect: { name: "Home" }
  },

]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

router.afterEach((to, from) => {
  store.commit("clearError");
})

export default router
