<template>
  <div>
    <b-container id="issue-data">
      
      <b-row>
      <b-col class="text-left">
        <h1 class="title" style="font-family:bebas neue">{{ issue.seriesTitle }}</h1>
        <br>
        <p class="data"><b class="bold"> Issue No:</b> {{ issue.issueNumber }}</p>
      <p class="data"><b class="bold">Creator:</b> {{ issue.creator }}</p>
      <p class="data"><b class="bold"> Publisher:</b> {{ issue.publisher }}</p>
      <p class="data"><b class="bold">Publication Date:</b> {{ issue.releaseDate }}</p>
      <p class="data"><b class="bold">Page Count:</b> {{ issue.pageCount }}</p>
      <p class="data"><b class="bold">Featuring: </b>{{ issue.characters }}</p><br>
      <h3 style="font-family:bebas neue">Add to collection:</h3>
      <b-container class="addToCollection" >
      <b-row>
        <b-col ><b-button 
        variant="primary"
        v-for="unaddedCollection in unaddedCollections"
        v-bind:key="unaddedCollection.id" 
        v-on:click="addToCollection(issue, unaddedCollection.id)"
        >{{ unaddedCollection.name }}</b-button></b-col>
        </b-row>
        <b-row>
          <b-form-rating v-model="value" variant="primary" class="mb-2" style="margin-top:15px;"></b-form-rating> 
        </b-row>
    </b-container>
      </b-col>
      <b-col class="text-right">
        <img v-if="issue.coverLink != ''" :src="issue.coverLink" />
        <div v-else>
      <img v-if="issue.publisher == 'Dark Horse'" src="https://d2lzb5v10mb0lj.cloudfront.net/darkhorse/index_images/blog/blog2015/sdcc15logo.jpg">
      <img v-if="issue.publisher == 'Marvel'" width=300 src="https://logodownload.org/wp-content/uploads/2017/05/marvel-logo-0.png">
      <img v-if="issue.publisher == 'DC'" width=300 src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/DC_Comics_logo.svg/600px-DC_Comics_logo.svg.png">
      <img v-if="issue.publisher == 'Centaur'" width=300 src="https://comicvine1.cbsistatic.com/uploads/scale_small/1/19772/619139-centaur.gif">
      <img v-if="issue.publisher == 'Image'" width=300 src="https://static.wikia.nocookie.net/walkingdead/images/3/3f/Image-comics-logo.png/revision/latest?cb=20180904121918">
      <img v-if="issue.publisher == 'IDW'" width=300 src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/IDW_Publishing_logo.svg/300px-IDW_Publishing_logo.svg.png">
      <img v-if="issue.publisher == 'Archie'" width=300 src="https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Archiecomicslogo.png/800px-Archiecomicslogo.png">
      <img v-if="issue.publisher == 'Boom!'" width=300 src="https://upload.wikimedia.org/wikipedia/en/e/ea/Updated_BOOM%21_logo%2C_fair_use.jpg">
      </div></b-col>
      </b-row>
      </b-container>
    <div class="summary">  
    <h1 style="font-family:bebas neue">Synopsis</h1><br>
    <p class="data">{{ issue.summary }}</p>
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
      value: 0
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
#issue-data{
  border:10px;
  border-color: white;

}
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
  font-family:'Montserrat'
}

.summary {
  font-size: 20px;
  
}

.bold{
  font-family:'Bebas neue';
  font-size: 23px;
}
</style>