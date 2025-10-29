class Panels {
  constructor () {
    this.panels = gsap.utils.toArray('.ly-split__panel');
    
    this.init();
  }

  init(){
    this.titleAni();
    this.descAni();
  }

  titleAni(){
    this.panels.forEach(panel => {
      gsap.from(panel.querySelector('.ly-split__tit'), {
        scrollTrigger: {
          trigger: panel,
          start:'top 75%',
          end:'top 75%'
        },
        autoAlpha:0,
        duration:.75,
        x: 1 + "em",
      })
    });
  }

  descAni(){
    this.panels.forEach(panel => {      
     
      const split = new SplitText(panel.querySelectorAll('.ly-split__desc'), { 
        type: "words chars",
        tag: "span"     
      });
      
      gsap.from(split.chars, {
        autoAlpha:0,
        y: 1 + "em",
        duration: 0.8,
        stagger: 0.02,
        ease: "power1.out",
        scrollTrigger: {
          trigger: panel,
          start: 'top 90%',
          end: 'center center',
          scrub:3,
        }
      });
    });
  }
}

document.fonts.ready.then(() => {
  new Panels();
});