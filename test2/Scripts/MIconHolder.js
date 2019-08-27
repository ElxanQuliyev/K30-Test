$(document).ready(function () {
    $(".iconsHolder i").on("click", function () {
        var iconClass = $(this).attr("class").split(" ")[1];
        $(".iconsHolder").find(".iconActiveColor").removeClass("iconActiveColor");
        $(this).addClass("iconActiveColor");
        $("#iconForm").val(iconClass);
    })
})