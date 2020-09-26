<template>
  <div class="row">
    <div class="col-6 offset-3">
      <h4>Login</h4>
      <div class="form-group">
        <label for="username">Username</label>
        <input
          name="username"
          class="form-control"
          v-model="model.username.$model"
          placeholder="(e.g. bob@aol.com)"
        />
        <error-span :model="model.username">Username is required.</error-span>
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input
          name="password"
          type="password"
          class="form-control"
          v-model="model.password.$model"
          placeholder="***********"
        />
        <error-span :model="model.password"></error-span>
      </div>
      <div class="form-group">
        <button
          class="btn btn-success"
          :disabled="model.$invalid"
          @click="login()"
        >
          Login
        </button>
      </div>
      <pre>{{ model }}</pre>
    </div>
  </div>
</template>

<script lang="ts">
import {
  ref,
  reactive,
  computed,
  watchEffect,
  defineComponent,
  useCssVars,
} from "vue";
import Credentials from "@/models/Credentials";
import router from "@/router";
import store from "@/store";
import { useVuelidate } from "@vuelidate/core";
import { required } from "@vuelidate/validators";

export default defineComponent({
  setup() {
    const credentials = reactive({} as Credentials);

    const rules = {
      username: { required },
      password: { required },
    };

    const model = useVuelidate(rules, credentials);

    async function login() {
      if (await model.value.$validate()) {
        store.commit("clearError");
        let result = await store.dispatch("login", credentials);
        if (result) {
          // Load customer if possible
          await store.dispatch("loadCustomer");
          router.push("/");
        }
      }
    }

    return {
      model,
      login,
    };
  },
});
</script>