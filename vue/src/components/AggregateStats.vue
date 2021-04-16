<template>
<div id="stats-bg">
  <b-container fluid-center class="card-grid">
    <b-row align-h="center">
      <b-card-group deck>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="Total Number of Users" class="text-center">
            <b-card-text  class="card_text">{{ numberOfUsers }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="Size of Largest Collection" class="text-center">
            <b-card-text class="card_text">{{ largestUserCollection }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card  header-text-variant=dark header="Avg. Issues Per Collection" class="text-center">
            <b-card-text class="card_text">{{ averageNumberOfIssues }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card  header-text-variant=dark header="Most Collections by a User" class="text-center">
            <b-card-text class="card_text">{{ mostCollectionsByUser }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
              <b-card header-text-variant=dark header="Featuring Superheroes" class="text-center">
                <b-card-text class="card_text">{{ superheroCount }}</b-card-text>
              </b-card>
            </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="DC Comics" class="text-center">
            <b-card-text class="card_text">{{ dcComics }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="Marvel Comics" class="text-center">
            <b-card-text class="card_text">{{ marvelComics }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="Image Comics" class="text-center">
            <b-card-text class="card_text">{{ imageComics }}</b-card-text>
          </b-card>
        </b-col>
        <b-col md="4" class="ml-auto p-4">
          <b-card header-text-variant=dark header="Dark Horse Comics" class="text-center">
            <b-card-text class="card_text">{{ darkHorseComics }}</b-card-text>
          </b-card>
        </b-col>
      </b-card-group>
    </b-row>
  </b-container>
  </div>
</template>
<script>
import StatisticsService from "../services/StatisticsService.js";
export default {
  name: "aggregate-statistics",
  data() {
    return {
      message: "",
    };
  },
  computed: {
    statistics() {
      return this.$store.state.statistics;
    },
    averageNumberOfIssues() {
      return this.statistics.averageNumberOfIssues
    },
    largestUserCollection(){
      return this.statistics.largestUserCollection
    },
    numberOfUsers(){
      return this.statistics.numberOfUsers
    },
    mostCollectionsByUser(){
      return this.statistics.mostCollectionsByUser
    },
    marvelComics() {
      let counter = 0;
      this.$store.state.allIssues.forEach((i) => {
        if (i.publisher == "Marvel") {
          counter++;
        }
      });
      return counter;
    },
    dcComics() {
      let counter = 0;
      this.$store.state.allIssues.forEach((i) => {
        if (i.publisher == "DC") {
          counter++;
        }
      });
      return counter;
    },
    imageComics() {
      let counter = 0;
      this.$store.state.allIssues.forEach((i) => {
        if (i.publisher == "Image") {
          counter++;
        }
      });
      return counter;
    },
    darkHorseComics() {
      let counter = 0;
      this.$store.state.allIssues.forEach((i) => {
        if (i.publisher == "Dark Horse") {
          counter++;
        }
      });
      return counter;
    },
    superheroCount() {
      let counter = 0;

      this.$store.state.allIssues.forEach((i) => {
        if (i.seriesTitle.includes("man") || i.seriesTitle.includes("men") || i.seriesTitle.includes("X") || i.seriesTitle.includes("Justice") || i.seriesTitle.includes("Squad") || i.seriesTitle.includes("Flash") || i.seriesTitle.includes("Guardians") ) {
          counter++;
        }
      });
      return counter;
    },

  },
  created() {
    this.statistics = this.$store.state.statistics;
    StatisticsService.getStatistics()
      .then((response) => {
        this.$store.commit("REPLACE_STATISTICS", response.data);
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

.text-center {
  font-size: .80em;
}
.card_text {
  font-size: 3em;
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
#stats-bg {
background-color:rgba(26, 24, 24, 0.966);
}
</style>