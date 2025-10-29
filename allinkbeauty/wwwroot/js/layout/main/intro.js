class Visual {
  constructor () {
    this.split = SplitText.create(".visual__text", { 
      type: "words, chars",
      tag: "span"     
    });
    
    this.charAni(this.split.chars);
  }

  charAni(chars) {
    const tl = gsap.timeline();
 
    tl
    .from('.intro__bg', {
      duration:1.5,
      autoAlpha:0,
    })
    .from('.visual__word', {
      duration:.75,
      autoAlpha:0,
    },"-=.5")
    .from('.visual__word', {
      ease:'power2.in',
      duration:1,
      left:'80%'
    })
    .from('.visual__k', {
      ease:'power2.in',
      duration:1,
      scale:1.75,
    }, "<")
    .from(chars, {
      duration: 1.75,
      y: () => gsap.utils.random(-150, 150),
      x: () => gsap.utils.random(-75, 75),
      rotationY: gsap.utils.random(-90, 90),
      autoAlpha: 0,
      ease: "power3.out",
      stagger: {
        each: 0.04,
        from: "random",
      }
    })
  }
}

class Greet {
  constructor () {
    this.split = SplitText.create(".greet__text", { 
      type: "words, chars",
      tag: "span"     
    });
    
    this.charAni(this.split.chars);
  }

  charAni(chars) {
    const tl = gsap.timeline({
      scrollTrigger : {
        trigger: '.greet',
        start: 'top 60%',
        end: 'center center',
        scrub:3,
      }
    });
 
    tl
    .from(chars, {
      opacity:0.2,
      stagger:0.08,
    })    
  }
}

document.fonts.ready.then(() => {
  new Visual();
  new Greet();
});
