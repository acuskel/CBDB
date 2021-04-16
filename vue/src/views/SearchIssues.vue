<template>
  <div id="searchBar">
    <div id="search">
      <b-container>
        <b-row>
          <b-col>
            <b-form-input
              size="sm"
              class="mr-sm-2"
              placeholder="Search"
              v-model="searchText"
              style="margin-left: -20px"
            ></b-form-input>
          </b-col>
          <b-col>
            <b-button
              v-on:click="getSearch"
              variant="success"
              style="float: left; margin-left: -40px; font-size: 0.6em"
              >🔍</b-button
            >
          </b-col><b-col><h4 style="color:white">Results: {{ searchResults.length }}    <span style="margin-left:20px; margin-right:-250px"> Current Page:
        {{ currentPage }}</span></h4></b-col></b-row>
      </b-container>
    </div>
    <div class="prevNext">
      <b-button
        id="prev"
        v-on:click="prevPage"
        variant="primary"
        v-show="currentPage > 1"
        >Previous Page</b-button
      > 
      <b-button
        id="next"
        v-on:click="nextPage"
        variant="primary"
        v-show="searchResults.length > lastIssue"
        >Next Page</b-button
      >
    </div>
    <b-table-simple bordered hover small responsive="false">
      <b-thead>
        <b-tr>
          <b-th>Series Title</b-th>
          <b-th>Issue No.</b-th>
          <b-th>Publisher</b-th>
          <b-th>Publication Date</b-th>
          <b-th>Creator</b-th>
        </b-tr>
        <b-tr v-for="issue in IssuesDisplayed" v-bind:key="issue.issueId">
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
          <b-td>{{ issue.issueNumber }}</b-td>
          <b-td>{{ issue.publisher }}</b-td>
          <b-td>{{ issue.releaseDate }}</b-td>
          <b-td>{{ issue.creator }}</b-td>
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
      first: 0,
      last: 39,
      currentPage: 1,
      searchText: "",
      searchResults: [],
    };
  },
  computed: {
    firstIssue() {
      return this.first;
    },
    lastIssue() {
      return this.last;
    },
    IssuesDisplayed() {
      return this.searchResults.slice(this.firstIssue, this.lastIssue);
    },
  },
  created() {
    this.allIssues = this.$store.state.allIssues;
    this.searchResults = this.allIssues;
    console.log("seachIssues", this.searchResults);
  },
  methods: {
    nextPage() {
      this.first += 40;
      this.last += 40;
      this.currentPage += 1;
      console.log("first", this.first);
      console.log("last", this.last);
      console.log("issue", this.issues);
    },
    prevPage() {
      this.first -= 40;
      this.last -= 40;
      this.currentPage -= 1;
      this.issues = this.IssuesDisplayed;
    },
    getSearch() {
      console.log("reached getSearch");
      console.log("All Issues", this.allIssues);
      console.log("search text", this.searchText);
      this.searchResults = this.allIssues.filter((i) => i.seriesTitle.toLowerCase().includes(this.searchText.toLowerCase()) || i.creator.toLowerCase().includes(this.searchText.toLowerCase())
      || i.publisher.toLowerCase().includes(this.searchText.toLowerCase()));
      console.log("search results", this.searchResults);
      this.currentPage = 1;
      this.first = 0;
      this.last = 39;
    },
  },
};
</script>

<style>
.search-bar {
  display: inline-block;
  width: 100px;
  height: 100px;
}
#search {
  padding: 20px 80px 20px 30px;
  font-family: bebas neue;
}

#searchBar {
  background-color: rgba(26, 24, 24, 0.966);
  padding-right: 40px;
  padding-bottom:10px;
}

#prev {
  float: left;
  margin: 20px;
}

#next {
  float: right;
  margin: 20px -20px 20px 20px;
}

#current-page {
  float: none;
}
</style>