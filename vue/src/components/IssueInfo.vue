<template>
  <div>
    <div>
      <h1>{{this.$store.state.currentCollection}}</h1>
      <h3>params.id {{ this.$route.params.id }}</h3>
      <h3>params.issueId {{ this.$route.params.issueId }}</h3>
      <h3>state.user.userId {{ this.$store.state.user.userId }}</h3>
      <h3>state.collections {{ this.$store.state.collections }}</h3>
      <h3>
        state.collections.issues {{ this.$store.state.collections.issues }}
      </h3>
      <h3>this.issueId {{ this.issueId }}</h3>

      <h1>{{ unaddedCollections }}</h1>
      <h1>{{ issue.title }}</h1>
      <h3>{{ issue.seriesTitle }}</h3>
      <h3>Issue Number: {{ issue.issueNumber }}</h3>
      <h3>{{ issue.creator }}</h3>
      <h3>{{ issue.publisher }}</h3>
      <h3>Genre: {{ issue.genre }}</h3>
      <h3>Publication Date: {{ issue.releaseDate }}</h3> 
      <h3>Pages: {{ issue.pageCount }}</h3> -->
    </div>
  </div>
</template>

<script>

export default {
  name: "issue-info",
  data() {
    return {
      message: "",
      issueId: 0,
      collection: {},
      issue: {},
      issues: [],
      unaddedCollections: []
    };
  },
  computed: {
    },
  methods: {
    setCollection() {
      this.$store.commit('SET_COLLECTION', this.collection);
    }
  },
  created() {
    
    console.log('store.collections', this.$store.state.collections);
    console.log('store.user', this.$store.state.user);
    this.collection = this.$store.state.collections.find((c) => c.id = this.$route.params.id);



    this.issueId = this.$route.params.id;

    /* /let issues = this.$store.state.collections.find((c) => 
    this.issue = this.$store.state.issues.find(
        (i) => i.issueId == this.issueId);

    this.unaddedCollections = this.$store.state.collections.filter(
        (c) => !c.issues.some((i) => i.issueId == this.issue.issueId));

    this.issue = this.issues.find((i) => i.id == this.$route.params.id); */
  }
}

</script>

<style>
</style>