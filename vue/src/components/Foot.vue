<template>
  <div id="footer">
    <share-it
      text="This is sample text"
      url="https://www.google.com"
      height="600"
      width="600"
      dense
    />
    <base-button class="btn-facebook btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-facebook"></i></span>
    </base-button>
    <base-button class="btn-twitter btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-twitter"></i></span>
    </base-button>
    <base-button class="btn-google-plus btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-google-plus-g"></i></span>
    </base-button>
    <base-button class="btn-instagram btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-instagram"></i></span>
    </base-button>
    <base-button class="btn-pinterest btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-pinterest"></i></span>
    </base-button>
    <base-button class="btn-youtube btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-youtube"></i></span>
    </base-button>
    <base-button class="btn-vimeo btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-vimeo-v"></i></span>
    </base-button>
    <base-button class="btn-slack btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-slack"></i></span>
    </base-button>
    <base-button class="btn-dribbble btn-icon-only">
      <span class="btn-inner--icon"><i class="fab fa-dribbble"></i></span>
    </base-button>
  </div>
</template>

<script>
export default {
  name: "foot",
};
</script>

<style>
#footer {
  background-color: rgba(26, 24, 24, 0.966);
  color: white;
  margin: auto;
  padding: 50px;
}
</style>