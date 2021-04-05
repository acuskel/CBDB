<template>
  <div class="home">
    <h1>My Collection</h1>
    <my-collection />
    <collections-list />
    <add-collection />
  </div>
</template>

<script>
import AddCollection from '../components/AddCollection.vue';
import CollectionsList from '../components/CollectionsList.vue';
import MyCollection from '../components/MyCollection.vue';

export default {
  components: { MyCollection, AddCollection, CollectionsList },
  name: "home"
};
</script>
