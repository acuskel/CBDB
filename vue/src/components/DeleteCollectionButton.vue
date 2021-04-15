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

  props: ['collectionId'],

  methods: {
    deleteOnClick() {
      collectionService
        .deleteCollection(this.collectionId)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({name: 'my-collections'});
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