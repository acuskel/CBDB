<template>
       <div id="navbar">
      <b-navbar toggleable="lg" type="dark">
        <b-navbar-brand>
          <img class="navbar-logo" v-bind:to="{ name: 'home'}" src="../../src/assets/logo.png" alt="CBDB Logo" height="100">
        </b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item :to="{ name: 'home'}" >Home</b-nav-item>
            <b-nav-item :to="{ name: 'my-collections'}" v-if="$store.state.token != ''" >My Collections</b-nav-item>
            <b-nav-item :to="{ name: 'public'}" >Browse Public Collections</b-nav-item>
            <b-nav-item :to="{ name: 'search'}">Search Comics</b-nav-item>
            <b-nav-item :to="{ name: 'register'}" v-if="$store.state.token == ''">Register</b-nav-item>
            <b-nav-item :to="{ name: 'login'}" v-if="$store.state.token == '' && this.$route.name != 'login'">Log In</b-nav-item>
          </b-navbar-nav>

          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">
            <!-- <b-nav-form>
              <b-form-input
                size="sm"
                class="mr-sm-2"
                placeholder="Search"
              ></b-form-input>
              <b-button size="sm" class="my-2 my-sm-0" type="submit"
                >Search</b-button
              >
            </b-nav-form> 

            <b-nav-item-dropdown text="Lang" right>
              <b-dropdown-item href="#">EN</b-dropdown-item>
              <b-dropdown-item href="#">ES</b-dropdown-item>
              <b-dropdown-item href="#">RU</b-dropdown-item>
              <b-dropdown-item href="#">FA</b-dropdown-item>
            </b-nav-item-dropdown> -->

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
            meal: ''
        }
    },
  methods: {
    getMeal() {
      
    }
  }
}    
</script>