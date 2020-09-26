<template>
  <div>
    <h3>Shipping Information</h3>
    <div class="row">
      <div class="col-6">
        <div class="form-group">
          <label for="firstName">First Name</label>
          <input
            v-model="model.firstName.$model"
            class="form-control"
            name="firstName"
          />
          <error-span :model="model.firstName"></error-span>
        </div>
        <div class="form-group">
          <label for="lastName">Last Name</label>
          <input
            v-model="model.lastName.$model"
            class="form-control"
            name="lastName"
          />
          <error-span :model="model.lastName"></error-span>
        </div>
        <div class="form-group">
          <label for="phoneNumber">Phone</label>
          <input
            v-model="model.phoneNumber.$model"
            class="form-control"
            name="phoneNumber"
          />
          <error-span :model="model.phoneNumber"></error-span>
        </div>
        <div class="form-group">
          <label for="companyName">Company Name</label>
          <input
            v-model="model.companyName.$model"
            class="form-control"
            name="companyName"
          />
          <error-span :model="model.companyName"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="username">Email Address</label>
          <input
            v-model="authModel.username.$model"
            class="form-control"
            name="username"
          />
          <error-span :model="authModel.username"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="password">Password</label>
          <input
            type="password"
            v-model="authModel.password.$model"
            class="form-control"
            name="password"
          />
          <error-span :model="authModel.password"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="confirmPassword">Confirm Password</label>
          <input
            type="password"
            v-model="authModel.confirmPassword.$model"
            class="form-control"
            name="password"
          />
          <error-span :model="authModel.confirmPassword"></error-span>
        </div>
        <div class="form-group">
          <button
            class="btn btn-success"
            :disabled="model.$invalid"
            @click="upsertCustomer()"
          >
            Continue to Payment
          </button>
          &nbsp;
          <route-button
            to="/login"
            class-name="btn btn-secondary"
            v-if="!isAuthenticated"
            >Login Instead</route-button
          >
        </div>
        <pre>{{ model }}</pre>
      </div>
      <div class="col-6">
        <div class="form-group">
          <label for="addressLine1">Address</label>
          <input
            v-model="model.addressLine1.$model"
            class="form-control"
            name="addressLine1"
          />
          <error-span :model="model.addressLine1"></error-span>
        </div>
        <div class="form-group">
          <label for="addressLine2">&nbsp;</label>
          <input
            v-model="model.addressLine2.$model"
            class="form-control"
            name="addressLine2"
          />
          <error-span :model="model.addressLine2"></error-span>
        </div>
        <div class="form-group">
          <label for="addressLine3">&nbsp;</label>
          <input
            v-model="model.addressLine3.$model"
            class="form-control"
            name="addressLine3"
          />
          <error-span :model="model.addressLine3"></error-span>
        </div>
        <div class="form-group">
          <label for="cityTown">City</label>
          <input
            v-model="model.cityTown.$model"
            class="form-control"
            name="cityTown"
          />
          <error-span :model="model.cityTown"></error-span>
        </div>
        <div class="form-group">
          <label for="stateProvince">State</label>
          <input
            v-model="model.stateProvince.$model"
            class="form-control"
            name="stateProvince"
          />
          <error-span :model="model.stateProvince"></error-span>
        </div>
        <div class="form-group">
          <label for="postalCode">Postal Code</label>
          <input
            v-model="model.postalCode.$model"
            class="form-control"
            name="postalCode"
          />
          <error-span :model="model.postalCode"></error-span>
        </div>
        <div class="form-group">
          <label for="country">Country</label>
          <input
            v-model="model.country.$model"
            class="form-control"
            name="country"
          />
          <error-span :model="model.country"></error-span>
        </div>
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import { ref, reactive, computed, onMounted, defineComponent, useCssVars } from "vue";
import Customer from "@/models/Customer";
import NewCredentials from "@/models/NewCredentials";
import router from "@/router";
import store from "@/store";
import { useVuelidate } from "@vuelidate/core";
import {
  required,
  email,
  requiredIf,
  minLength,
  maxLength,
  sameAs,
} from "@vuelidate/validators";
import { phone } from "@/validators";

export default defineComponent({
  setup() {
    const customer = reactive({} as Customer);
    const credentials = reactive({} as NewCredentials);

    // TESTING
    credentials.username = "shawn@wildermuth.com";
    credentials.password = "P@ssw0rd!";
    credentials.confirmPassword = credentials.password;

    const isAuthenticated = computed(() => store.getters.isAuthenticated);

    const rules = {
      firstName: { required, maxLength: maxLength(50) },
      lastName: { required, maxLength: maxLength(50) },
      phoneNumber: { required, phone },
      companyName: { required, maxLength: maxLength(50) },
      addressLine1: { required, maxLength: maxLength(50) },
      addressLine2: { maxLength: maxLength(50) },
      addressLine3: { maxLength: maxLength(50) },
      cityTown: { required, maxLength: maxLength(50) },
      stateProvince: { required, maxLength: maxLength(50) },
      postalCode: { required, minLength: minLength(5) },
      country: { maxLength: maxLength(50) },
    };

    const model = useVuelidate(rules, customer);

    onMounted(async () => {
      if (store.getters.isAuthenticated) {
        if (await store.dispatch("loadCustomer")) {
          // Shallow copy if the customer is loaded
          Object.assign(customer, store.state.customer);
        }
      }
    });

    async function upsertCustomer(): Promise<void> {
      console.log("Upserting Customer");

      if (await model.value.$validate() && (isAuthenticated.value || await authModel.value.$validate())) {
        if (store.getters.isAuthenticated === false) {
          console.log("Saving Customer Info for new user.");
          // Store Cred
          const user = await store.dispatch("createLogin", credentials);
          if (user) {
            await store.dispatch("login", {
              username: credentials.username,
              password: credentials.password,
            });
          }
        }
        // Store Customer
        if (store.getters.isAuthenticated === false) {
          // Only should fire if the login fails, shouldn't happen
          console.log("Login didn't work");
          store.commit("setError", "Failed to login during save");
          return;
        }

        if (await store.dispatch("saveCustomer", customer)) {
          router.push("/checkout");
        }
      }
    }

    let authModel: any;

    if (!isAuthenticated.value) {
      const authRules = {
        username: {
          requiredIf: requiredIf(() => !isAuthenticated.value),
          email,
        },
        password: { requiredIf: requiredIf(() => !isAuthenticated.value) },
        confirmPassword: {
          requiredIf: requiredIf(() => !isAuthenticated),
          sameAs: sameAs(credentials.password, "Password"),
        },
      };

      authModel = useVuelidate(authRules, credentials);
    }



    return {
      model,
      authModel,
      isAuthenticated,
      upsertCustomer,
    };
  },
});

</script>