<template>
  <div id="register" class="text-center" style="padding-bottom:10px; padding-top:30px">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal" style="margin-top:30px">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only">Username</label>
      <input style="max-width:300px; margin:auto; margin-bottom:10px"
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input style="max-width:300px; margin:auto; margin-bottom:10px"
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input style="max-width:300px; margin:auto; margin-bottom:10px"
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <!-- email input added when user wants to register as premium. Required field if premium box is checked. Is not linked to database -->
      <label for="email" class="sr-only" v-show="user.isPremium">Email</label>
      <input
        type="email"
        id="email"
        placeholder="E-mail Address"
        v-show="user.isPremium"
        :required="user.isPremium ? true : false"
      />
      <br />
      <input style="margin-top:10px"
        type="checkbox"
        id="isPremium"
        class="form-control"
        v-model="user.isPremium"
      />
      <label for="checkbox"
        ><p style="color:white; margin-top:10px">Register as a premium member ?</p></label
      >
      <br />
      <button style="max-width:300px; margin:auto; margin-bottom:10px" class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
      <router-link :to="{ name: 'login' }"><p style="margin-top:5px">Have an account?</p></router-link>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      isPremium: false,
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
        isPremium: false,
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style>
#register{
  background-color:rgba(26, 24, 24, 0.966);
  }
</style>
