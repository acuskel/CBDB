<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue';
import issueService from "./services/IssueService.js";

export default {
  components: { Navbar },
  created() {
    issueService
      .getAllIssues()
      .then((response) => {
        this.$store.commit("POPULATE_ALL_ISSUES", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "error: HTTP Response Code: " + error.response.data.status;
          this.message = +" Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>


<style>
@import '/assets/styles/styles.css';
body, html, #app {   
  min-height: 100%;
  background-color: rgb(232, 61, 79);
  text-align: center;
  color: #2c3e50;
  display: auto; }

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #1476a7;
}

ul {
  list-style-type: none;
}

#buttons li a {
  text-decoration: none;
  color: #ffffff;
  display: block;
}

li a:hover {
  text-decoration: none;
}
</style>