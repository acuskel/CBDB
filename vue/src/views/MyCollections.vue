<template>
  <div class="my-collections">
    <h1>Collections</h1>
    <collections-list />
    <add-collection />
    <aggregate-stats/>
  </div>
</template>

<script>
import AddCollection from '../components/AddCollection.vue';
import CollectionsList from '../components/CollectionsList.vue';
import AggregateStats from '../components/AggregateStats.vue';

export default {
  components: { AddCollection, CollectionsList, AggregateStats},
  name: "my-collections"
};
</script>
