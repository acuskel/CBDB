<template>
  <div class="my-collection-container">
    <ul>
      <li
        
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
import collectionService from "../services/CollectionService.js";
export default {
  name: "my-collection",
  data() {
    return {
      message: "",
    };
  },
  computed: {
    collections() {
      return this.$store.state.collections;
    }
  },
  created(){
    this.message = "";

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