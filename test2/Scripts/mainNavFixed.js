$(document).ready(function () {

    if ($(window).width() < 480) {
        $("#TopBar").css({
            "margin-bottom": "30px",
            "padding-bottom": "15px"
        })
        $("#TopMenu").css({
            "margin": "42px 0"
        })
    }
 
})
$(window).scroll(function () {
    if ($(this).scrollTop() > 42) {
        $('#TopMenu').addClass('navFixed');
        $('#TopBar').css('display', 'none');
        $('#TopMenu').css({
            'margin': 0
        })
        $('.hamburger').css({
            'margin': '-42px 0'
        })
    } else {
        $('#TopMenu').removeClass('navFixed');
        $('#TopMenu').css({
            'margin': '42px 0'
        })
        $('.hamburger').css({
            'margin': 0
        })
        $('#TopBar').css('display', 'block');

    }

})