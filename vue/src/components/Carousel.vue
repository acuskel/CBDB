<template>
  <div>
      <div id="carousel" class="mx-auto">
    <b-carousel
      id="carousel-1"
      v-model="slide"
      :interval="4000"
      controls
      indicators
      background="#ababab"
      img-width="176px"
      img-height="246.5px"
      style="text-shadow: 1px 1px 2px #333"
      @sliding-start="onSlideStart"
      @sliding-end="onSlideEnd"
    >
      <!-- Text slides with image -->
      <b-carousel-slide
        caption="First slide"
        text="Nulla vitae elit libero, a pharetra augue mollis interdum."
        img-src="https://ia800605.us.archive.org/view_archive.php?archive=/28/items/olcovers88/olcovers88-L.zip&file=882969-L.jpg"
        img-height="246.5px"
      ></b-carousel-slide>

      <!-- Slides with custom text -->
      <b-carousel-slide img-src="http://covers.openlibrary.org/b/isbn/9781607066019-L.jpg" >
        <h1>Hello world!</h1>
      </b-carousel-slide>

      <!-- Slides with image only 
      <b-carousel-slide
        img-src="https://picsum.photos/1024/480/?image=58"
        img-height="246.5px"
      ></b-carousel-slide> -->

      <!-- Slides with img slot -->
      <!-- Note the classes .d-block and .img-fluid to prevent browser default image alignment 
      <b-carousel-slide>
        <template #img>
          <img
            class="d-block img-fluid w-100"
            width="176"
            height="246.5"
            src="https://picsum.photos/1024/480/?image=55"
            alt="image slot"
          />
        </template>
      </b-carousel-slide> -->

      <!-- Slide with blank fluid image to maintain slide aspect ratio -->
      <b-carousel-slide caption="Blank Image" img-blank img-alt="Blank image">
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
          eros felis, tincidunt a tincidunt eget, convallis vel est. Ut
          pellentesque ut lacus vel interdum.
        </p>
      </b-carousel-slide>
    </b-carousel>

    <p class="mt-4">
      Slide #: {{ slide }}<br />
      Sliding: {{ sliding }}
    </p>
    </div>
  </div>
</template>

<script>
export default {
    name: "carousel",
  data() {
    return {
      slide: 0,
      sliding: null,
    };
  },
  methods: {
    onSlideStart() {
      this.sliding = true;
    },
    onSlideEnd() {
      this.sliding = false;
    },
  },
};
</script>

<style scoped>
#carousel {
    text-align: center;
    max-width: 200px;
    align-items: center;
    align-content:center;
    justify-content: center;
    justify-self: center;
}
</style>