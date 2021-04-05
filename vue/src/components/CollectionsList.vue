<template>
  <div class="my-collection-container">
    <ul>
      <li
        v-bind:collection="collection"
        v-for="collection in $store.state.collections"
        v-bind:key="collection.name"
      >
      <!-- todo: add routerlink to CollectionDisplay -->
      {{collection.name}}
      <li/>
      <!-- todo: bind on ID -->
    </ul>
  </div>
</template>

<script>

export default {
  name: "my-collection",
};
</script>

<style>

</style>