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
        <error-span :error="credentials.errors['username']"></error-span>
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
        <error-span :error="credentials.errors['password']"></error-span>
      </div>
      <div class="form-group">
        <button class="btn btn-success" :disabled="!(credentials.isValid)" @click="login()">Login</button>
        <div>{{ credentials }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, reactive, computed, watchEffect } from "vue";
import Credentials from "@/models/credentials";
import router from "@/router";
import store from "@/store";

export default {
  setup() {
    const credentials = reactive(new Credentials());
    watchEffect(() => credentials.validate());
    
    async function login() {
      store.commit("clearError");
      let result = await store.dispatch("login", credentials);
      if (result) {
        router.push("/");
      } 
    }

    return {
      credentials,
      login
    };
  }
};
</script>