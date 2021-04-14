<template>
  <div id="search">
    <b-button id="prev" v-on:click="nextPage" variant="primary">Previous Page</b-button>
    <b-button id="next" v-on:click="prevPage" variant="primary">Next Page</b-button>
    <b-table-simple bordered hover small responsive=false>
      <b-thead>
        <b-tr>
          <b-th>Series Title</b-th>
          <b-th>Publisher</b-th>
          <b-th>Publication Date</b-th>
        </b-tr>
        <b-tr v-for="issue in allIssues" v-bind:key="issue.issueId">
          <b-td>
            <b-link
               :to="{
                name: 'issue-display',
                params: { id: issue.issueId },
              }"
            >
              {{ issue.seriesTitle }}
            </b-link>
          </b-td>
          <b-td>{{ issue.publisher }}</b-td>
          <b-td>{{ issue.releaseDate }}</b-td>
        </b-tr>
      </b-thead>
    </b-table-simple>
  </div>
</template>

<script>
export default {
  name: "search-issues",
  data() {
    return {
      issues: this.allIssues,
      first: 0,
      last: 40,
    }
  },
  computed: {
    firstIssue(){
      return this.first;
    },
    lastIssue(){
      return this.last;
    },
    allIssues(){
      return this.$store.state.allIssues.slice(this.firstIssue, this.lastIssue);
    }
  },
  created() {
    //this.allIssues = this.$store.state.allIssues.slice(this.firstIssue, this.lastIssue);
    console.log("Reached Search Issues", this.allIssues);
  },
  methods: {
    nextPage() {
      this.first += 40;
      this.last += 40;
      this.issues = this.allIssues;
    },
    prevPage() {
      this.first -=40;
      this.last -=40;
      this.issues = this.allIssues;
    }
  }
};
</script>

<style>
#search{
  background-color:rgba(26, 24, 24, 0.966);
  padding:20px 80px 20px 30px;
  }

#prev{
  float:left;
  margin:20px;
}

#next{
  float:right;
  margin:20px -20px 20px 20px;
}
</style>