<template>
  <div class="my-collections">
    <h1>My Collections</h1>
    <collections-list />
    <add-collection />
  </div>
</template>

<script>
import AddCollection from '../components/AddCollection.vue';
import CollectionsList from '../components/CollectionsList.vue';

export default {
  components: { AddCollection, CollectionsList},
  name: "my-collections"
};
</script>

<style>
.my-collections{
  background-color:rgba(26, 24, 24, 0.966);
  }

h1 {
  font-family: bebas neue;
  color:white;
}
</style>