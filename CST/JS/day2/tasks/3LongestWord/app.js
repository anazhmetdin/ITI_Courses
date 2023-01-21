var sentance, longest, longestSize = 0;

do {
    sentance = prompt("Please enter a sentance:");
} while (!!!sentance);

sentance = sentance.split(' ');

for (var i = 0; i < sentance.length; i++) {
    if (sentance[i].length > longestSize) {
        longestSize = sentance[i].length;
        longest = sentance[i];
    }
}

document.write(`The longest word in "${sentance.join(' ')}" 
is "${longest}"`);