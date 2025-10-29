class Contact {
  constructor() {
    this.header = document.getElementById('header');
    this.headerHeight = this.header.clientHeight;
    this.wrapper = document.getElementById('contact');
    this.scrollTriggerInstance = null;
    
    this.init();
    this.handleResize();
  }
  
  init() {
    if (window.innerWidth >= 769) {
      this.createScrollTrigger();
    }
  }
  
  createScrollTrigger() {
    this.scrollTriggerInstance = ScrollTrigger.create({
      trigger: '.contact__text',
      pin: true,
      start: `top ${this.headerHeight}`,
      end: () => {
        return this.wrapper.classList.contains('contact--sub') 
          ? 'bottom bottom' 
          : 'bottom top';
      },
      endTrigger: '.contact__container',
    });
  }
  
  handleResize() {
    window.addEventListener('resize', () => {
      if (window.innerWidth < 768) {
        if (this.scrollTriggerInstance) {
          this.scrollTriggerInstance.kill();
          this.scrollTriggerInstance = null;
        }
      } else {
        if (!this.scrollTriggerInstance) {
          this.createScrollTrigger();
        }
      }
    });
  }
}

new Contact();