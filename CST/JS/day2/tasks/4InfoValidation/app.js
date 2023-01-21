var Uname, Uphone, Umobile, Uemail;

do {
    Uname = prompt("Please enter your first and last name:", "Ahmed Negm");
} while (!!!Uname || Uname.match(/^[A-Z a-z ]{3,20} [A-Z a-z]{3,20}$/) == null);

do {
    Uphone = prompt("Please enter your phone number:", "12345678");
} while (!!!Uphone || Uphone.match(/^[0-9]{8}$/) == null);

do {
    Umobile = prompt("Please enter your mobile number:", "01212345678");
} while (!!!Umobile || Umobile.match(/^01[0-2][0-9]{8}$/) == null);

do {
    Uemail = prompt("Please enter your email:","asd231@gmail.com");
} while (!!!Uemail || Uemail.match(/^[a-zA-Z_.0-9]{3,32}@[a-zA-Z]{1,16}\.[A-Za-z]{1,3}$/) == null);

var fields = ['Welcome', 'telephone', 'mobile', 'email'];
var values = [Uname, Uphone, Umobile, Uemail];

for (var i = 0; i < 4; i++){
    document.write(`<p style="color:blue; display:inline;">${fields[i]} </p><p style="display:inline;">${values[i]}</p><br>`);
}