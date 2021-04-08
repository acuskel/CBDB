<template>
  <div class="issues-container">
    <ul>
        <li>{{$store.state.issues}}</li>
      <li
        
        v-for="issue in $store.state.issues"
        v-bind:key="issue.title"
      >
      <!-- todo: add routerlink to Individual comic Display -->
      
      {{issue.title}}
      
      </li>
      <!-- todo: bind on ID -->
    </ul>
  </div>
</template>

<script>
import issueService from "../services/IssueService.js";
export default {
  name: "issue-list",
  data() {
    return {
      message: "",
    };
  },
  computed: {
    issues() {
      return this.$store.state.issues;
    },

  },
  created(){
    this.message = "";
    
    issueService
      .getIssues(this.$store.state.collections.id) //need parameter from selected collection
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

</style>