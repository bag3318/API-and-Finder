var birthstoneGemFinder = (function() {
    function findUserGemstone(msg, monthSelector, gemSelector, January, February, March, April, May, June, July, August, September, October, November, December) {
        var list1 = document.querySelector(monthSelector);
        var message = msg;
        var label = document.querySelector(gemSelector);
        switch(list1.options[list1.selectedIndex].text) {
            case January:
                BetterInnerHTML(label, message + "Garnet</span>", true); // BettterInnerHTML = dom2 plugin replacement for innerHTML
                break;
            case February:
                BetterInnerHTML(label, message + "Amethyst</span>", true);
                break;
            case March:
                BetterInnerHTML(label, message + "either Aquamarine, or Bloodstone</span>", true);
                break;
            case April:
                BetterInnerHTML(label, message + "Diamond</span>", true);
                break;
            case May:
                BetterInnerHTML(label, message + "Emerald</span>", true);
                break;
            case June:
                BetterInnerHTML(label, message + "either Pearl, Moonstone, or Alexandrite</span>", true);
                break;
            case July:
                BetterInnerHTML(label, message + "Ruby</span>", true);
                break;
            case August:
                BetterInnerHTML(label, message + "either Peridot, Spinel, or Sardonyx</span>", true);
                break;
            case September:
                BetterInnerHTML(label, message + "Sapphire</span>", true);
                break;
            case October:
                BetterInnerHTML(label, message + "either Opal, or Tourmaline</span>", true);
                break;
            case November:
                BetterInnerHTML(label, message + "either Yellow Topaz, or Citrine</span>", true);
                break;
            case December: 
                BetterInnerHTML(label, message + "either Turqoise, Tanzanite, Blue Topaz, or Zircon</span>", true);
                break;
        }
    }

    function removeDefault2(extraElement) {
        var element = document.querySelector(extraElement);
        element.remove();
    }
    function showBtn(buttonSelector, cssSelector, cssClass) {
        var element = document.querySelector(buttonSelector);
        element.setAttribute(cssSelector, cssClass);
    }
    function initiation() {
        var element = document.querySelector("#btnBirthstone");
        element.addEventListener("click", function() {
            var script = birthstoneGemFinder();
            script.findUserGemstone("<span class=\"fade-in\">Your Gemstone is ", "#month2", "#gemstone", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"); // define all previous parameters
        }, false);
        element = null;
        var element = document.querySelector("#month2");
        element.addEventListener("change", function() {
            var script = birthstoneGemFinder();
            script.showBtn("#btnBirthstone", "class", "fade-in pos4");
            script.removeDefault2("#willremove2"); // good browsers will bypass this error
        }, false);
    }
    return function returnAPI(api) {
        return {
            initiation: initiation,
            findUserGemstone: findUserGemstone,
            removeDefault2: removeDefault2,
            showBtn: showBtn
        };
    };
}());