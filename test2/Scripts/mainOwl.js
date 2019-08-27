
$(document).ready(function () {
    var numitem = $(".mainPractice").length;
    if (numitem > 3) {
        $(".mainPractice").last().after("<div class='clearfix'></div>")
    }
 /*Our team*/
    $(".owl-carousel").owlCarousel({
        margin: 15,
        items:4,
        nav: true,
        autoHeight: true,
        autoplay :true,
        navText: [
          "<i class='fa fa-chevron-left'></i>",
          "<i class='fa fa-chevron-right'></i>"
        ],
        responsiveClass:true,
        responsive:{
            0:{
                items: 1,
                nav:false,
                loop:false
            },
            480:{
                items: 2,
                margin:0,
                nav:true
            },
            768:{
                items:3,
                nav:true,
                loop:true
            },
            1192: {
                loop: true,
                items:4,
                nav:true,
           
            }
        }
        })
})