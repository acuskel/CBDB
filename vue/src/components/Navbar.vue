<template>
       <div id="navbar">
      <b-navbar class="navbar-custom" toggleable="lg" type="dark">
        <b-navbar-brand :to="{name: 'home'}">
          <img class="navbar-logo" src="../../src/assets/cbdbyellow2.png" alt="CBDB Logo" height="50">
        </b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item :to="{ name: 'home'}" >Home</b-nav-item>
            <b-nav-item :to="{ name: 'my-collections'}" v-if="$store.state.token != ''" >My Collections</b-nav-item>
            <b-nav-item :to="{ name: 'public'}" >Browse Public Collections</b-nav-item>
            <b-nav-item :to="{ name: 'search'}">Browse All Comics</b-nav-item>
            <b-nav-item :to="{ name: 'register'}" v-if="$store.state.token == ''">Register</b-nav-item>
            <b-nav-item :to="{ name: 'login'}" v-if="$store.state.token == '' && this.$route.name != 'login'">Log In</b-nav-item>
          </b-navbar-nav>

          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">

            <b-nav-item-dropdown right v-if="$store.state.token != ''">
              <!-- Using 'button-content' slot -->
              <template #button-content>
                <b>Logged in as:</b> {{$store.state.user.username}}
              </template>
              <b-dropdown-item v-if="$store.state.user.isPremium==true" disabled>☆ Premium User ☆</b-dropdown-item>
              <b-dropdown-item v-else disabled>Standard User</b-dropdown-item>
              <b-dropdown-item :to="{ name: 'logout'}" v-if="$store.state.token != ''">Sign Out</b-dropdown-item>
            </b-nav-item-dropdown>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
</template>
<script>
export default {
    name: "navbar",
    data() {
        return {
            searchText: '',
            searchResults: []

        }
    },
  methods: {
    getSearch() {
      this.searchResults = this.$store.state.allIssues.filter((i) => i.seriesTitle.includes(this.searchText));
      
    }
  }
}    
</script>

<style scoped>
.navbar-custom {
  color:white;
  background-color:rgba(26, 24, 24, 0.966);
  font-family: 'Bebas Neue', cursive;
}

.navbar-dark .navbar-nav .nav-link{
      color:white!important
    }


b{
  color:white;
}
</style>