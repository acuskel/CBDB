<template>
  <div class="issue-list">
    <issue-list />
    <delete-collection-button />
  </div>
</template>

<script>
import DeleteCollectionButton from '../components/DeleteCollectionButton.vue';
import IssueList from "../components/IssueList.vue";
export default {
  name: "collection-display",
  components: {
    IssueList,
    DeleteCollectionButton,
  },
};
</script>
<<<<<<< HEAD
<style>
html, 
body {
    background-color: lightgray;
}
=======

<style>
.issue-list{
  background-color:rgba(26, 24, 24, 0.966);
  }
>>>>>>> 88c473f5d3019d6fe57bd7cb8bce43bdede26065
</style>