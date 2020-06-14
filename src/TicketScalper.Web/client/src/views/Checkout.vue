<template>
  <h2>Checkout</h2>
  <div class="row">
    <div class="col-6">
      <div>Enter your payment information:</div>
      <div class="form-group">
        <label>Credit Card:</label>
        <input class="form-control" v-model="payment.creditCard" />
        <span v-if="errors['creditCard']"  class="text-danger">{{ errors['creditCard'] }}</span>
      </div>
      <label>Expiration:</label>
      <div class="form-group">
        <input class="form-control col-2  d-inline" v-model="payment.expirationMonth" />/
        <input class="form-control col-2  d-inline" v-model="payment.expirationYear" />
        <br/>
        <span v-if="errors['expirationMonth']" class="text-danger">{{ errors['expirationMonth'] }}</span>&nbsp;
        <span v-if="errors['expirationYear']"  class="text-danger">{{ errors['expirationYear'] }}</span>
      </div>
      <div class="form-group">
        <label>Security Code</label>
        <input class="form-control col-4" v-model="payment.validationCode" />
        <span v-if="errors['validationCode']"  class="text-danger">{{ errors['validationCode'] }}</span>
      </div>
      <div class="form-group">
        <label>Security Code</label>
        <input class="form-control col-4" v-model="payment.postalCode" />
        <span v-if="errors['postalCode']" class="text-danger">{{ errors['postalCode'] }}</span>
      </div>
      <button class="btn btn-success" :disabled="!paymentValid" @click="processPayment()">Process Payment</button>
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
          <tr v-for="t in basket">
            <td>{{ t.show }}</td>
            <td>{{ dateFormat(t.date) }}</td>
            <td>{{ t.seat }}</td>
            <td>{{ moneyFormat(t.price) }}</td>
          </tr>
        </tbody>
      </table>
      <div>
        Total: {{ moneyFormat(basketTotal) }}
      </div>
      <div>{{ JSON.stringify(errors) }}</div>
    </div>
  </div>
</template>
<script>
  import store from "@/store";
  import filters from "@/filters";
  import { computed, ref, reactive } from "vue";
  import router from "@/router";
  import Payment from "@/models/payment";

  export default {
    setup(props, ctx) {
      const basket = computed(() => store.state.basket);
      const payment = reactive(new Payment("4444444444444444", "10", "2025", "30303", "123"));
      const paymentValid = computed(() => payment.isValid(errors));
      const basketTotal = computed(() => store.getters.basketTotal);
      const errors = reactive({});

      async function processPayment() {
        const result = await store.dispatch("processPayment", payment);
        if (result) {
          router.replace("/");
        }
      };

      return {
        errors, 
        payment,
        basket,
        basketTotal,
        paymentValid,
        processPayment,
        ...filters
      }
    }
  }
</script>
