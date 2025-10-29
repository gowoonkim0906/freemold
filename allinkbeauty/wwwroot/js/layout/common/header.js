class Header {
  
  constructor() {    
    this.header = document.getElementById('header');
    this.menus = document.querySelectorAll('.header-nav__item');    
    this.hamburger = document.getElementById('hamburger');
    this.threshold = 769;
    this.type = this.deviceCheck();
    
    this.handlers = new WeakMap();
    this.hamburgerHandler = null;

    this.init();
  }

  init() {
    this.setupMenus();

    window.addEventListener('resize', () => {
      const newType = this.deviceCheck();
      if (this.type === newType) return;

      this.type = newType;
      this.cleanup();
      this.setupMenus();
    });
  }

  setupMenus() {
    this.menus.forEach(menu => {
      const btn = menu.querySelector('.header-nav__btn[aria-haspopup]');
      if (!btn) return;

      this.ariaToggle(btn);
      if (this.type) {
        this.pcInit(menu, btn);
      } else {
        this.moInit();
      }
    });
  }

  deviceCheck() {
    return window.innerWidth >= this.threshold;
  }

  toggle(e, btn) {
    const id = btn.getAttribute('aria-controls');
    const target = document.getElementById(id);
    const status = btn.getAttribute('aria-expanded') === 'true';

    if (e && e.type === 'mouseenter' && status) return;

    if (btn.id === 'hamburger'){
      !status
        ? this.header.classList.add('header--active')
        : this.header.classList.remove('header--active');
    }

    btn.setAttribute('aria-expanded', !status);
    target.setAttribute('aria-hidden', status);    
  }

  ariaToggle(btn) {
    const menuId = btn.getAttribute('aria-controls');
    const menuTarget = document.getElementById(menuId);
    const navId = this.hamburger.getAttribute('aria-controls');
    const navTarget = document.getElementById(navId);

    if (this.type) {
      btn.setAttribute('aria-expanded', 'false');
      menuTarget.setAttribute('aria-hidden', 'true');

      this.hamburger.setAttribute('aria-expanded', 'false');
      navTarget.setAttribute('aria-hidden', 'false');
    } else {
      btn.setAttribute('aria-expanded', 'true');
      menuTarget.setAttribute('aria-hidden', 'false');

      this.hamburger.setAttribute('aria-expanded', 'false');
      navTarget.setAttribute('aria-hidden', 'true');
    }
  }

  pcInit(menu, btn) {
    const mouseEnterHandler = (e) => this.toggle(e, btn);
    const mouseLeaveHandler = (e) => this.toggle(e, btn);

    btn.addEventListener('mouseenter', mouseEnterHandler);
    menu.addEventListener('mouseleave', mouseLeaveHandler);

    this.handlers.set(btn, {
      element: btn,
      event: 'mouseenter',
      handler: mouseEnterHandler
    });
    this.handlers.set(menu, {
      element: menu,
      event: 'mouseleave',
      handler: mouseLeaveHandler
    });
  }

  moInit() {
    if (this.hamburgerHandler) return;

    this.hamburgerHandler = () => this.toggle(null, this.hamburger);
    this.hamburger.addEventListener('click', this.hamburgerHandler);
  }

  cleanup() {
    this.menus.forEach(menu => {
      const btn = menu.querySelector('.header-nav__btn[aria-haspopup]');
      if (!btn) return;

      if (this.handlers.has(btn)) {
        const btnData = this.handlers.get(btn);
        btnData.element.removeEventListener(btnData.event, btnData.handler);
        this.handlers.delete(btn);
      }

      if (this.handlers.has(menu)) {
        const menuData = this.handlers.get(menu);
        menuData.element.removeEventListener(menuData.event, menuData.handler);
        this.handlers.delete(menu);
      }
    });
  }
}

new Header();