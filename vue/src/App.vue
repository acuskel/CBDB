<template>
  <div id="app">
    <Navbar />
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

<script>
import Navbar from './components/Navbar.vue';  
  export default {
    name: 'navbar',
    components: {
      Navbar
}}

</script>


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