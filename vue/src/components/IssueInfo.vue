<template>
  <div>
    <Cards />
    <div>
      <h1>{{ issue.title }}</h1>
      <h3>Title: {{ issue.seriesTitle }}</h3>
      <h3>Creator: {{ issue.creator }}</h3>
      <h3>Publisher: {{ issue.publisher }}</h3>
      <h3>Characters: {{ issue.characters }}</h3>
      <h3>Summary: {{ issue.summary}}</h3>
      <h3>Publication Date: {{ issue.releaseDate }}</h3> 
      <h3>Page Count: {{ issue.pageCount }}</h3>
    </div>
  </div>
</template>

<script>
import Cards from './Cards.vue'

export default {
  components: { Cards },
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
    this.issue = this.collection.issues.find((i) => i.issueId = this.issueId);



    

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