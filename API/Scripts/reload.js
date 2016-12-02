var pageReload = (function(){
    function executePageReload() {
        document.location.reload(true);
    }
    function init() {
        var element = document.querySelector("#reload");
        element.addEventListener("click", function() {
            var script = pageReload();
            script.ePR();
        }, false);
    }
    return function returnAPI(api) {
        return {
            initiation3: init,
            ePR: executePageReload
        };
    };
}());
