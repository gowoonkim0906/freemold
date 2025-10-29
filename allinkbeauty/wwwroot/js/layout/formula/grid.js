class Grid {
  constructor () {
    this.grid = document.querySelector('.grid-list--about')

    this.fadeAni();
  }

  fadeAni(){
    gsap.from(this.grid, {
      scrollTrigger: {
        trigger: this.grid,
        start:'top 75%',
        end:'top 75%',
      },
      yPercent:15,
      autoAlpha:0,
    })
  }
}

new Grid();