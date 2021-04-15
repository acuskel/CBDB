<template>
  <div class="my-collection-container" style="margin: 10px 40px" >
    <b-card-group deck>
      <!--  <b-card
        border-variant="primary"
        header="Primary"
        header-bg-variant="primary"
        header-text-variant="white"
        align="center"
        footer="Card Footer"
    footer-tag="footer"
    :footer-bg-variant="isPublic"
    title="Title"
    style="max-width: 20rem;"
      > 
        <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
      </b-card> -->
<!-- collection image    :img-src="collection.coverLink"  -->
      <b-card
       :img-src="collection.coverLink"
    img-alt="Image"
    img-top
    :title="collection.name"
        v-for="collection in $store.state.collections"
        v-bind:key="collection.name"
        border-variant="outline-primary"
        align="center"
        :footer="publicorPrivate(collection.isPublic)"
    footer-tag="footer"
    :footer-bg-variant="isPublic(collection.isPublic)"
    header-text-variant="white"
        
style="max-width: 30rem; min-width:300px; max-width:365px; margin: 10px"
min-cols = 3   
      >
        

        <b-button :to="{
            name: 'collection-display',
            params: { id: collection.id }}" variant="primary" style="vertical-align: middle; min-width:90%">View Collection</b-button>
            <b-button :to="{
            name: 'collection-display',
            params: { id: collection.id }}" variant="warning" style="vertical-align: middle; min-width:90%; margin-top: 10px">Delete Collection</b-button>
      </b-card>
    </b-card-group>

   <!-- <ul>
      <li
        v-on:click="setCollection"
        v-for="collection in $store.state.collections"
        v-bind:key="collection.name"
      >
        <router-link
          v-bind:to="{
            name: 'collection-display',
            params: { id: collection.id },
          }"
        >
          {{ collection.name }}
        </router-link>
      </li>
    </ul> -->
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "collections-list",
  data() {
    return {
      collection: {},
      collectionId: 0,
    };
  },
  methods: {
    setCollection() {
      this.$store.commit("SET_COLLECTION", this.collection);
      console.log("in coll disp", this.collection);
    },
    isPublic(bool){
      if(bool){
        return 'success';
      }
      else return 'danger'
    },
    publicorPrivate(bool){
      if(bool){
        return 'Public';
      }
      else return 'Private'
    }
  },
  created() {
    collectionService
      .getCollections(this.$store.state.user.userId)
      .then((response) => {
        this.$store.commit("REPLACE_COLLECTIONS", response.data);
        console.log("in coll list", this.$store.state.collections);
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "error: HTTP Response Code: " + error.response.data.status;
          this.message = +" Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>

<style>
</style>