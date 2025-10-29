class Brand{
  constructor(){
    this.panels = gsap.utils.toArray('.brand__panel');

    this.panels.forEach(panel => {
      const tl = gsap.timeline({
        scrollTrigger: {
          trigger: panel,
          start: 'top 60%',
          end: 'center 45%',
          scrub:2,
        }
      });

      tl.from(panel.querySelector('.brand__frame img'), {
        opacity:0.25,
        scale:0.85,
        objectPosition : '0% -50%'
      }).from(panel.querySelector('.main-tit'), {
        autoAlpha:0,
        x: 2+ "em",
      }).from(panel.querySelector('.brand__desc'), {
        autoAlpha:0,
        x: 2+ "em",
      })
      .from(panel.querySelector('.brand__nav'), {
        autoAlpha:0,
        x: 2+ "em",
      })
    });
  }
}

new Brand();