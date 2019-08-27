
$(window).on('load', function () { // makes sure the whole site is loaded 
    $('#status').fadeOut(); // will first fade out the loading animation 
    $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website. 
    $('body').delay(350).css({ 'overflow': 'visible' });
});
$('ul.nav li.dropdown').hover(function () {
    //var w = $(window).width();
    //if (w > 767) {
    //    $(this).find('.dropdown-menu').hide();

    //}
  $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(250);
$(this).find('.dropdown-menu').css({
	"border-top":"2px solid #c8ac48",
     "opacity":.8
})
}, function() {

  $(this).find('.dropdown-menu').stop(true, true).delay(200).slideUp(250);

});

$(document).ready(function () {
    var w = $(window).width();
    $(".submenu").click(function () {
        if (w > 768) {
            $(".subdrop").css("position", "absolute")
        }
        else {
            $(".subdrop").css("position", "static")
            $(".submenu").children("ul").stop(true, true).delay(200).slideToggle();

        }
    })

    $("ul").click(function () {
        //p.stopPropagation();
    })
    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
        isClosed = false;

    trigger.click(function () {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
            $(".menu").css("transform", "translateX(-100%)")
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
            $(".menu").css("transform", "translateX(0%)")

        }
    }

    //$('[data-toggle="offcanvas"]').click(function () {
    //    $('#wrapper').toggleClass('toggled');
    //});
    (function ($) {
        $("#first-slider").fitText(1.2);
        //Function to animate slider captions 
        function doAnimations(elems) {
            //Cache the animationend event in a variable
            var animEndEv = 'webkitAnimationEnd animationend';

            elems.each(function () {
                var $this = $(this),
                    $animationType = $this.data('animation');
                $this.addClass($animationType).one(animEndEv, function () {
                    $this.removeClass($animationType);
                });
            });
        }

        //Variables on page load 
        var $myCarousel = $('#carousel-example-generic'),
            $firstAnimatingElems = $myCarousel.find('.item:first').find("[data-animation ^= 'animated']");

        //Initialize carousel 
        $myCarousel.carousel();

        //Animate captions in first slide on page load 
        doAnimations($firstAnimatingElems);

        //Pause carousel  
        $myCarousel.carousel('pause');


        //Other slides to be animated on carousel slide event 
        $myCarousel.on('slide.bs.carousel', function (e) {
            var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
            doAnimations($animatingElems);
        });
        $('#carousel-example-generic').carousel({
            interval: 4000,
            pause: "false"
        });

    })(jQuery);
})
   
