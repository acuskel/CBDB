<template>
  <div>
      <h1>Search</h1>
      <b-table-simple striped hover>
          <b-thead>
              <b-tr>
                  <b-th>Series Title</b-th>
                  <b-th>Publication Date</b-th>
              </b-tr>
              <b-tr v-for="issue in allIssues" v-bind:key="issue.issueId">
                  <b-td>{{issue.seriesTitle}}</b-td>
                  <b-td>{{issue.releaseDate}}</b-td>
                  </b-tr>
          </b-thead>
      </b-table-simple>
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