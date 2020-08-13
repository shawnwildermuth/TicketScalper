<template>
  <div>
    <h2>Checkout</h2>
    <div class="row">
      <div class="col-6">
        <div>Enter your payment information:</div>
        <div class="form-group">
          <label>Credit Card:</label>
          <input class="form-control" v-model="payment.creditCard" />
          <error-span :error="payment.errors['creditCard']" />
        </div>
        <label>Expiration:</label>
        <div class="form-group">
          <input class="form-control col-2 d-inline" v-model="payment.expirationMonth" />/
          <input class="form-control col-2 d-inline" v-model="payment.expirationYear" />
          <br />
          <error-span :error="payment.errors['expirationMonth']" />
          &nbsp;
          <error-span :error="payment.errors['expirationYear']" />
        </div>
        <div class="form-group">
          <label>Security Code</label>
          <input class="form-control col-4" v-model="payment.validationCode" />
          <error-span :error="payment.errors['validationCode']" />
        </div>
        <div class="form-group">
          <label>Security Code</label>
          <input class="form-control col-4" v-model="payment.postalCode" />
          <error-span :error="payment.errors['postalCode']" />
        </div>
        <button
          class="btn btn-success"
          :disabled="!payment.isValid"
          @click="processPayment()"
        >Process Payment</button>
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
import store from '@/store';
import filters from "@/filters";
import { computed, reactive, watchEffect, defineComponent } from "vue";
import router from "@/router";
import Payment from "@/models/Payment";

export default defineComponent({
  setup(props, ctx) {
    const payment = reactive(new Payment());

    const basketTotal = computed(() => store.getters.basketTotal);
    const basket = computed(() => store.state.basket);

    //watchEffect(() => payment.validate());

    async function processPayment() {
      const result = await store.dispatch("processPayment", payment);
      if (result) {
        store.commit("clearBasket");
        router.replace("/");
      }
    }

    return {
      payment,
      basket,
      basketTotal,
      processPayment,
      ...filters
    };
  }
});
</script>
