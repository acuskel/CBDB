<template>
  <div>
    <form v-on:submit.prevent>
      <input
        class="collection-input"
        type="text"
        placeholder="Insert Collection Name"
        v-model="collection.name"
      />
      <button type="submit" v-on:click="onSubmit()">Add Collection</button>
    </form>
  </div>
</template>

<script>
import CollectionService from "../services/CollectionService.js"

export default {
  name: "add-collection",
  data() {
    return {
      collection: {
        name: "",
        userId: this.$store.state.user.userId
      },
    };
  },

  methods: {
    onSubmit(){
      CollectionService
      .addCollection(this.collection)
      .then((response) => {
          console.log("promise was success", response);
          this.$router.go(0); 
        })
        .catch((error) => {
         
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
    }
    },
};
</script>

<style>
</style>