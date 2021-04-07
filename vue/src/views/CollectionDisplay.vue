<template>
  <div>
    <h1>List of comics in collection selected</h1> <!-- selected collection name? -->
    <issue-list />
    <add-issue />
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
};
</script>

<style>
</style>