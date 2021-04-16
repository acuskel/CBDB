<template>
  <div id="public-bg"><!-- selected collection name? -->
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
#public-bg{
  background-color:rgba(26, 24, 24, 0.966);
  padding-bottom: 20px;
}
</style>