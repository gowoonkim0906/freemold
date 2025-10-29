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
    // Smoother ������ load ����
    const smoother = ScrollSmoother.create({
        wrapper: '#smooth-wrapper',
        content: '#smooth-content',
        smooth: 2,
        effects: true
    });

    // �̹���/��Ʈ �ε� �� ���̾ƿ� ���� �ݿ�
    requestAnimationFrame(() => {
        ScrollTrigger.refresh();
        smoother.refresh();
    });
});