<template>
  <div>
    <h3>Shipping Information</h3>
    <div class="row">
      <div class="col-6">
        <div class="form-group">
          <label for="firstName">First Name</label>
          <input v-model="customer.firstName" class="form-control" name="firstName" />
          <error-span :error="customer.errors['firstName']"></error-span>
        </div>
        <div class="form-group">
          <label for="lastName">Last Name</label>
          <input v-model="customer.lastName" class="form-control" name="lastName" />
          <error-span :error="customer.errors['lastName']"></error-span>
        </div>
        <div class="form-group">
          <label for="phoneNumber">Phone</label>
          <input v-model="customer.phoneNumber" class="form-control" name="phoneNumber" />
          <error-span :error="customer.errors['phoneNumber']"></error-span>
        </div>
        <div class="form-group">
          <label for="companyName">Company Name</label>
          <input v-model="customer.companyName" class="form-control" name="companyName" />
          <error-span :error="customer.errors['companyName']"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="username">Email Address</label>
          <input v-model="credentials.username" class="form-control" name="username" />
          <error-span :error="credentials.errors['username']"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="password">Password</label>
          <input
            type="password"
            v-model="credentials.password"
            class="form-control"
            name="password"
          />
          <error-span :error="credentials.errors['password']"></error-span>
        </div>
        <div class="form-group" v-if="!isAuthenticated">
          <label for="confirmPassword">Confirm Password</label>
          <input
            type="password"
            v-model="credentials.confirmPassword"
            class="form-control"
            name="password"
          />
          <error-span :error="credentials.errors['confirmPassword']"></error-span>
        </div>
        <div class="form-group">
          <button
            class="btn btn-success"
            :disabled="!customer.isValid || !credentials.isValid"
            @click="upsertCustomer()"
          >Continue to Payment</button> &nbsp;
          <route-button to="/login" class-name="btn btn-secondary" v-if="!isAuthenticated">Login Instead</route-button>
        </div>
        <div>{{ customer }}</div>
        <div>{{ credentials }}</div>
      </div>
      <div class="col-6">
        <div class="form-group">
          <label for="addressLine1">Address</label>
          <input v-model="customer.addressLine1" class="form-control" name="addressLine1" />
          <error-span :error="customer.errors['addressLine1']"></error-span>
        </div>
        <div class="form-group">
          <label for="addressLine2">&nbsp;</label>
          <input v-model="customer.addressLine2" class="form-control" name="addressLine2" />
          <error-span :error="customer.errors['addressLine2']"></error-span>
        </div>
        <div class="form-group">
          <label for="addressLine3">&nbsp;</label>
          <input v-model="customer.addressLine3" class="form-control" name="addressLine3" />
          <error-span :error="customer.errors['addressLine3']"></error-span>
        </div>
        <div class="form-group">
          <label for="cityTown">City</label>
          <input v-model="customer.cityTown" class="form-control" name="cityTown" />
          <error-span :error="customer.errors['cityTown']"></error-span>
        </div>
        <div class="form-group">
          <label for="stateProvince">State</label>
          <input v-model="customer.stateProvince" class="form-control" name="stateProvince" />
          <error-span :error="customer.errors['stateProvince']"></error-span>
        </div>
        <div class="form-group">
          <label for="postalCode">Postal Code</label>
          <input v-model="customer.postalCode" class="form-control" name="postalCode" />
          <error-span :error="customer.errors['postalCode']"></error-span>
        </div>
        <div class="form-group">
          <label for="country">Country</label>
          <input v-model="customer.country" class="form-control" name="country" />
          <error-span :error="customer.errors['country']"></error-span>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { reactive, computed, watchEffect, onMounted } from "vue";
import Customer from "@/models/customer";
import NewCredentials from "@/models/newCredentials";
import _ from "lodash";
import router from "@/router";
import store from "@/store";

export default {
  setup() {
    const customer = computed(() => store.state.customer);
    const credentials = reactive(new NewCredentials());
    credentials.username = "shawn@wildermuth.com";
    credentials.password = "P@ssw0rd!";
    credentials.confirmPassword = credentials.password;

    const isAuthenticated = computed(() => store.getters.isAuthenticated);

    watchEffect(() => customer.value.validate());
    watchEffect(() => credentials.validate());

    onMounted(async () => {
      await store.dispatch("loadCustomer");
    });

    async function upsertCustomer() {
      console.log("Upserting Customer");

      if (!customer.value.isValid) {
        store.commit("setError", "Customer Form invalid.");
        return;
      }

      if (store.getters.isAuthenticated === false) {
        console.log("Saving Customer Info for new user.");
        // Store Cred
        const user = await store.dispatch("createLogin", credentials);
        if (user) {
          await store.dispatch("login", {
            username: credentials.username,
            password: credentials.password
          });
        }
      }
      // Store Customer
      if (store.getters.isAuthenticated === false) { // Only should fire if the login fails, shouldn't happen
        console.log("Login didn't work");
        store.commit("setError", "Failed to login during save");
        return;
      }

      if (await store.dispatch("saveCustomer", customer.value)) {
        router.push("/checkout");
      }
    }

    return {
      customer,
      credentials,
      isAuthenticated,
      upsertCustomer
    };
  }
};
</script>