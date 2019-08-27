$(document).ready(function () {

    /*Our team*/
    $('.aboutProfile').hide();
    $('.aboutAllView').mouseover(function () {
        var team = $('.aboutAllView').index(this);
        $(this).css({
            'top': -55 + 'px'
        });
        $('.aboutProfile:eq(' + team + ')').show();
    })
    $('.aboutAllView').mouseout(function () {
        var team = $('.aboutAllView').index(this);
        $('.aboutProfile:eq(' + team + ')').slideDown();
        $('.aboutAllView').css({
            'top': 0
        });
    });

    /*Our team*/
})