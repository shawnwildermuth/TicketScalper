<template>
  <div id="app">
    <wait-cursor :busy="busy"><i class="fas fa-cog fa-spin"></i> Please wait...</wait-cursor>
    <div class="alert alert-danger" v-if="error"> <i class="fas fa-exclamation-triangle"></i> {{ error }}</div>
    <Teleport to="#main-menu">
      <ul class="navbar-nav flex-grow-1">
        <li class="nav-item">
          <router-link class="nav-link" to="/">Home</router-link>
        </li>
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

      return {
        busy, 
        error
      };
    }
  }
</script>

