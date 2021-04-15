<template>
  <div class="public-collections">

    <ul>
      <li
        
        v-for="publicCollection in $store.state.publicCollections"
        v-bind:key="publicCollection.name"
      >
      <!-- todo: add routerlink to CollectionDisplay -->
      <router-link v-bind:to="{ name: 'public-display', params: {id: publicCollection.id}}">
      {{publicCollection.name}}
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
    publicCollections() {
      return this.$store.state.publicCollections;
    }
  },
  created(){
    this.message = "";

    collectionService
      .getPublicCollections()
      .then((response) => {
        this.$store.commit("SET_PUBLIC_COLLECTIONS", response.data);
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
.public-collections{
  background-color:rgba(26, 24, 24, 0.966);
  padding:20px;
  }
</style>