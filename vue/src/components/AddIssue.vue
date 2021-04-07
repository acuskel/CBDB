<template>
  <div>
    <h2>Add an Issue</h2>
    <form v-on:submit.prevent>
      <input type="text" placeholder="Title" v-model="issue.title" />
      <input
        type="text"
        placeholder="Series Title"
        v-model="issue.seriesTitle"
      />
      <input type="number" placeholder="UPC" v-model="issue.upc" />
      <input type="number" placeholder="ISBN" v-model="issue.isbn" />
      <input type="text" placeholder="Summary" v-model="issue.summary" />
      <input type="text" placeholder="Publisher" v-model="issue.publisher" />
      <input type="text" placeholder="Cover Link" v-model="issue.coverLink" />
      <input
        type="date"
        placeholder="Release Date"
        v-model="issue.releaseDate"
      />
      <button type="submit" v-on:click="onSubmit()">Add Issue</button>
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
        title: "",
        seriesTitle: "",
        upc: "",
        isbn: "",
        summary: "",
        publisher: "",
        coverLink: ""
      },
    };
  },

  methods: {
    onSubmit() {
      IssueService.addIssue(this.issue)
        .then((response) => {
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