class View{
  constructor() {
    this.thumbs = new Swiper(".view-slide__thumb", {
        loop: false,
      spaceBetween: 8,
      slidesPerView: 3,
      freeMode: true,
      watchSlidesProgress: true,
      breakpoints: {
        1281: {
          spaceBetween: 20,
          slidesPerView: 6,
        },
        1024: {
          spaceBetween: 15,
          slidesPerView: 5,
        },
        768: {
          spaceBetween: 10,
          slidesPerView: 4,
        },
      }
    });

    this.main = new Swiper(".view-slide__main", {
        loop: false,
      grabCursor: true,
      thumbs: {
        swiper: this.thumbs,
      },
    });
  }
}

new View();