<template>
  <span v-if="error" class="text-danger">{{ error }}</span>
</template>
<script>
export default {
  props: {
    error: {
      required: true
    }
  }
}
</script>