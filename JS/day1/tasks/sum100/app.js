var sum = 0;
var input;

do {
    input = prompt("[Sum = " + sum + "]" + " Please enter a number (0 to exit):");
    if (isFinite(input)) {
        sum += parseInt(input)
    } else {
        alert("You've entered a non-number value");
    }
} while (input != '0' && sum <= 100);

document.write("Your sum is " + sum);