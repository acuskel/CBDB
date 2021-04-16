<template>
  <div class="my-collection-container" style="padding-bottom:50px">
    <b-card-group deck style="margin: auto;">
      <b-card
      class="text-center"
        :img-src="publicCollection.coverLink"
        img-alt="Image"
        img-top
        v-for="publicCollection in $store.state.publicCollections"
        v-bind:key="publicCollection.name"
        border-variant="outline-primary"
        align="center"
        :footer="'Owner: ' + userIdToUser(publicCollection.userId)"
        footer-tag="footer"
        footer-bg-variant=dark
        header-text-variant="white"
        footer-text-variant="white"
        style="
          max-width: 30rem;
          min-width: 300px;
          max-width: 365px;
          margin: 10px;
        "
        min-cols="3"
      >
        <b-card-title
          style="
            font-weight: bold;
            font-family: bebas neue;
            font-size: 40px;
            margin-bottom: 20px;
          "
          >{{ publicCollection.name }}</b-card-title
        >

        <b-button
          :to="{
            name: 'public-display',
            params: { id: publicCollection.id },
          }"
          variant="primary"
          style="vertical-align: middle; min-width: 90%"
          >View Collection</b-button
        >
      </b-card>
    </b-card-group>

    <!-- <ul>
      <li
        v-for="publicCollection in $store.state.publicCollections"
        v-bind:key="publicCollection.name"
      >
       
        <router-link
          v-bind:to="{
            name: 'public-display',
            params: { id: publicCollection.id },
          }"
        >
          {{ publicCollection.name }}
        </router-link>
      </li>
    </ul> -->
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
  created() {
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
          this.message = +" Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
  methods: {
    isPublic(bool) {
      if (bool) {
        return "success";
      } else return "dark";
    },
    publicorPrivate(bool) {
      if (bool) {
        return "Public";
      } else return "Private";
    },
    
    userIdToUser(userId) {
      if (userId == 1) {
        return "amanda1993"
      }
      else if (userId == 2) {
        return "RJ2000"
      }
      else if (userId== 3) {
        return "joshkwood"
      }
      else if (userId == 4) {
        return "acuskelly"
      }
      else if (userId == 5) {
        return "anonymous"
      }
      else if (userId == 6) {
        return "anonymous"
      }
      else return 'anonymous'
    },
  },
};
</script>

<style>
.my-collection-container{

}
.public-collections {
  padding: 20px;
}
</style>