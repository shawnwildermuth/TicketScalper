<template>
  <div class="row">
    <div class="col-6 offset-3">
      <h4>Login</h4>
      <div class="form-group">
        <label for="username">Username</label>
        <input
          name="username"
          class="form-control"
          v-model="credentials.username"
          placeholder="(e.g. bob@aol.com)"
        />
        <error-span :error="errors['username']"></error-span>
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input
          name="password"
          type="password"
          class="form-control"
          v-model="credentials.password"
          placeholder="***********"
        />
        <error-span :error="errors['password']"></error-span>
      </div>
      <div class="form-group">
        <button class="btn btn-success" :disabled="!isValid" @click="login()">Login</button>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, reactive, computed } from "vue";
import Credentials from "@/models/credentials";
import router from "@/router";
import store from "@/store";

export default {
  setup() {
    const credentials = reactive(new Credentials());
    const isValid = computed(() => credentials.isValid(errors));
    const errors = ref({});

    async function login() {
      store.commit("clearError");
      let result = await store.dispatch("login", credentials);
      if (result) {
        router.push("/");
      } 
    }

    return {
      credentials,
      isValid,
      errors,
      login
    };
  }
};
</script>