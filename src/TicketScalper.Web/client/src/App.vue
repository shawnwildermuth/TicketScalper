<template>
  <div id="app">
    <wait-cursor :busy="busy"><i class="fas fa-gear fa-spin"></i> Please wait...</wait-cursor>
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
  import WaitCursor from "./components/WaitCursor";

  export default {
    setup() {
      const busy = computed(() => store.state.busy);

      return {
        busy
      };
    },
    components: { WaitCursor }
  }
</script>

