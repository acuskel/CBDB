<template>
  <div>
    <h1>{{ comic.title }}</h1>
    <h1>{{ comic.author }}</h1>
    <img class="selectedComic"
      v-bind:src="
        'http://covers.openlibrary.org/b/isbn/' + comic.isbn + '-M.jpg'
      "
    />
  </div>
</template>

<script>
export default {
  computed: {
    comic() {
      return this.$store.state.comics.find(
        (c) => c.isbn == this.$store.state.activeComic
      );
    },
  },
  created() {
    const comicIsbn = this.$route.params.isbn;
    this.$store.commit("SET_ACTIVE_COMIC", comicIsbn);
  },
};
</script>

<style>
.selectedComic {
    height: 650px;
}
</style>
