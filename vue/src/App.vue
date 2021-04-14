<template>
  <div id="app">
    <navbar />
    <router-view />
    <foot />
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue';
import issueService from "./services/IssueService.js";
import Foot from './components/Foot.vue';


export default {
  components: { Navbar, Foot },
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
body, html, #app {   
  margin: auto;
  max-width: 1200px;
  min-height: 100%;
  text-align: center;
  color: #2c3e50;
  display: auto; 
  background: #7493bb;
  background-image: url("https://www.onlygfx.com/wp-content/uploads/2016/08/halftone-simple.png"), linear-gradient(#a64ac9, #fccd04);
  }


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