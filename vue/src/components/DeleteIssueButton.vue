<template>
  <div id="deleteButton">
    <!-- delete button only shows up if the user owns the collection. Will not show on public display if user is not owner -->
    <b-button variant="danger" v-on:click="deleteOnClick" v-show="isMine">Remove From Collection</b-button>
  </div>
</template>

<script>
import issueService from "../services/IssueService.js";
export default {
  name: "delete-issue-button",
  data() {
    return {
      myCollections: [],
      count: 0
    };
  },

  props: ["collectionId", "issueId"],
  computed: {
    //determines if user is the owner of the collection selected
  isMine() {
  if(this.myCollections.filter((c) => c.id == this.collectionId).length == 1){
    return true}
    else{
      return false}
    }
  },
 created(){
    this.myCollections =  this.$store.state.collections;
    console.log("Is mine?", this.isMine)
  },
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
#deleteButton{
  font-size: 12px;
}
</style>