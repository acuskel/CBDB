<template>
  <div>
    <h2>Add an Issue</h2>
    <form v-on:submit.prevent="onSubmit()">
      <input type="text" placeholder="Title" v-model="issue.title" />
      <input
        type="text"
        placeholder="Series Title"
        v-model="issue.seriesTitle"
      />
      <input type="number" placeholder="UPC" v-model.number="issue.upc" />
      <input type="number" placeholder="ISBN" v-model.number="issue.isbn" />
      <input type="text" placeholder="Summary" v-model="issue.summary" />
      <input type="text" placeholder="Publisher" v-model="issue.publisher" />
      <input type="text" placeholder="Cover Link" v-model="issue.coverLink" />
      <input
        type="date"
        placeholder="Release Date"
        v-model="issue.releaseDate"
      />
      <button type="submit">Add Issue</button>
    </form>
  </div>
</template>

<script>
import IssueService from "../services/IssueService.js";

export default {
  name: "add-issue",
  data() {
    return {
      issue: {
      },
    };
  },

  props: ["collectionId"],


  methods: {
    onSubmit() {
      IssueService.addIssue(this.issue, this.collectionId)
        .then((response) => {
          console.log(response.data);
          console.log("promise was success", response);
          this.$router.go(0);
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
    },
  },
};
</script>

<style>
</style>