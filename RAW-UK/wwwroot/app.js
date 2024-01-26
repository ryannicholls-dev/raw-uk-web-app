window.blazorInterop = {
    initializeAnimations: function() {
        const hero = document.querySelector('.hero');
        const image = document.querySelector('.bg-img');
        const headline = document.querySelector('.headline');
        const scrollText = document.querySelector('.scroll-text');
        const navBar = document.querySelector('.navbar-nav');

        const tl = new TimelineMax();

        tl.fromTo(image, 1, { height: "0%"}, {height: "80%", ease: Power2.easeInOut }).delay(0.5)
          .fromTo(image, 1.2, { width: "100%"}, { width: "70%", ease: Power2.easeInOut})
          .fromTo(headline, 0.5, {visibility: "hidden"}, {visibility: "visible"}, "-=1")
          .fromTo(navBar, 1, { opacity: 0 }, { opacity: 1 }, "-=0.5")
          .fromTo(headline, 1, { opacity: 0 }, { opacity: 1 }, "-=1")
          .fromTo(scrollText, 1.5, { opacity: 0 }, { opacity: 1 });

        //SCROLLMAGIC
        const controller = new ScrollMagic.Controller();

        const logoAnim = TweenMax.fromTo(image, 1.5, { opacity: 1 }, { opacity: 0 });
        const textAnim = TweenMax.fromTo(headline, 1.5, { opacity: 1 }, { opacity: 0 });

        //SCENES
        let logoScene = new ScrollMagic.Scene({
          duration: 500, 
          triggerElement: hero,
          triggerHook: 0
        })
        .setPin(hero)
        .setTween(logoAnim)
        .addTo(controller);

        let textScene = new ScrollMagic.Scene({
          duration: 500, 
          triggerElement: hero,
          triggerHook: 0
        })
        .setTween(textAnim)
        .addTo(controller);
    }
};