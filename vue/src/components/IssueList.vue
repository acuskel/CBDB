<template>
  <div class="issues-container">
    <h1>Collection Stats</h1>
    <table class="table table-bordered table-hover">
    <b-tbody responsive>
      <b-tr>
        <th>Issues or Books</th>
        <th>Marvel Comics</th>
        <th>DC Comics</th>
        <th>Issues Featuring Superheroes</th>
        <th>Issues Featuring Wonder Woman</th>
        <th>Issues Featuring Spiderman</th>
        <th>Issues Featuring Superman</th>
        <th>Issues Featuring Batman</th>
      </b-tr>
      <b-tr>
        <td>{{issues.length }}</td>
        <td>{{ marvelComics }}</td>
        <td>{{ dcComics }}</td>
        <td>{{ superheroCount }}</td>
        <td> {{ wonderWomanCount }} </td>
        <td>{{ spidermanCount }}</td>
        <td>{{ supermanCount }}</td>
        <td>{{ batmanCount }}</td>
        
      </b-tr>
      
    </b-tbody>
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
    wonderWomanCount(){
      let counter = 0;
      
      this.issues.forEach(i => {
      if(i.characters.includes("Wonder Woman")){
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
