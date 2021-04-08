<template>
  <div class="public-collections">

    <ul>
      <li
        
        v-for="collection in $store.state.collections"
        v-bind:key="collection.name"
      >
      <!-- todo: add routerlink to CollectionDisplay -->
      <router-link v-bind:to="{ name: 'public-display', params: {id: collection.id}}">
      {{collection.name}}
      </router-link>
      </li>
      <!-- todo: bind on ID -->
    </ul>
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "public-collections",
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
      .getPublicCollections()
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