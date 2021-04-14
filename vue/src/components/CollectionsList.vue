<template>
  <div class="my-collection-container">

    <ul>
      <li 
        v-on:click="setCollection"
        v-for="collection in $store.state.collections"
        v-bind:key="collection.name"
      >
      <router-link 
      v-bind:to="{ name: 'collection-display', params: {id: collection.id}}">
      {{collection.name}}
      </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "collections-list",
  data() {
    return {
      collection: {},
      collectionId: 0
    };
  },
  methods: {
    setCollection() {
      this.$store.commit('SET_COLLECTION', this.collection);
      console.log('in coll disp', this.collection)
    }
  },
  created(){
    collectionService
      .getCollections(this.$store.state.user.userId)
      .then((response) => {
        this.$store.commit("REPLACE_COLLECTIONS", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message = 
          "error: HTTP Response Code: " + error.response.data.status;
          this.message =+ " Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>

<style>

</style>