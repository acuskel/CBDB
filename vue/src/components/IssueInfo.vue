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
    <ul>
      <li
        v-for="unaddedCollection in unaddedCollections"
        v-bind:key="unaddedCollection.id"
      >
        {{ unaddedCollection.name }}
        <button type="button" class="btn btn-success" v-on:click="addToCollection(issue, unaddedCollection.id)">+</button>
      </li>
    </ul>
    <div>
      <!-- <b-form-rating v-model="value" variant="warning" class="mb-3"></b-form-rating> -->
    </div>
  </div>
</template>

<script>
import IssueService from "../services/IssueService.js"
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
    // trying to implement so the und=addedCOllections list updates
        /*updateUnaddedCollections() {
        unaddedCollections = this.$store.state.collections.filter(
      (c) => !c.issues.some((i) => i.issueId == this.issue.issueId));
      return this.unaddedCollections;
        }*/ 
  },
  methods: {
    addToCollection(issue, unaddedCollectionId){
      IssueService.addIssue(issue, unaddedCollectionId)
            .then((response) => {
          console.log("promise was success", response);
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

  },
  created() {
    console.log("store.collections", this.$store.state.collections);
    console.log("store.user", this.$store.state.user);
    // this.collection = this.$store.state.collections.find((c) => c.id == this.$route.params.id);
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

button{
  border-radius: 50%;
}

</style>