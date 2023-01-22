conditionizr.add("noCookie", function(){
    return !window.cookie;
})

conditionizr.polyfill("cookies.js", ["noCookie"]);