var keys = window.location.search.match(/([^&?]{0,})=/g);
var vals = window.location.search.match(/=[^&]{0,}/g);

var dict = {};

for (var i = 0; i<keys.length; i++) {
    keys[i] = keys[i].replace('=', '');
    vals[i] = vals[i].replace('=', '');
    vals[i] = vals[i].replace('+', ' ');

    dict[keys[i]] = vals[i];
}

alert(`Hello ${dict['title']} ${dict['name']}`);

document.write(`Address: ${dict['address']} <br> Gender: ${dict['gender']} <br> Email: ${dict['address']} <br> Mobile: ${dict['mobile']} <br>`);

if (!!!window.chrome) {
    document.write("<br><br>It's recommeded to use Chrome");
}