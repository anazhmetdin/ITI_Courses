var word, letter, caseSensitive;

do {
    word = prompt("Please enter a word: ");
} while (!!!word);

do {
    letter = prompt("Please enter a letter to be counted: ");
} while (!!!letter);

caseSensitive = confirm("Do you want the count to be case sensitive?");

if (!caseSensitive) {
    word = word.toLowerCase();
    letter = letter.toLocaleLowerCase();
}

document.write(`The letter "${letter}" appeared in "${word}"
 ${(word.match(RegExp(letter, 'g'))|| []).length} times`);