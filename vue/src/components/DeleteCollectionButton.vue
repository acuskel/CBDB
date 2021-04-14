<template>
  <div>
    <button v-on:click="deleteOnClick">Delete Collection</button>
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "delete-collection-button",
  data() {
    return {
      collection: {},
    };
  },

  created() {
    this.collection = this.$store.state.collection;
    console.log("in delete button created", this.collection);
  },
  methods: {
    deleteOnClick() {
      collectionService
        .deleteCollection(this.collection.id)
        .then((response) => {
          console.log("promise was success", response);
          this.$store.commit("SET_COLLECTION", {});
          this.$router.push("collection-display");
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
    },
  },
};
</script>

<style>
</style>