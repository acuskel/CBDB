<template>
  <div>
    <div id="carousel" class="mx-auto">
      <b-carousel
        id="carousel-1"
        v-model="slide"
        :interval="4000"
        controls
        indicators
        fade
        background="#ababab"
        img-width="1000"
        img-height="561"
        style="text-shadow: 1px 1px 2px #333"
        @sliding-start="onSlideStart"
        @sliding-end="onSlideEnd"
      >

          <!-- caption="Saga"   this can alternatively be inserted into the b-carousel-slide item
          text="Staff Pick: Josh" -->

        <b-carousel-slide
         
          img-src="https://i.ibb.co/zXYR4Qf/Saga-carousel.jpg"
          img-width="1000"
          img-height="561"
        >
        <div class="saga">
          <h1 class="sagatext">Saga</h1>
          <p class="sagatext">Staff Pick: Josh</p>
          </div>
        </b-carousel-slide>

        <!-- Slides with custom text -->
        <b-carousel-slide
          img-src="https://i.ibb.co/MGMVbCQ/tankgirl-carousel.jpg"
          img-width="1000"
          img-height="561"
        >
          <h1 class="tankgirl">Tank Girl</h1>
          <p class="tankgirl">Staff Pick: Amanda</p>
        </b-carousel-slide>

        <!-- Slides with image only -->
        <b-carousel-slide
          img-src="https://i.ibb.co/3019FRS/thor-carousel.jpg"
          img-width="1000"
          img-height="561"
        >
           <h1 class="thor">Thor</h1>
          <p class="thor">Staff Pick: ...um...AJ?</p>
        </b-carousel-slide>

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

        <!-- Slide with blank fluid image to maintain slide aspect ratio 
        <b-carousel-slide caption="Blank Image" img-blank img-alt="Blank image">
          <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
            eros felis, tincidunt a tincidunt eget, convallis vel est. Ut
            pellentesque ut lacus vel interdum.
          </p>
        </b-carousel-slide> -->
      </b-carousel>
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
  align-items: center;
  align-content: center;
  justify-content: center;
  justify-self: center;
}

.tankgirl {
  color: #388ca0;
  font-weight: 700;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}


.sagatext {
  color: #605c75
;
  font-weight: 700;
  text-shadow:black;
  opacity:solid;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}

.thor {
  
  color: #ee2e4d;
  font-weight: 700;
  text-shadow:black;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}

p {
  font-size: 2em
}
</style>