<template>
  <div id="app">
    <wait-cursor :busy="busy"><i class="fas fa-cog fa-spin"></i> Please wait...</wait-cursor>
    <div class="alert alert-danger" v-if="error"> <i class="fas fa-exclamation-triangle"></i> {{ error }}</div>
    <Teleport to="#main-menu">
      <ul class="navbar-nav flex-grow-1">
        <li class="nav-item">
          <router-link class="nav-link" to="/">Home</router-link>
        </li>
        <li class="nav-item" v-if="!isAuthenticated">
          <router-link class="nav-link" to="/Login">Login</router-link>
        </li>
        <li class="nav-item" v-if="isAuthenticated">
          <a class="nav-link" href="#" @click="logout()">Logout</a>
        </li>
        <li class="nav-item" >{{ isAuthenticated }}</li>
      </ul>
    </Teleport>
    <router-view />
  </div>
</template>

<script>
  import store from "./store";
  import { computed } from "vue";

  export default {
    setup() {
      const busy = computed(() => store.state.busy);
      const error = computed(() => store.state.error);
      const isAuthenticated = computed(() => store.getters.isAuthenticated);

      function logout() { store.dispatch("logout"); }

      return {
        busy, 
        error,
        isAuthenticated,
        logout
      };
    }
  }
</script>

