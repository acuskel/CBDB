<template>
  <div class="issues-container">
    <h1>Collection Stats</h1>
    <table class="table table-bordered table-hover">
    <tbody>
      <tr>
        <td>Issues</td>
        <td>{{issues.length }}</td>
      </tr>
      <tr>
        <td>Issues Data</td>
        <td>{{issues}}</td>
      </tr>
    </tbody>
    </table>
    <h1>Issues</h1>
    <ul>

      <li
        
        v-for="issue in $store.state.issues"
        v-bind:key="issue.id"
      >
      <router-link v-bind:to="{name: 'issue-display', params: {id: issue.id}}">
      {{issue.title}}
      </router-link>
      </li>
      <!-- todo: bind on ID -->
    </ul>
  </div>
</template>

<script>
import CollectionService from "../services/CollectionService.js";
export default {
  name: "issue-list",
  data() {
    return {
      message: "",
      issueId: 0,
    };
  },
  computed: {
    issues() {
      return this.$store.state.issues;
    },

  },
  created(){
    this.message = "";
    this.issueId = this.$route.params.id;
    
    CollectionService
      .getIssues(this.issueId)
      
      .then((response) => {
        this.$store.commit("REPLACE_ISSUES", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message = 
          "error: HTTP Response Code: " + error.response.data.status;
          this.message =+ " Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
    
  },
};
</script>

<style>

table,
th,
td {
  border: 1px solid black;
  background-color: white;
}

table {
  width: 50%;
  margin: 20px;
}
</style>
