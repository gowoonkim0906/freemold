gsap.registerPlugin(ScrollTrigger, ScrollSmoother);

class Smoother{
  constructor () {
    this.smoother = ScrollSmoother.create({
      smooth: 2,
      effects: true,
    });    
  }
}

class SkipPanels {
  constructor () {
    this.panels = document.querySelectorAll('[data-skip]');
  }
}

window.addEventListener('load', () => {
    // Smoother 생성은 load 이후
    const smoother = ScrollSmoother.create({
        wrapper: '#smooth-wrapper',
        content: '#smooth-content',
        smooth: 2,
        effects: true
    });

    // 이미지/폰트 로딩 후 레이아웃 변동 반영
    requestAnimationFrame(() => {
        ScrollTrigger.refresh();
        smoother.refresh();
    });
});