<template>
  <div class="row">
    <h3>Available Shows</h3>
    <div class="col-12">
      <table class="table table-condensed table-striped table-bordered">
        <thead class="thead-dark">
          <tr>
            <th>Show</th>
            <th>Acts</th>
            <th>Date</th>
            <th>Venue</th>
            <th>Sold Out?</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="s in shows" >
            <td>{{ s.name }}</td>
            <td>
              <span v-for="a in s.acts">{{ a.name }}<br/></span>
            </td>
            <td>{{ dateFormat(s.startDate) }}</td>
            <td>{{ s.venue.name }}</td>
            <td>{{ s.soldOut ? "Sold Out" : "Tickets Available" }}</td>
            <td>
              <route-button className="btn btn-sm btn-primary" :disabled="s.soldOut" :to="`/tickets/${s.id}`">Buy</route-button>
            </td>
          </tr>
        </tbody>
        
      </table>
    </div>
  </div>
</template>

<script>
  import store from "../store";
  import { onMounted, computed } from "vue";
  import filters from "../filters";

  export default {
    name: 'Home',
    setup() {

      let shows = computed(() => store.state.shows);
      onMounted(() => store.dispatch("loadShows"));

      return {
        shows,
        ...filters,
      };
    }
  }
</script>
