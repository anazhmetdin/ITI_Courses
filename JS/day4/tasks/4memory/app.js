var cards = [], rCards, index, moon = './imgs/Moon.gif';
var revealed = [], solved = 0, trials = 0, started = false;
var trialsElement, accuracyElement, startButton, resetButton;

document.addEventListener("DOMContentLoaded", function(event) {
    trialsElement = document.getElementById("trials");
    accuracyElement = document.getElementById("accuracy");
    startButton = document.getElementById("start");
    resetButton = document.getElementById("reset");
});

function revealAll() {
    if (cards.length == 0 && !started) {
        startButton.disabled = true;

        // create list of all cards
        for (var i = 0; i < 6; i++) {
            cards[i*2] = `./imgs/${i+1}.gif`;
            cards[i*2 + 1] = `./imgs/${i+1}.gif`;
        }
        
        // select random card and move it to a random list of cards
        rCards = [];
        for (var i = 0; i < 12; i++) {
            index = Math.floor(Math.random() * cards.length);
            rCards[i] = cards[index];
            cards.splice(index, 1);

            // display card
            document.images[i].src = rCards[i];
        }
        
        // hide all cards after timeout
        setTimeout(() => {
            for (var i = 0; i < 12; i++) {
                document.images[i].src = moon;
            }
            // set game panel
            started = true;
            resetButton.disabled = false;
        }, 3000);
    }
}

function reset() {
    if (started) {
        // hide all cards
        for (var i = 0; i < 12; i++) {
            document.images[i].src = moon;
        }
    
        // reset variables
        trials = solved = 0;
        trialsElement.textContent = 0;
        accuracyElement.textContent = 0 + '%';
    
        rCards = [];
        revealed = [];

        started = false;
        startButton.disabled = false;
        resetButton.disabled = true;
    }
}

function reveal(img) {
    if (started && solved != 6) {
        // display card
        img.src = rCards[img.id];
        // add img to revealed array
        revealed.push(img);
    }

    // if two cards are revealed
    if (revealed.length == 2) {
        trials++;
        trialsElement.textContent = trials;
    }
}

function check() {
    // if two cards revealed
    if (solved != 6 && revealed.length == 2) {
        if (revealed[0].src == revealed[1].src) { // corret guess
            solved++;
        } else { // wrong guess, hide cards
            revealed[0].src = revealed[1].src = moon;
        }
        
        // reset revealed array
        revealed = [];
        // update accuracy
        accuracyElement.textContent = (solved / trials).toFixed(2) * 100 + '%';
    }
}