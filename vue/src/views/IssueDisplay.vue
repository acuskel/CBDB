<template>
<div>
  <h1>{{issue.title}}</h1>
  <h2>{{issue}}</h2>
  </div>
</template>

<script>
export default {
  name: "issue-display",
  data() {
    return {
      message: "",
    };
  },
computed: {
    issue(){
        return this.$store.state.issues.find(i => i.id == this.$route.params.id)
    }
}
}
</script>

<style>

</style>