class Vision {
  constructor () {
    this.title = SplitText.create("#vision-tit", { 
      type: "words, chars",
      tag: "span"     
    });
    this.panels = gsap.utils.toArray('.vision__panel');
    
    this.init();
  }

  init(){
    this.charAni(this.title.chars);
    this.panels.forEach(panel => this.panelAni(panel))
  }

  charAni(chars) {
    gsap.from(chars, {
      yPercent: 50,
      stagger:0.03,
      autoAlpha:0,
      rotateZ: 10,
      scrollTrigger : {
        trigger: '#vision',
        start: 'top 60%',
        end: 'top 60%',
        toggleActions:'play none none reverse'
      }
    })    
  }

  panelAni(panel){
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: panel,
        start: 'top 75%',
        end: 'top 75%',
        toggleActions:'play none none reverse'
      }
    });

    tl
    .from(panel.querySelector('.vision__cate'), {
      duration:.6,
      ease: "power1.out",
      autoAlpha:0,
      x : 2 + "em",
    })
    .from(panel.querySelector('.vision__frame img'), {
      scale:1.075,
      opacity:0.3,
      ease: "power3.inout",
    }, "<")
    .from(panel.querySelector('.vision__ment'), {
      duration:.6,
      ease: "power2.out",
      autoAlpha:0,
      x : 1.5 + "em",
    }, '-=.2')
    .from(panel.querySelector('.vision__desc'), {
      duration:.6,
      ease: "power2.out",
      autoAlpha:0,
      x : 2 + "em",
    }, '-=.2')
    .from(panel.querySelectorAll('.vision__item'), {
      duration:.3,
      ease: "power2.out",
      autoAlpha:0,
      y : 1.5 + "em",
      stagger:0.05
    }, '-=.4')
  }
}

document.fonts.ready.then(() => {
  new Vision();
});