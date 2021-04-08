<template>
  <div>
    <h1>List of comics in collection selected</h1> <!-- selected collection name? -->
    <issue-list />
  </div>
</template>

<script>
import IssueList from "../components/IssueList.vue";
export default {
  name: 'public-display',
  components: {
    IssueList,
  },
};
</script>

<style>
</style>