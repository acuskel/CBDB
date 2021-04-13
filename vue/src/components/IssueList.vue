<template>
  <div class="issues-container">
    <h1>Collection Stats</h1>
    <table class="table table-bordered table-hover">
    <tbody>
      <tr>
        <th>Number of Issues or Books</th>
        <th>Number of Marvel Comics</th>
        <th>Number of DC Comics</th>
        <th>Number of Issues Featuring Superheroes</th>
        <th>Number of Issues Featuring Spiderman</th>
        <th>Number of Issues Featuring Superman</th>
        <th>Number of Issues Featuring Batman</th>
      </tr>
      <tr>
        <td>{{issues.length }}</td>
        <td>{{ marvelComics }}</td>
        <td>{{ dcComics }}</td>
        <td>{{ superheroCount }}</td>
        <td>{{ spidermanCount }}</td>
        <td>{{ supermanCount }}</td>
        <td>{{ batmanCount }}</td>
      </tr>
      
    </tbody>
    </table>
    <h1>Issues in this Collection:</h1>
    <ul>

      <li
        
        v-for="issue in issues"
        v-bind:key="issue.id"
      >
      <router-link 
      v-on:click="onSubmit"
      v-bind:to="{name: 'issue-display', params: {id: issue.issueId, collectionId: collectionId}}">
      {{issue.seriesTitle}}
      </router-link>
      </li>
      <!-- todo: bind on ID -->
    </ul>
  </div>
</template>

<script>
import CollectionService from "../services/CollectionService.js";
export default {
  name: "issue-list",
  data() {
    return {
      message: "",
      collectionId: 0,
      collections: {}
    };
  },
  computed: {
    issues() {
      return this.$store.state.issues;
    },
    marvelComics(){
      let counter = 0;
      this.issues.forEach(i => {
      if(i.publisher == 'Marvel'){
        counter ++;
      }     
      });
      return counter;  
    },
    dcComics(){
      let counter = 0;
      this.issues.forEach(i => {
      if(i.publisher == 'DC'){
        counter ++;
      }     
      });
      return counter;  
    },
    imageComics(){
      let counter = 0;
      this.issues.forEach(i => {
      if(i.publisher == 'Image'){
        counter ++;
      }     
      });
      return counter;  
    },
    darkHorseComics(){
      let counter = 0;
      this.issues.forEach(i => {
      if(i.publisher == 'Dark Horse'){
        counter ++;
      }     
      });
      return counter;  
    },
    superheroCount(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.publisher == 'DC' || i.publisher == 'Marvel'){
        counter ++;
      }     
      });
      return counter;  
    },
    spidermanCount(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.characters.includes("Spider-Man") || i.characters.includes("Spiderman")){
        counter ++;
      }     
      });
      return counter;  
    },
    supermanCount(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.characters.includes("Superman")){
        counter ++;
      }     
      });
      return counter;  
    },
    batmanCount(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.characters.includes("Batman")){
        counter ++;
      }     
      });
      return counter;  
    },
    stanLeeComics(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.creator.includes("Stan Lee")){
        counter ++;
      }     
      });
      return counter;  
    },
    jackKirbyComics(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.characters.includes("Jack Kirby")){
        counter ++;
      }     
      });
      return counter;  
    },
  },
  methods: {
    onSubmit() {
      this.$store.commit("SET_COLLECTION", this.$route.params.id);
    },
    
  },
  created(){
    
    this.collectionId = this.$route.params.id;
    console.log('store.collections', this.$store.state.collections);
    this.collections = this.$store.state.collections
    CollectionService
      .getIssues(this.collectionId)
      
      .then((response) => {
        this.$store.commit("REPLACE_ISSUES", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message = 
          "error: HTTP Response Code: " + error.response.data.status;
          this.message =+ " Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
    
  },
};
</script>

<style>

table,
th,
td {
  border: 1px solid black;
  background-color: white;
}

table {
  width: 50%;
  margin: 20px;
}
</style>
