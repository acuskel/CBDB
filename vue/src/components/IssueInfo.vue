<template>
  <div>
    <b-container id="issue-data">
      
      <b-row>
      <b-col class="text-left">
        <h1 class="title">{{ issue.seriesTitle }}</h1>
      <p class="data"><b>Creator:</b> {{ issue.creator }}</p>
      <p class="data"><b>Publisher:</b> {{ issue.publisher }}</p>
      <p class="data"><b>Publication Date:</b> {{ issue.releaseDate }}</p>
      <p class="data"><b>Page Count:</b> {{ issue.pageCount }}</p>
      <p><b>Featuring: </b>{{ issue.characters }}</p><br>
      <h3>Add to collection:</h3>
      <b-container class="addToCollection" >
      <b-row>
        <b-col ><b-button 
        variant="primary"
        v-for="unaddedCollection in unaddedCollections"
        v-bind:key="unaddedCollection.id" 
        v-on:click="addToCollection(issue, unaddedCollection.id)" v-b-tooltip.hover="'Click to add comic to collection!'"
        >{{ unaddedCollection.name }}</b-button></b-col>
        </b-row>
    </b-container>
      </b-col>
      <b-col class="text-right">
      <img v-if="issue.publisher == 'Dark Horse'" src="https://d2lzb5v10mb0lj.cloudfront.net/darkhorse/index_images/blog/blog2015/sdcc15logo.jpg">
      <img v-if="issue.publisher == 'Marvel'" width=300 src="https://logodownload.org/wp-content/uploads/2017/05/marvel-logo-0.png">
      <img v-if="issue.publisher == 'DC'" width=300 src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/DC_Comics_logo.svg/600px-DC_Comics_logo.svg.png">
      <img v-if="issue.publisher == 'Centaur'" src="https://comicvine1.cbsistatic.com/uploads/scale_small/1/19772/619139-centaur.gif">
      </b-col>
      </b-row>
      </b-container>
    <div class="summary">  
    <h1>Synopsis</h1><br>
    <p>{{ issue.summary }}</p>
    </div>
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
  color:white;
}
button{
  margin-left:-15px;
  margin-right: 30px;
  margin-top: 10px;
}

.summary {
  margin-top:80px;
  margin-bottom:80px;
}

.data {
  font-size: 18px;
}

.summary {
  font-size: 20px;
}
</style>