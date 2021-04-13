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
const currentCollections = JSON.parse(localStorage.getItem('collections'));
const allIssues = JSON.parse(localStorage.getItem('allIssues'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    collections: currentCollections || [],
    issues: [],
    allIssues: allIssues || [],

    collection: {},
    
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
    SAVE_COLLECTION(state, newCollection){
      state.collections.push(newCollection);
    },
    REPLACE_COLLECTIONS(state, collections) {
      state.collections = collections;
      localStorage.setItem('collections', JSON.stringify(collections));
    },
    REPLACE_ISSUES(state, issues) {
      state.issues = issues;
    },
    SET_COLLECTION(state, collection) {
      state.currentCollection = collection;
    },
    POPULATE_ALL_ISSUES(state, allIssues) {
      state.allIssues = allIssues;
      localStorage.setItem('allIssues', JSON.stringify(allIssues))
    },
  }
})