<template>
  <div class="issues-container">
    <h1>Collection Stats</h1>
    <b-container fluid-center class="card-grid">
      <b-row align-h="center">
        <b-card-group deck>
          <b-col md="4" class="ml-auto p-3">
            <b-card header="Issues" class="text-center">
              <b-card-text class="card_text">{{ issues.length }}</b-card-text>
            </b-card>
          </b-col>
          
          <b-col md="4" class="ml-auto p-3">
            <b-card header="Marvel Comics" class="text-center">
              <b-card-text class="card_text">{{ marvelComics }}</b-card-text>
            </b-card>
          </b-col>
          <b-col md="4" class="ml-auto p-3">
            <b-card header="DC Comics" class="text-center">
              <b-card-text class="card_text">{{ dcComics }}</b-card-text>
            </b-card>
          </b-col>
          <b-col md="4" class="ml-auto p-3">
            <b-card header="Featuring Superheroes" class="text-center">
              <b-card-text class="card_text">{{ superheroCount }}</b-card-text>
            </b-card>
          </b-col>
          <b-col md="4" class="ml-auto p-3">
            <b-card header="Total Pages in Collection" class="text-center">
              <b-card-text class="card_text">{{ countPages }}</b-card-text>
            </b-card>
          </b-col>
          <b-col md="4" class="ml-auto p-3">
            <b-card header="Avg Pages Per Issue" class="text-center">
              <b-card-text class="card_text">{{ averagePages }}</b-card-text>
            </b-card>
          </b-col>
        </b-card-group>
      </b-row>
    </b-container>
      <h1>Issues in this Collection:</h1>
      <ul>
        <li class="issue" v-for="issue in issues" v-bind:key="issue.id">
          <router-link
            v-on:click="onSubmit"
            v-bind:to="{
              name: 'issue-display',
              params: { id: issue.issueId, collectionId: collectionId },
            }"
          >
            {{ issue.seriesTitle }}
          </router-link>
           <delete-issue-button class="delete" :issueId="issue.issueId" :collectionId="collectionId"/>
        </li>
        <!-- todo: bind on ID -->
      </ul>
    
  </div>
</template>

<script>
import CollectionService from "../services/CollectionService.js";
import DeleteIssueButton from './DeleteIssueButton.vue';
export default {
  name: "issue-list",
  components:{
    DeleteIssueButton
  },
  data() {
    return {
      message: "",
      collectionId: 0,
      collections: {},
    };
  },
  computed: {
    issues() {
      return this.$store.state.issues;
    },
    marvelComics() {
      let counter = 0;
      this.issues.forEach((i) => {
        if (i.publisher == "Marvel") {
          counter++;
        }
      });
      return counter;
    },
    dcComics() {
      let counter = 0;
      this.issues.forEach((i) => {
        if (i.publisher == "DC") {
          counter++;
        }
      });
      return counter;
    },
    imageComics() {
      let counter = 0;
      this.issues.forEach((i) => {
        if (i.publisher == "Image") {
          counter++;
        }
      });
      return counter;
    },
    darkHorseComics() {
      let counter = 0;
      this.issues.forEach((i) => {
        if (i.publisher == "Dark Horse") {
          counter++;
        }
      });
      return counter;
    },
    superheroCount() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (i.characters.includes("man") || i.characters.includes("men") || i.characters.includes("X") || i.characters.includes("Justice") || i.characters.includes("Squad") || i.characters.includes("Flash") || i.characters.includes("Guardians") ) {
          counter++;
        }
      });
      return counter;
    },
    spidermanCount() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (
          i.characters.includes("Spider-Man") ||
          i.characters.includes("Spiderman")
        ) {
          counter++;
        }
      });
      return counter;
    },
    wonderWomanCount() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (i.characters.includes("Wonder Woman")) {
          counter++;
        }
      });
      return counter;
    },
    supermanCount() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (i.characters.includes("Superman")) {
          counter++;
        }
      });
      return counter;
    },
    batmanCount() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (i.characters.includes("Batman")) {
          counter++;
        }
      });
      return counter;
    },
    stanLeeComics() {
      let counter = 0;

      this.issues.forEach((i) => {
        if (i.creator.includes("Stan Lee")) {
          counter++;
        }
      });
      return counter;
    },
    countPages() {
      let counter = 0;

      this.issues.forEach((i) => {
        counter += i.pageCount;
      });
      return counter;
    },
    averagePages() {
      let pageCounter = 0;
      let issuesCounter = 0;

      this.issues.forEach((i) => {
        issuesCounter++;
        pageCounter += i.pageCount;
      });
      return Math.floor(pageCounter / issuesCounter);
    },
  },
  
  methods: {
    onSubmit() {
      this.$store.commit("SET_COLLECTION", this.$route.params.id);
    },
  },
  created() {
    this.collectionId = this.$route.params.id;
    console.log("store.collections", this.$store.state.collections);
    this.collections = this.$store.state.collections;
    CollectionService.getIssues(this.collectionId)

      .then((response) => {
        this.$store.commit("REPLACE_ISSUES", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "error: HTTP Response Code: " + error.response.data.status;
          this.message = +" Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>

<style>
.card-grid {
  padding-bottom: 2em;
}
.text-center {
  font-weight: bold;
}
.card_text {
  font-size: 4em;
}
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
body {
  background-color: white;
}

</style>
