<template>
  <div class="home">
    <h1>My Collection</h1>
    <collections-list />
    <add-collection />
  </div>
</template>

<script>
import AddCollection from '../components/AddCollection.vue';
import CollectionsList from '../components/CollectionsList.vue';


export default {
  components: { AddCollection, CollectionsList },
  name: "home"
};
</script>
