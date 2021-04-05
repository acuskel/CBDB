<template>
  <div>
    <form v-on:submit.prevent>
      <input
        class="collection-input"
        type="text"
        placeholder="Insert Collection Name"
        v-model="collection.name"
      />
      <button type="submit" v-on:click="saveCollection()">Add Collection</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "add-collection",
  data() {
    return {
      collection: {
        name: "",
      },
    };
  },

  methods: {
    saveCollection() {
      this.$store.commit("SAVE_COLLECTION", this.collection);
      this.collection = {
        name: "",
      };
      //this.$router.push({ name: "Home" });
    },
  },
};
</script>

<style>
</style>