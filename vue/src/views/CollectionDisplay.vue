<template>
  <div>
    <h1>List of comics in collection selected</h1> <!-- selected collection name? -->
    <issue-list />
    <add-issue v-if="$store.state.token != ''" v-bind:collectionId="collectionId" />
  </div>
</template>

<script>
import AddIssue from '../components/AddIssue.vue';
import IssueList from "../components/IssueList.vue";
export default {
  name: 'collection-display',
  components: {
    IssueList,
    AddIssue,
  },

    created() {
    this.collectionId = this.$route.params.id;
    console.log("in created", this.collectionId)
  },
data(){
  return {
    collectionId: 0,
  }
}
};
</script>

<style>
</style>