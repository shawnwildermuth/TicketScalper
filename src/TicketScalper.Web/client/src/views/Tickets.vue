<template>
  <h3>Tickets</h3>
  <div class="row">
    <div class="col-6">
      <div>{{ show.name }}</div>
      <div>
        <div>Acts:</div>
        <ul>
          <li v-for="a in show.acts">
            {{ a.name }}
          </li>
        </ul>
      </div>
      <div>Date: {{ dateFormat(show.startDate) }}</div>
      <div>
        <div>{{ show.venue.name }}</div>
        <div>ph: {{ show.venue.phone }}</div>
        <div v-if="show.venue.address1">{{ show.venue.address1 }}</div>
        <div v-if="show.venue.address2">{{ show.venue.address2 }}</div>
        <div v-if="show.venue.address3">{{ show.venue.address3 }}</div>
        <div>{{ show.venue.cityTown }}, {{ show.venue.stateProvince }}  {{ show.venue.postalCode }}</div>
        <div v-if="show.venue.country">{{ show.venue.country }}</div>
      </div>
    </div>
    <div class="col-6">
      <table class="table table-condensed table-striped table-dark table-bordered">
        <thead>
          <tr>
            <th>Seat</th>
            <th>Current Price</th>
            <th>Face Value</th>
            <th>Include</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="t in show.tickets">
            <td>{{ t.seat }}</td>
            <td>{{ moneyFormat(t.currentPrice) }}</td>
            <td>{{ moneyFormat(t.originalPrice) }}</td>
            <td>
              <button class="btn btn-sm btn-success" @click="addTicket(t)" v-if="!isPicked(t)">Add</button>
              <button class="btn btn-sm btn-danger" @click="removeTicket(t)" v-if="isPicked(t)">Remove</button>
            </td>
          </tr>
        </tbody>
      </table>

      <div>Total: {{ moneyFormat(total) }}</div>
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
      const picked = reactive([]);
      onMounted(() => store.dispatch("loadTickets", props.id));

      function addTicket(ticket) {
        let index = picked.indexOf(ticket);
        if (index === -1) picked.push(ticket);
      };

      function removeTicket(ticket) {
        let index = picked.indexOf(ticket);
        if (index > -1) picked.splice(index, 1);
      };

      function isPicked(ticket) {
        return picked.indexOf(ticket) > -1;
      }

      const total = computed(() => picked.length === 0 ? 0 : picked.reduce((a, v) => a + Number(v.currentPrice), 0));

      return {
        show,
        total, 
        picked,
        addTicket,
        removeTicket,
        isPicked,
        ...filters,
      };
    }
  }
</script>