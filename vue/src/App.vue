<template>
  <div id="app">
    <img src="../src/assets/logo.png"/>
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'public' }">Browse Public Collections</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'signup' }">Become a Premium User</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
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
  background-color:rgb(232,61, 79)
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.footer {
  font-size: 0.9rem;
}

ul {
  list-style-type: none;
}

#buttons li a {
  text-decoration: none;
  color: #FFFFFF;
  display: block;
}

li a:hover {
  text-decoration: none;
  color: #000000;
  background-color: #33B5E5;
}
</style>