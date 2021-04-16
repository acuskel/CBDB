<template>
  <div>
    <b-button v-b-modal.modal variant=danger style="font-family:bebas neue">Delete Entire Collection</b-button>
    <b-modal @ok="deleteOnClick" id="modal">
      <h3>Are you sure you want to delete this collection?</h3>
    </b-modal>
  </div>
</template>

<script>
import collectionService from "../services/CollectionService.js";
export default {
  name: "delete-collection-button",
  data() {
    return {

    };
  },

  props: ["collectionId"],

  methods: {
    /*closeModal() {
      this.show = false;
    },
    openModal() {
      this.show = true;
    },*/
    deleteOnClick() {
      collectionService
        .deleteCollection(this.collectionId)
        .then((response) => {
          console.log("promise was success", response);
          this.$router.push({ name: "my-collections" });
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

<style scoped>

</style>