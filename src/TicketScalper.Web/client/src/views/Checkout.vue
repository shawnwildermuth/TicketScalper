<template>
  <div>
    <h2>Checkout</h2>
    <div class="row">
      <div class="col-6">
        <div>Enter your payment information:</div>
        <div class="form-group">
          <label>Credit Card:</label>
          <input class="form-control" v-model="model.creditCard.$model" />
          <error-span :model="model.creditCard" />
        </div>
        <label>Expiration:</label>
        <div class="form-group">
          <input
            class="form-control col-2 d-inline"
            v-model="model.expirationMonth.$model"
          />/
          <input
            class="form-control col-2 d-inline"
            v-model="model.expirationYear.$model"
          />
          <br />
          <error-span :model="model.payment" />
        </div>
        <div class="form-group">
          <label>Security Code</label>
          <input class="form-control col-4" v-model="model.validationCode.$model" />
          <error-span :model="model.validationCode" />
        </div>
        <div class="form-group">
          <label>Security Code</label>
          <input class="form-control col-4" v-model="model.postalCode.$model" />
          <error-span :model="model.payment" />
        </div>
        <button
          class="btn btn-success"
          :disabled="model.$invalid"
          @click="processPayment()"
        >
          Process Payment
        </button>
      </div>
      <div class="col-6">
        <div>Order Summary</div>
        <table class="table table-condensed table-striped table-bordered">
          <thead>
            <tr>
              <th>Show</th>
              <th>Date</th>
              <th>Seat</th>
              <th>Price</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="t in basket" :key="t.id">
              <td>{{ t.show }}</td>
              <td>{{ dateFormat(t.date) }}</td>
              <td>{{ t.seat }}</td>
              <td>{{ moneyFormat(t.price) }}</td>
            </tr>
          </tbody>
        </table>
        <div>Total: {{ moneyFormat(basketTotal) }}</div>
        <div>{{ payment }}</div>
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import store from "@/store";
import filters from "@/filters";
import { computed, reactive, watchEffect, defineComponent } from "vue";
import router from "@/router";
import Payment from "@/models/Payment";
import { useVuelidate } from "@vuelidate/core";
import { required, numeric, minLength } from "@vuelidate/validators";
import { creditCard, length } from "@/validators";

export default defineComponent({
  setup(props, ctx) {
    const payment = reactive({} as Payment);

    const basketTotal = computed(() => store.getters.basketTotal);
    const basket = computed(() => store.state.basket);

    const rules = {
      creditCard: { required },
      expirationMonth: { required, numeric, length: length(2) },
      expirationYear: { required, numeric,  length: length(2) },
      postalCode: { required, minLength: minLength(5) },
      validationCode: { required, numeric },
    };

    const model = useVuelidate(rules, payment);

    async function processPayment(): Promise<void> {
      if (await model.value.$validate()) {
        const result = await store.dispatch("processPayment", payment);
        if (result) {
          store.commit("clearBasket");
          router.replace("/");
        }
      }
    }

    return {
      model,
      basket,
      basketTotal,
      processPayment,
      ...filters,
    };
  },
});
</script>
