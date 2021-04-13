<template>
  <div>
      <b-table v-bind:key="issue.issueId" v-for="issue in allIssues"></b-table>
  </div>
</template>

<script>
export default {
    name: "search-issues",
    data(){
        return{
            allIssues: []
        }
    },
    created(){
        this.allIssues = this.$store.state.allIssues;
        console.log(this.allIssues.length);
        console.log(this.allIssues)
    }
}
</script>

<style>

</style>