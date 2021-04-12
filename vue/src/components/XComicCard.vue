<template>
  <div class="card"> 
    <router-link
      v-bind:to="{ name: 'comicDetails', params: { isbn: comic.isbn } }"
    >
      <h2 class="comic-title">{{ comic.title }}</h2>
      <img
        v-if="comic.isbn"
        v-bind:src="
          'http://covers.openlibrary.org/b/isbn/' + comic.isbn + '-M.jpg'
        "
      />
      <h3 class="comic-author">{{ comic.author }}</h3>
    </router-link>
    </div>
</template>

<script>
export default {
  name: "comic-card",
  props: {
    comic: Object,
  }
};
</script>

<style>
.card {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 550px;
  margin: 20px;
  justify-items: center;
}

.card .comic-title {
  font-size: 1.5rem;
}

.card .comic-author {
  font-size: 1rem;
}
</style>