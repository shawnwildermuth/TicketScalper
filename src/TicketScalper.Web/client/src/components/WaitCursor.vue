<template>
  <div>
    <div class="alert alert-primary" v-if="busy">
      <slot></slot>
    </div>
  </div>
</template>

<script>
  export default {
    props: {
      busy: Boolean
    }
  }
</script>