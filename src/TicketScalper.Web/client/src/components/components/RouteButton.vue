<template>
  <router-link :class="className" :to="to" v-slot="{ href, route, navigate}" v-if="!disabled">
    <slot></slot>
  </router-link>
  <button :class="className" disabled v-else>
    <slot></slot>
  </button>
</template>

<script>
  export default {
    props: {
      to: {
        required: true
      },
      disabled: {
        type: Boolean,
        required: false,
        default: () => false
      },
      className: {
        type: String,
        required: false,
        default: () => "btn"
      }
    },
  }
</script>
