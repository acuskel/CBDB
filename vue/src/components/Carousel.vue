<template>
<div style="background-color: rgba(26, 24, 24, 0.966);padding-top:1px;">
  <div>
    <div id="carousel" class="mx-auto">
      <div
        id="welcome"
        style="
          width: 100%;
          letter-spacing: 2px;
          margin: 4px -3px;
          padding: 7.5px 0px 5.5px;
          border: solid 3px white;
          border-radius: 20px;
          text-align: center;
          color: white;
          font-size: 25px;
        "
      >
        <img src="../../src/assets/welcome.gif" />
      </div>
      <b-row>
        <b-col>
          <div style="width: 825px; margin: 10px">
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
              style="text-shadow: 1px 1px 1px #333"
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
                  <!-- <h1 class="sagatext">Saga</h1>
                  <p class="sagatext">Staff Pick: Josh</p> -->
                </div>
              </b-carousel-slide>

              <!-- Slides with custom text -->
              <b-carousel-slide
                img-src="https://i.ibb.co/MGMVbCQ/tankgirl-carousel.jpg"
                img-width="1000"
                img-height="561"
              >
                <!--<h1 class="tankgirl">Tank Girl</h1>
                <p class="tankgirl">Staff Pick: Amanda</p>-->
              </b-carousel-slide>

              <!-- Slides with image only -->
              <b-carousel-slide
                img-src="https://i.ibb.co/3019FRS/thor-carousel.jpg"
                img-width="1000"
                img-height="561"
              >
               <!-- <h1 class="thor">Thor</h1>
                <p class="thor">Staff Pick: RJ</p>-->
              </b-carousel-slide>
            </b-carousel>
          </div>
        </b-col>
        <b-col>
          <div
            id="sidebar"
            class="text-right"
            style="
              letter-spacing: 2px;
              border: solid 3px white;
              border-radius: 20px;
              text-align: center;
              color: white;
              font-size: 25px;
            "
          >
            <div id="sidebar-title" style="background:black;">
              <img width="200" src="../../src/assets/staffpicks.png" />
            </div>
            <div id="recs">
            <div v-if="slide == 0" class="text-center">
              <h1 class="title" style="color:#d88726; font-family:bebas neue">Saga</h1>
              <h2 class="recBy" style="color:#d88726; font-family:bebas neue">Recommended by: Josh</h2>
              <h3 class="blurb" style="font-size:16px; font-weight:normal">Saga is the sweeping tale of one young family fighting to find their place in the worlds. When two soldiers from opposite sides of a never-ending galactic war fall in love, they risk everything to bring a fragile new life into a dangerous old universe. Fantasy and science fiction are wed like never before in a sexy, subversive drama for adults.</h3>
            </div>
            <div v-if="slide == 1" class="text-center">
              <h1 class="title" style="color:#49b4a9; font-family:bebas neue">Tank Girl</h1>
              <h2 class="recBy" style="color:#49b4a9; font-family:bebas neue">Recommended by: Amanda</h2>
              <h3 class="blurb" style="font-size:15px; font-weight:normal">The eponymous character Tank Girl drives a tank, which is also her home. She undertakes a series of missions for a nebulous organization before making a serious mistake and being declared an outlaw. The comic centres on her misadventures with her boyfriend, Booga, a mutant kangaroo. The comic's style is heavily influenced by punk visual art, and strips are frequently deeply disorganized, anarchic, absurdist, and psychedelic.</h3>
            </div>
            <div v-if="slide == 2" class="text-center">
              <h2 class="recBy" style="color:#ee2e4d; font-size:24px; font-family:bebas neue">Thor 154 [1968] - "To Wake the Mangog"</h2>
              <h2 class="recBy" style="color:#ee2e4d; font-family:bebas neue">Recommended by: RJ</h2>
              <h3 class="blurb" style="font-size:14px; font-weight:normal;">Hela pays a visit to Sif’s hospital room while she hangs in the balance from Loki’s onslaught. 

Meanwhile, Ulik the Troll seeks revenge against the Asgardians. Searching deep in the bowels of the Earth, Ulik discovers a prison with a warning from Odin. “Let the universe tremble! The Mangog lives again!” shouts the beast that emerges from the shattered cell. Ulik, who recently held his own against Thor, realizes that this ancient creature’s power dwarfs his own.</h3>
            </div>
          </div>
          </div>
        </b-col>
      </b-row>
    </div>
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
#recs{
margin-top:15px;
margin-inline: 15px;
}

.title{
  font-size:30px;
}
.recBy{
  font-size:18px;
}
.blurb{
  font-size:22px;
}
#sidebar-title {
  border: solid 3px white;
  border-radius: 15px;
  margin: 5px;
  text-align: center;
  font-size: 22px;
}
#sidebar {
  min-height: 460px;
  margin-right: 10px;
  margin-top: 10px;
  margin-left: -20px;

  background-color: rgba(26, 24, 24, 0.5);
  width: 330px;
}

#welcome {
  background-color: black;
  color: white;
}

#welcome-text {
  text-align: center;
  padding: 30px;
}

.tankgirl {
  color: #388ca0;
  font-weight: 700;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}

.sagatext {
  color: #605c75;
  font-weight: 700;
  text-shadow: black;
  opacity: solid;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}

.thor {
  color: #ee2e4d;
  font-weight: 700;
  text-shadow: black;
  -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: black;
}

p {
  font-size: 2em;
}
</style>