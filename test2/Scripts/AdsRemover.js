$(document).ready(function () {
    $(".disqus-footer__wrapper").remove();
    $("div[style='height: 65px;']").remove();
    $("div[onmouseover='S_ssac();']").remove();
    SomeeAdsRemover();
});
function SomeeAdsRemover() {
    $("center").each(function () {
        if ($(this).html() == '<a href="http://somee.com">Web hosting by Somee.com</a>') {
            $(this).next().remove();
            $(this).next().next().remove();
            $(this).next().next().next().remove();
            $(this).remove();
            return false;
        }
        $("div[style='opacity: 0.9; z-index: 2147483647; position: fixed; left: 0px; bottom: 0px; height: 65px; right: 0px; display: block; width: 100%; background-color: #202020; margin: 0px; padding: 0px;']").remove();
        $("div[style='position: fixed; z-index: 2147483647; left: 0px; bottom: 0px; height: 65px; right: 0px; display: block; width: 100%; background-color: transparent; margin: 0px; padding: 0px;']").remove();
        $("div[style='outline: none !important; visibility: visible !important; resize: none !important; box-shadow: none !important; overflow: visible !important; background: none transparent !important; opacity: 1 !important; top: auto !important; position: fixed !important; border: 0px !important; min-height: 0px !important; min-width: 0px !important; max-height: none !important; max-width: none !important; padding: 0px !important; margin: 0px !important; transition-property: none !important; transform: none !important; width: auto !important; height: auto !important; z-index: 2000000000 !important; cursor: auto !important; float: none !important; bottom: 0px !important; right: 0px !important; left: auto !important; display: block;']").remove();
        $("div[style='height: 65px;']").remove();
    });
}