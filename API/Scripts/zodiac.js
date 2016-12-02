var zodiacFinder = (function() { // define global variable function
    function formFinder(msg, selector) {
        document.finder.date.selectedIndex; // use form tag to get day select value
        document.finder.month.selectedIndex; // use form to tag to get month select tag's selected value
        var span = document.querySelector(selector);
        var message = msg;
		/*
			Quick explanation:
			----------------------
			== is not used here because it is not strict; whereas === is.
			== will try to convert one side to make it equal to the other, === won't
			that is why === is used here.
		*/
        if(document.finder.month.selectedIndex === 0 && document.finder.date.selectedIndex <= 19) {

            BetterInnerHTML(span, message+"Capricorn</span>", true); // DOM2 plugin replacement for innerHTML
			return true; // return true to help browser know what is correct
        }
        if(document.finder.month.selectedIndex === 0 && document.finder.date.selectedIndex >= 20) {
            BetterInnerHTML(span, message+"Aquarius</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 1 && document.finder.date.selectedIndex <= 18) {
            BetterInnerHTML(span, message+"Aquarius</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 1 && document.finder.date.selectedIndex >= 19) {
            BetterInnerHTML(span, message+"Pisces</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 2 && document.finder.date.selectedIndex <= 20) {
            BetterInnerHTML(span, message+"Pisces</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 2 && document.finder.date.selectedIndex >= 21) {
            BetterInnerHTML(span, message+"Aries</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 3 && document.finder.date.selectedIndex <= 19) {
            BetterInnerHTML(span, message+"Aries</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 3 && document.finder.date.selectedIndex >= 20) {
            BetterInnerHTML(span, message+"Taurus</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 4 && document.finder.date.selectedIndex <= 20) {
            BetterInnerHTML(span, message+"Taurus</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 4 && document.finder.date.selectedIndex >= 21) {
            BetterInnerHTML(span, message+"Gemini</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 5 && document.finder.date.selectedIndex <= 22) {
            BetterInnerHTML(span, message+"Gemini</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 5 && document.finder.date.selectedIndex >= 21) {
            BetterInnerHTML(span, message+"Cancer</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 6 && document.finder.date.selectedIndex <= 22) {
            BetterInnerHTML(span, message+"Cancer</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 6 && document.finder.date.selectedIndex >= 23) {
            BetterInnerHTML(span, message+"Leo</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 7 && document.finder.date.selectedIndex <= 22) {
            BetterInnerHTML(span, message+"Leo</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 7 && document.finder.date.selectedIndex >= 23) {
            BetterInnerHTML(span, message+"Virgo</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 8 && document.finder.date.selectedIndex <= 22) {
            BetterInnerHTML(span, message+"Virgo</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 8 && document.finder.date.selectedIndex >= 23) {
            BetterInnerHTML(span, message+"Libra</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 9 && document.finder.date.selectedIndex <= 22) {
            BetterInnerHTML(span, message+"Libra</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 9 && document.finder.date.selectedIndex >= 23) {
            BetterInnerHTML(span, message+"Scorpio</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 10 && document.finder.date.selectedIndex <= 21) {
            BetterInnerHTML(span, message+"Scorpio</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 10 && document.finder.date.selectedIndex >= 22) {
            BetterInnerHTML(span, message+"Sagittarius</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 11 && document.finder.date.selectedIndex <= 21) {
            BetterInnerHTML(span, message+"Sagittarius</span>", true);
			return true;
        }
        if(document.finder.month.selectedIndex === 11 && document.finder.date.selectedIndex >= 22) {
            BetterInnerHTML(span, message+"Capricorn</span>", true);
			return true;
        }
    }

    function addOrRemoveDays(selector1, selector2, selector3, January, March, May, July, August, October, December, April, June, September, November, February, option, element, attribute) {
        var list = document.querySelector(selector1);
        var div = document.querySelector(selector2); 
        var dateList = document.querySelector(selector3);
        var days = 0;
        switch(list.options[list.selectedIndex].text) { // format: select.options[select.selectedIndex].text
            case January:
            case March:
            case May:
            case July:
            case August:
            case October:
            case December:
                days = 31; // set all months above to days 31
                break;
            case April:
            case June:
            case September:
            case November:
                days = 30; // set all months above to days 30
                break;
            case February:
                days = 29; // set month above to days 29
                break;
        }
        if(dateList.length > 0) {
            for(var i = dateList.length; i >= dateList.length; i--) { // remove first, then take away a day
                dateList.remove(dateList.length - 1); // remove 1 from the days list
            }
        }
        for(var x = 1; x <= days; x++) { 
            var li = document.createElement(option); // add a day in case of ascending dates
            dateList.appendChild(li); // add to the list
            li.appendChild(document.createTextNode(x)); // create text within the list
        }
        div.setAttribute(element, attribute); // set attribute to div to show
    }

    function removeDefault(extraElement) {
        var element = document.querySelector(extraElement); // remove the extra option in select tag
        element.remove(); // call to remove
    }

    function init() {
        var element = document.querySelector("#month");
        element.addEventListener("change", function() {
            var script = zodiacFinder();
            script.addOrRemoveDays("#month", "#daysList", "#date", "January", "March", "May", "July", "August", "October", "December", "April", "June", "September", "November", "February", "option", "class", "fade-in1");
            script.removeDefault("#willremove");
        }, false);
        element = null; // set element to null to reuse variable
        var element = document.querySelector("#btnZodiac");
        element.addEventListener("click", function() {
            var script = zodiacFinder();
            script.formFinder("<span class=\"fade-in\">Your Zodiac Sign is ", "#zodiacSign");
        }, false);
    }
    return function returnAPI(api) { // define all-purpse API here to create callbacks for initiation functions and initiate.js
        return {
            formFinder: formFinder,
            addOrRemoveDays: addOrRemoveDays,
            initiation2: init,
            removeDefault: removeDefault
        };
    };
}());
