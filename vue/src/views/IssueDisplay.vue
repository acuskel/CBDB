<template>
  <div>
    <div>
      <h1>{{unaddedCollections}}</h1>
      <h1>{{this.$store.state.issues}}</h1>
      <h2>{{ issue }}</h2>
      <h1>{{ issue.title }}</h1>
      <h3>{{ issue.seriesTitle }}</h3>
      <h3>Issue Number: {{ issue.issueNumber }}</h3>
      <h3>{{ issue.creator }}</h3>
      <h3>{{ issue.publisher }}</h3>
      <h3>Genre: {{ issue.genre }}</h3>
      <h3>Publication Date: {{ issue.releaseDate }}</h3>
      <h3>Pages: {{ issue.pageCount }}</h3>
    </div>
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "issue-display",
    created() {
    this.issueId = this.$route.params.id;
    console.log("in created", this.issueId);
    console.log(this.$store.state.issues)

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
      })

      .getIssues(this.issueId)
      .then((response) => {
        this.$store.commit("REPLACE_ISSUES", response.data);
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

  data() {
    return {
      message: "",
      issueId: 0
    };
  },
  computed: {
    issue() {
      return this.$store.state.issues.find(
        (i) => i.issueId == this.issueId
      );
    },
    
    //returns array of collections the issue has not been added to
    unaddedCollections(){
      return this.$store.state.collections.filter(
        (c) => !c.issues.some(i => i.issueId == this.issue.issueId)
      )
    }
  },
};
</script>

<style>
</style>