<template>
  <h2>Tickets</h2>
  <hr/>
  <div class="row">
    <div class="col-3">
      <h4>{{ show.name }}</h4>
      <div><strong>{{ dateFormat(show.startDate) }}</strong></div>
      <div>
        <ul class="list-unstyled">
          <li v-for="a in show.acts">
            <strong>{{ a.name }}</strong>
          </li>
        </ul>
      </div>
      <div>
        <h5>{{ show.venue.name }}</h5>
        <div>ph: {{ show.venue.phone }}</div>
        <div v-if="show.venue.address1">{{ show.venue.address1 }}</div>
        <div v-if="show.venue.address2">{{ show.venue.address2 }}</div>
        <div v-if="show.venue.address3">{{ show.venue.address3 }}</div>
        <div>{{ show.venue.cityTown }}, {{ show.venue.stateProvince }}  {{ show.venue.postalCode }}</div>
        <div v-if="show.venue.country">{{ show.venue.country }}</div>
      </div>
    </div>
    <div class="col-7">
      <table class="table table-condensed table-striped table-dark table-bordered">
        <thead>
          <tr>
            <th>Seat</th>
            <th>Face Value</th>
            <th>Current Price</th>
            <th>Include</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="t in show.tickets">
            <td>{{ t.seat }}</td>
            <td>{{ moneyFormat(t.originalPrice) }}</td>
            <td>{{ moneyFormat(t.currentPrice) }}</td>
            <td>
              <button class="btn btn-sm btn-success" @click="addTicket(t)" v-if="!isPicked(t)">Add</button>
              <button class="btn btn-sm btn-danger" @click="removeTicket(t)" v-if="isPicked(t)">Remove</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="col-2">
      <div>Total: {{ moneyFormat(total) }}</div>
      <div><route-button to="/checkout" className="btn btn-success" :disabled="!allowCheckout">Checkout</route-button></div>

    </div>
  </div>
</template>

<script>
  import store from "../store";
  import { computed, onMounted, reactive } from "vue";
  import filters from "../filters";

  export default {
    props: [ "id" ],
    setup(props) {
      const show = computed(() => store.getters.getShow(props.id));
      const allowCheckout = computed(() => {
        console.log(`Basket: ${store.getters.basketTotal}`);
        return store.getters.basketTotal > 0;
      });
      const total = computed(() => store.getters.basketTotal);
      onMounted(() => store.dispatch("loadTickets", props.id));

      function addTicket(ticket) {
        store.commit("addToBasket", ticket);
      };

      function removeTicket(ticket) {
        store.commit("removeFromBasket", ticket);
      };

      function isPicked(ticket) {
        return store.getters.hasTicket(ticket);
      }


      return {
        show,
        total, 
        allowCheckout,
        addTicket,
        removeTicket,
        isPicked,
        ...filters,
      };
    }
  }
</script>