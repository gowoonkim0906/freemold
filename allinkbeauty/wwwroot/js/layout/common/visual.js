class Visual {
  constructor () {
    this.split = SplitText.create(".visual__text", { 
      type: "words, chars",
      tag: "span"     
    });
    
    this.charAni(this.split.chars);
  }

  charAni(chars) {
    gsap.from(chars, {
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
    });
  }
}

document.fonts.ready.then(() => {
  new Visual();
});