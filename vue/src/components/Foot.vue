<template>
  <div>
    <div id="foot">
      <div class="container">
        <div class="row">
          <div class="col-md-5">
            <h5><i class="fa fa-road"></i> ACME CO INC.</h5>
            <div class="row">
              <div class="col-6">
                <ul class="list-unstyled">
                  <li><a href="">Product</a></li>
                  <li><a href="">Benefits</a></li>
                  <li><a href="">Partners</a></li>
                  <li><a href="">Team</a></li>
                </ul>
              </div>
              <div class="col-6">
                <ul class="list-unstyled">
                  <li><a href="">Documentation</a></li>
                  <li><a href="">Support</a></li>
                  <li><a href="">Legal Terms</a></li>
                  <li><a href="">About</a></li>
                </ul>
              </div>
            </div>
            <ul class="nav">
              <li class="nav-item">
                <a href="" class="nav-link pl-0"
                  ><i class="fa fa-facebook fa-lg"></i
                ></a>
              </li>
              <li class="nav-item">
                <a href="" class="nav-link"
                  ><i class="fa fa-twitter fa-lg"></i
                ></a>
              </li>
              <li class="nav-item">
                <a href="" class="nav-link"
                  ><i class="fa fa-github fa-lg"></i
                ></a>
              </li>
              <li class="nav-item">
                <a href="" class="nav-link"
                  ><i class="fa fa-instagram fa-lg"></i
                ></a>
              </li>
            </ul>
            <br />
          </div>
          <div class="col-md-2">
            <h5 class="text-md-right">Contact Us</h5>
            <hr />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "foot",
};
</script>

<style>
#foot {
  background-color: white;
}

template {
  font-family: "Alegreya Sans", sans-serif;
}

/* Sticky footer position and size
-------------------------------------------------- */
html {
  position: relative;
  min-height: 100%;
}
body {
  /* Margin bottom by footer height */
  margin-bottom: 300px;
}
.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  /* Set the fixed height of the footer here */
  height: 300px;
}

/* Sticky footer style and color
-------------------------------------------------- */
footer {
  padding-top: 30px;
  background-color: #292c2f;
  color: #bbb;
}

footer a {
  color: #999;
  text-decoration: none;
}

footer a:hover,
footer a:focus {
  color: #aaa;
  text-decoration: none;
  border-bottom: 1px dotted #999;
}

footer .form-control {
  background-color: #1f2022;
  box-shadow: 0 1px 0 0 rgba(255, 255, 255, 0.1);
  border: none;
  resize: none;
  color: #d1d2d2;
  padding: 0.7em 1em;
}
</style>