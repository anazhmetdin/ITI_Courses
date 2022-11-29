var word, caseSensitive, i;

do {
    word = prompt("Please enter a word:");
} while (!!!word);

caseSensitive = confirm("Do you want the palindrome search to\
 be case sensitive?");

if (!caseSensitive) {
    word = word.toLowerCase();
}

var wordLen = word.length
var middle = parseInt(wordLen / 2);

for (i = 0; i < middle && word[i] == word[word.length - i - 1]; i++) {

}

if (i == middle) {
    document.write(`"${word}" is a palindrome`);
} else {
    document.write(`"${word}" isn't a palindrome`);
}