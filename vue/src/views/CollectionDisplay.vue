<template>
  <div>
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
html, 
body {
    background-color: lightgray;
}
</style>