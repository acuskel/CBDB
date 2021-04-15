<template>
  <div>
    <b-button variant="danger" v-on:click="deleteOnClick">Remove From Collection</b-button>
  </div>
</template>

<script>
import issueService from "../services/IssueService.js";
export default {
  name: "delete-issue-button",
  data() {
    return {

    };
  },

  props: ["collectionId", "issueId"],

  methods: {

    deleteOnClick() {
      issueService
        .deleteIssueFromCollection(this.collectionId, this.issueId)
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

<style scoped>

</style>