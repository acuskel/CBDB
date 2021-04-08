<template>
  <div>
    <h1>Public comics:</h1> 
    <public-collections />
  </div>
</template>

<script>
import PublicCollections from '../components/PublicCollections.vue';
export default {
  name: 'public',
  components: {
    PublicCollections,
  },
};
</script>

<style>
</style>