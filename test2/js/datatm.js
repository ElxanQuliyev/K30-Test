$(document).ready(function () {
    var j = jQuery.noConflict();
    j(function () {
        j('#datetimepicker1').datetimepicker({
            format: 'L',
            disabledHours: true,
        });
    });
})

