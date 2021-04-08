<template>
  <div>
    <h1>List of comics in collection selected</h1>
    <!-- selected collection name? -->
    <issue-list />
    <add-issue
      v-if="allowAdd"
      v-bind:collectionId="collectionId"
    />
    <img v-else src="https://i.imgur.com/pgONM9p.png" width=500/ >
  </div>
</template>

<script>
import AddIssue from "../components/AddIssue.vue";
import IssueList from "../components/IssueList.vue";
export default {
  name: "collection-display",
  components: {
    IssueList,
    AddIssue,
  },
  computed: {
    allowAdd() {
      if((this.$store.state.token != '') && (this.$store.state.issues.length < 100)) {
        return true;
      }
      else return false;
    }
  },
  created() {
    this.collectionId = this.$route.params.id;
    console.log("in created", this.collectionId);
  },
  data() {
    return {
      collectionId: 0,
    };
  },
};
</script>

<style>
</style>