<template>
  <div id="public">
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
#public{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>