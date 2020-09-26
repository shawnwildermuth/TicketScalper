<template>
  <span v-if="model.$invalid" class="text-danger">
    <slot>{{ model.$errors[0].$message }}: {{ model.$errors[0].$property }}</slot>
  </span>
</template>
<script>
export default {
  props: {
    model: {
      required: true
    }
  }
}
</script>