<template>
  <div>
    <router-link v-bind:to="{ name: 'signup' }"><img src="https://i.imgur.com/pgONM9p.png" width=500/></router-link>
  </div>
</template>

<script>

export default {
  name: "collection-display",
  components: {
  },
  
  computed: {
    allowAdd() {
      if((this.$store.state.token != '') && (this.$store.state.issues.length < 100)) {
        return true;
      }
      else return false;
    }
  },
  created() {
    this.collectionId = this.$route.params.id;
    console.log("in created", this.collectionId);
  },
  data() {
    return {
      collectionId: 0,
    };
  },
};
</script>

<style>
</style>