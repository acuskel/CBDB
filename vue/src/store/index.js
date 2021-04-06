import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    comics: [
      {
        title: "Spiderman",
        author: "Peter David",
        isbn: "9781601390554"
      },
      {
        title: "Batman",
        author: "Jeph Loeb",
        isbn: "9781401223175"
      },
      {
        title: "The Tick",
        author: "Greg Hyland",
        isbn: "9781578400775"
      },
    ],

    collections: [],

    token: currentToken || '',
    user: currentUser || {}
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_ACTIVE_COMIC(state, comicIsbn){ // todo: not working
      state.activeComic = comicIsbn;
    },
    SAVE_COLLECTION(state, newCollection){
      state.collections.push(newCollection);
    },
    REPLACE_COLLECTIONS(state, collections) {
      state.collections = collections;
    }
  }
})
