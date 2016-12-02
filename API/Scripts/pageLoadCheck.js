// JavaScript Document
var loadCheck = (function(){
	function checkLoadOK(str, str1, errMsg, complete) {
		if (document.readyState === complete) {
			var string = str;
			console.log(string);
		} else {
			var string1 = str1;
			console.log(str1);
			alert(errMsg);
		}
	}
	function init() {
		var element = window;
		element.addEventListener("load", function() {
			var script = loadCheck();
			script.checkLoadOK("page loaded 200 OK", "page not loaded correctly", "Page has not loaded correclty", "complete");
		}, false);
	}
	return function returnAPI(api) {
		return {
			checkLoadOK: checkLoadOK,
			initiation4: init		
		};
	};
}());
