<template>
  <div class="issue-list">
    <issue-list />
  </div>
</template>

<script>
import IssueList from "../components/IssueList.vue";
export default {
  name: "collection-display",
  components: {
    IssueList,
  },
};
</script>

<style>
.issue-list{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>