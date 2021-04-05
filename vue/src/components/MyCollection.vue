<template>
  <div class="comic-container">
    <comic-card v-bind:comic="comic" v-for="comic in $store.state.comics" v-bind:key="comic.isbn" />  <!-- todo: bind on ID --> 
  </div>
</template>

<script>
import ComicCard from '@/components/ComicCard.vue';

export default {
    name: 'my-collection',
    components: {
        ComicCard
    }
}
</script>

<style>
.comic-container {
    display:flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>