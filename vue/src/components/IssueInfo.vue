<template>
  <div>
    <div id="issue-data">
      <h1>{{ issue.title }}</h1>
      <h3>Title: {{ issue.seriesTitle }}</h3>
      <h3>Creator: {{ issue.creator }}</h3>
      <h3>Publisher: {{ issue.publisher }}</h3>
      <h3>Characters: {{ issue.characters }}</h3>
      <h3>Summary: {{ issue.summary }}</h3>
      <h3>Publication Date: {{ issue.releaseDate }}</h3>
      <h3>Page Count: {{ issue.pageCount }}</h3>
    </div>
        <h1>Add to Collection:</h1>
        <b-button 
        variant="primary"
        v-for="unaddedCollection in unaddedCollections"
        v-bind:key="unaddedCollection.id" 
        v-on:click="addToCollection(issue, unaddedCollection.id)">{{ unaddedCollection.name }}</b-button>
    <div>
      <!-- <b-form-rating v-model="value" variant="warning" class="mb-3"></b-form-rating> -->
    </div>
  </div>
</template>

<script>
import IssueService from "../services/IssueService.js";
import collectionService from "../services/CollectionService.js";

export default {
  name: "issue-info",
  data() {
    return {
      message: "",
      issueId: 0,
      collection: {},
      issue: {},
      issues: [],
      unaddedCollections: [],
    };
  },
  computed: {
  },
  methods: {
    addToCollection(issue, unaddedCollectionId){
      IssueService.addIssue(issue, unaddedCollectionId)
            .then((response) => {
          console.log("promise was success", response);
          this.updateUnaddedCollections(unaddedCollectionId)
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
    setCollection() {
      this.$store.commit("SET_COLLECTION", this.collection);
    },
    updateUnaddedCollections(unaddedCollectionId){
         this.unaddedCollections = this.unaddedCollections.filter(
      (c) => c.id != unaddedCollectionId);
    }

  },
  created() {
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
      });
    this.issueId = this.$route.params.id;
    this.issue = this.$store.state.allIssues.find(
      (i) => i.issueId == this.issueId
    );
    //console.log(this.issue)

    this.unaddedCollections = this.$store.state.collections.filter(
      (c) => !c.issues.some((i) => i.issueId == this.issue.issueId)
    );
  },
};
</script>

<style scoped>
div {
  background-color: white;
}
button{
  margin:5px;
}

</style>