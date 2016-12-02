[comment]: # (start README.md markdown script)

<!--

 _______  __  .__   __.  _______   _______ .______      
|   ____||  | |  \ |  | |       \ |   ____||   _  \     
|  |__   |  | |   \|  | |  .--.  ||  |__   |  |_)  |    
|   __|  |  | |  . `  | |  |  |  ||   __|  |      /     
|  |     |  | |  |\   | |  '--'  ||  |____ |  |\  \----.
|__|     |__| |__| \__| |_______/ |_______|| _| `._____|
                                                                                                       
-->                                                                             
                                                                                    
About Finder :mag:
==================

<!--<img type="text/png" src="http://goo.gl/fwnd3e"/>-->

![Finder Favicon](images/favicon.png "Finder Favicon")

This app Includes
-----------------
- [x] Fully functioning Zodiac Sign Finder
- [x] Fully functioning Birthstone Finder
- [x] Feedback system (not fully functioning yet; API coming soon)
- [x] JavaScript written in DOM2 notation/format

## How to Execute

1. Download the :file_folder: **`Birthstone-and-Zodiac-Sign-Finder.zip`** file by clicking the green download button.
2. Then, in the page popup, click the "__Dowload ZIP__" button.
3. Open the downloaded .zip file and extract it.
4. Open the extracted folder
5. Locate to this directory: :open_file_folder: __`test\index.html`__
6. Open the index.html file in the test folder with a browser (see browser compatbility below)
7. See how to use the web app below

## How To Use Finder

### Zodiac Sign Finder

1.  Select your birthday month
2.  then select your birthday-day when it appears
3.  click the find button
4.  Your zodiac sign will appear

### Birthday Gemstone (Birthstone) Finder

1.  Select your birthday month
2.  Click the find button
3.  Your birthstone will appear

Browser Compatibility
---------------------

[//]: # (start table)
|     Edge/IE     |    Safari    |      Chrome      |   Firefox  |    Opera    |
|-----------------|--------------|------------------|------------|-------------|
|not compatible :(|6.1.6 or later|34.0.1847 or later|1.3 or later|8.xx or later|
[//]: # (end table)

## Version Info and History

+ _1.1_ - Added Scripts
+ _1.2_ - Added Stylesheets
+ _1.3_ - Added HTML Page
+ _1.4_ - Added Plans
+ _1.5_ - Added Images
+ _1.6_ - Added SQL Database Files
+ _1.7_ - Added feedback preview functionality (current)
+ _1.8_ - Added ASP.net web API (preview, beta)

Download and Install Adobe Acrobat Reader to Open `layout.xd`
------------------------------------------------------------

1. Go to [this](https://get.adobe.com/reader/ "Adobe Experience Designer CC Download Link") page
2. Click the "**download now**" button (**it's free**)
3. Continue with the guided download of Adobe Acrobat Reader
4. Open and install the file
5. Continue with the guided installation of Adobe Acrobat Reader
6. Open :paperclip:__`layout.pdf`__ file in the plans folder with __Adobe Acrobat Reader__; directory: :open_file_folder: __`plans\layout.pdf`__

* * *

## JavaScript DOM2 Example

```JavaScript
var a = (function(){
	function b(c) {
		var d = c;
		console.log(d); // write to the console
	}
	function l(m,n) {
		var p = m;
		var q = n;
		console.log(p+q); // do some math
	}
	function s(t) {
		var v = t;
		document.write(v); // write to the page
	}
	function w(x) {
		var y = x;
		alert(y); // alert the user
	}
	function e() {
		var f = window;
		var r = "load";
		var A = 8;
		var W = 44;
		f.addEventListener(r, function() {
			var j = a();
			j.h(A);
			j.o(W, W);
			j.u(A);
			j.z(A);
		}, false); // or true appropriately
	}
	return function g(api) { // define API
		return {
			h: b,
			i: e,
			o: l,
			u: s,
			z: w
		};
	};	
}());
/*------------------------------------*/
// define intiate script
var k = a();
k.i();
```

## Other Information

### Languages Used

+ HTML5
+ CSS3
+ JavaScript
<br/>
- [x] No jQuery is/was used (~~jQuery~~) :+1: 

> It's not that I hate jQuery, it's that people hate (or don't like) JavaScript and want to use jQuery instead. :thought_balloon:

### Plugins Used

+ [BetterInnerHTML][1]
- [Pace Loading Bar][2]

[1]: http://www.optimalworks.net/resources/betterinnerhtml/ "BetterInnerHTML page"
[2]: http://github.hubspot.com/pace/docs/welcome/ "Pace Loading Bar GitHub page"

* * *

<span>Thanks to **`@jrw6287`** for testing</span>

> __*Enjoy!*__

[comment]: # (end README.md markdown script)
