<template>
  <div>
    <p style="color:white; margin-top:40px">Create a new collection?</p>
    <form v-on:submit.prevent>
      <b-input
        class="collection-input"
        type="text"
        placeholder="Insert Collection Name"
        v-model="collection.name"
        style="max-width:300px; margin:auto "
      />
      <b-button type="submit" variant="primary" v-on:click="onSubmit()" style="margin:10px">Add Collection</b-button>


      <input type="checkbox" v-model="collection.isPublic" />
      <label for="checkbox" style="color:white; margin-left:10px">Make public?</label> 
    </form>
  </div>
</template>

<script>
import CollectionService from "../services/CollectionService.js";

export default {
  name: "add-collection",
  data() {
    return {
      collection: {
        name: "",
        userId: this.$store.state.user.userId,
        isPublic: false,
        status: 'not'
      },
    };
  },
  computed() {
    
  },

  methods: {
    onSubmit() {
      CollectionService.addCollection(this.collection)
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
    },
  },
};
</script>

<style>
</style>