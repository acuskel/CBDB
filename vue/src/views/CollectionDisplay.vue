<template>
  <div class="issue-list">








    <issue-list />
    <delete-collection-button v-bind:collectionId="collectionId"/>
  </div>
</template>

<script>
import DeleteCollectionButton from '../components/DeleteCollectionButton.vue';
import IssueList from "../components/IssueList.vue";
export default {
  name: "collection-display",

  data(){
    return{
      collectionId: 0,
    }
  },
  components: {
    IssueList,
    DeleteCollectionButton,
  },

  created(){
    this.collectionId = this.$route.params.id;
    console.log('reached coll disp 2', this.collectionId);
  }
  
};
</script>

<style>
.issue-list{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>