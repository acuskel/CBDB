<template>
  <div id="app">
    <div id="bootstrap-navbar">
      <b-navbar toggleable="lg" type="dark" variant="success">
        <b-container>
          <b-navbar-brand href="#">Mealzers</b-navbar-brand>
          <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
          <b-collapse id="nav-collapse" is-nav>
            <!-- Right aligned nav items -->
            <b-navbar-nav class="ml-auto">
              <b-nav-form>
                <b-form-input
                  size="sm"
                  class="mr-sm-2"
                  placeholder="Search for a meal"
                  v-model="meal"
                ></b-form-input>
                <b-button
                  size="sm"
                  class="my-2 my-sm-0"
                  type="submit"
                  @click.prevent="getMeal"
                  >Search</b-button
                >
              </b-nav-form>
              <b-nav-item-dropdown right>
                <!-- Using 'button-content' slot -->
                <template slot="button-content"><em>User</em></template>
                <b-dropdown-item href="#">Profile</b-dropdown-item>
                <b-dropdown-item href="#">Sign Out</b-dropdown-item>
              </b-nav-item-dropdown>
            </b-navbar-nav>
          </b-collapse>
        </b-container>
      </b-navbar>
    </div>
    <img src="../src/assets/logo.png" />

    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }" v-if="$store.state.token != ''"
        >Home</router-link
      >&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'public' }"
        >Browse Public Collections</router-link
      >&nbsp;|&nbsp;
      <router-link
        v-bind:to="{ name: 'register' }"
        v-if="$store.state.token == ''"
        >Register</router-link
      >&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''"
        >Login</router-link
      >&nbsp;|&nbsp;
      <!-- <router-link v-bind:to="{ name: 'signup' }" v-if="$store.state.token != ''">Become a Premium User</router-link>&nbsp;|&nbsp;-->
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout</router-link
      >
    </div>
    <router-view />
  </div>
</template>


<style>
#app {
  font-family: comic, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background-color: rgb(232, 61, 79);
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #1476a7;
}

.footer {
  font-size: 0.9rem;
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
  color: #000000;
  background-color: #33b5e5;
}
</style>