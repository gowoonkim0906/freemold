class Life {
  constructor () {
    this.title = SplitText.create("#life-tit", { 
      type: "words, chars",
      tag: "span"     
    });
    this.container = document.querySelector('.life__container');
    this.wrapper = document.querySelector('.life__wrapper');
    this.slider = new Swiper(".life__slide", {
      loop: true,
      grabCursor: true,
      slidesPerView: 1.7,
      spaceBetween: 30,
      speed:1500,
      autoplay: {
        delay: 50,
        disableOnInteraction: false,
      },
      breakpoints: {
        769: {
          slidesPerView: 2.2,
          spaceBetween: 40,
        },
        1025: {
          slidesPerView: 2.7,
          spaceBetween: 60,
        }
      },
    });

    this.init();
  }

  init(){
    this.charAni(this.title.chars);
    this.fadeContents();
    this.mouseCtrl();
  }

  charAni(chars) {
    gsap.from(chars, {
      yPercent: 50,
      stagger:0.03,
      autoAlpha:0,
      rotateZ: 10,
      scrollTrigger : {
        trigger: '#life',
        start: 'top 60%',
        end: 'top 60%',
        toggleActions:'play none none reverse'
      }
    })    
  }

  fadeContents(){
    gsap.from('.life__slide', {
      autoAlpha:0,
      duration:.8,
      yPercent:25,
      rotateX:45,
      scrollTrigger: {
        trigger: this.wrapper,
        start: 'top 65%',
        end: 'top 65%',
      }
    })
  }

  mouseCtrl(){
    this.wrapper.addEventListener('mouseenter', () => {
      this.slider.autoplay.stop();
    });
    
    this.wrapper.addEventListener('mouseleave', () => {
      this.slider.autoplay.start();
    });
  }

  // pinScroll(){
  //   gsap.to(this.wrapper, { 
  //     x: () => {
  //       const totalWidth = this.wrapper.scrollWidth;
  //       const viewWidth = this.wrapper.clientWidth;
  //       const scrollWidth = totalWidth - viewWidth;          
  //       return -scrollWidth;
  //     },
  //     scrollTrigger: {
  //       trigger: this.container,
  //       pin: true,
  //       pinSpacing: true,
  //       scrub: 2,
  //       start: "top top",					
  //     }
  //   });		
  // }
}

document.fonts.ready.then(() => {
  new Life();
});