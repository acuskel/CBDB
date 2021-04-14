<template>
  <div id="issue-display">
    <issue-info />
  </div>
</template>

<script>
import IssueInfo from "../components/IssueInfo";

export default {
  name: "issue-display",
  components: { IssueInfo }
}
</script>

<style>
#issue-display{
  background-color:rgba(26, 24, 24, 0.966);
  padding:50px;
  }
</style>