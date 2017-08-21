$(document).ready(function ($) {
    $("#comments").owlCarousel({

        navigation: false, // Show next and prev buttons
        slideSpeed: 800,
        paginationSpeed: 400,
        autoPlay: 5000,
        singleItem: true
    });

    var owl = $("#pictures");

    owl.owlCarousel({
        items: 4,
        itemsDesktop: [1000, 4],
        itemsDesktopSmall: [900, 2],
        itemsTablet: [600, 1],
        itemsMobile: false
    });

    $(window).stellar({
        horizontalScrolling: false
    });


    $('#pictures a').nivoLightbox({
        effect: 'fadeScale'
    });

    var scrollAnimationTime = 1200;
    $('.navbar-default a, .section-home-cont a').click(function () {
        scrollTo(this.hash);
    });

    $('.section-home-cont button').click(function () {
        var target = '#register';
        scrollTo(target);
    });

    function scrollTo(target) {
        $('html, body').stop().animate({
            scrollTop: $(target).offset().top
        }, scrollAnimationTime);
    }

    $('.navbar-right').onePageNav({
        currentClass: 'current',
        changeHash: false,
        scrollSpeed: 750,
        scrollThreshold: 0.01,
        scrollOffset: 60,
        begin: function () {
        },
        end: function () {
        },
        scrollChange: function ($currentListItem) {
            if ($currentListItem.hasClass('kj-green')) {
                $('.kg-navigation').removeClass('background-yellow');
                $('.kg-navigation').addClass('background-green');
            }
            else {
                $('.kg-navigation').removeClass('background-green');
                $('.kg-navigation').addClass('background-yellow');
            }
        }
    });

    $(window).scroll(function () {
        var top = (document.documentElement && document.documentElement.scrollTop) || document.body.scrollTop;

        if (top > 40) {
            $('.kg-navigation').removeClass('nav-animate-out');
            $('.kg-navigation').addClass('nav-animate-in');
        }
        else {
            $('.kg-navigation').removeClass('nav-animate-in');
            $('.kg-navigation').addClass('nav-animate-out');
        }

    });

    var wow = new WOW(
        {
            mobile: false
        }
    );
    wow.init();
});