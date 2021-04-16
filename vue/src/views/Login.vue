<template>
  <div id="login" class="text-center" style="padding-bottom:20px; padding-top:10px">
    <div
        id="welcome"
        style="
          width: 100%;
          letter-spacing: 2px;
          margin: 4px -3px;
          padding: 7.5px 0px 5.5px;
          border: solid 3px white;
          border-radius: 20px;
          text-align: center;
          color: white;
          font-size: 25px;
          background: black;
          margin-bottom:50px
        "
      >
        <img src="../../src/assets/welcome.gif" />
      </div>
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label for="username" class="sr-only">Username</label>
      <input
      style="max-width:300px; margin:auto; margin-bottom:10px"
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
      style="max-width:300px; margin:auto; margin-bottom:10px"
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <b-button variant=primary type="submit" style="margin-right:20px; margin-top:20px">Sign in</b-button>
      <router-link :to="{ name: 'register' }"><p style="margin-top:20px">Need an account?</p></router-link>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style>
#login{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>