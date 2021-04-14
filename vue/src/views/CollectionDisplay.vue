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
<style>
.issue-list{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>