// JavaScript Document
var giveFeedback = (function(){ // define global variable function
	function showFeedback(selector1, selector2, attr1, value1, attr2, value2) { // this function will show the feedback boxes
		var feedback = document.querySelector(selector1); // define feedback div
		var feedbackBtn = document.querySelector(selector2); // define feedback button
		feedback.setAttribute(attr1, value1); // show the div
		feedbackBtn.setAttribute(attr2, value2); // hide the button
		feedbackBtn.remove(); // remove the button so the positions will override each other
	}
 	function userFeedback(selector1, selector2, selector3, selector4, selector5, str1, attr1, value1, attr2, value2, attr3, value3, attr4, value4) { // this function deals with the users feedback
		// define all variables
		var btnFeedback = document.querySelector(selector1);
		var input = document.querySelector(selector2);
		var tyMsg = document.querySelector(selector3);
		var helpBetter = document.querySelector(selector4);
		var feedback = document.querySelector(selector5);
		if (input.options[input.selectedIndex].value >= 7) { // if the user enters a value of 7 or greater
			feedback.remove(); // remove the feedback div
			BetterInnerHTML(tyMsg, str1, true); // set inner html
			// set attributes
			tyMsg.setAttribute(attr1, value1);
			feedback.setAttribute(attr2, value2);
		}
		else if (input.options[input.selectedIndex].value < 7) { // else if lower than 7
			// do this
			feedback.setAttribute(attr3, value3);
			feedback.remove();
			helpBetter.setAttribute(attr4, value4);
		}
	}
	function closeImproveBox(selector1, selector2, str1, selector3, str2, attr1, value1, str3) { // define initiation function
		var helpBetter = document.querySelector(selector1);
		var ty = document.querySelector(selector2);
		var emptyStr = str1;
		if (document.querySelector(selector3).value === emptyStr) {
			alert(str2);
			return false;
		} else {
			helpBetter.setAttribute(attr1, value1);
			helpBetter.remove();
			BetterInnerHTML(ty, str3, true);		
			return true;
		}

	}
	function initiation5() {
		var element = document.querySelector("#feedbackBtn");
		element.addEventListener("click", function() {
			var script = giveFeedback();
			script.showFeedback("#feedback", "#feedbackBtn", "class", "fade-in", "class", "fade-out");
		}, false);
		element = null;
		var element = document.querySelector("#submitHelp");
		element.addEventListener("click", function() {
			var script = giveFeedback();
			script.closeImproveBox("#improve", "#thankYou",  "", "textarea", "Please enter something.", "class", "fade-out", "<span class=\"fade-in\">Thank you for your feedback :)</span>");
		}, false);
		element = null;
		var element = document.querySelector("#submitFeedback");
		element.addEventListener("click", function() {
			var script = giveFeedback();
			script.userFeedback("#feedbackBtn", "#inputFeedback", "#feedbackMessage", "#improve", "#feedback", "Thank you for your feedback :)", "class", "fade-in", "class", "fade-out", "class", "fade-out", "class", "fade-in");
		}, false);
	}
	return function returnAPI(api) { // define all purpose api
		return {
			userFeedback: userFeedback,
			initiation5: initiation5,
			closeImproveBox: closeImproveBox,
			showFeedback: showFeedback
		};
	};
}());