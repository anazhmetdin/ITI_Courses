var cards = [], rCards, index, moon = './imgs/Moon.gif';
var revealed = [], wrong = [], solved = 0, trials = 0, started = false;
var trialsElement, accuracyElement, startButton, resetButton;

var rightAudio  = new Audio('audios/aud1.mp3');
var wrongAudio1 = new Audio('audios/wrong0.mp3');
var wrongAudio2 = new Audio('audios/wrong1.mp3');
var wrongAudio = [wrongAudio1, wrongAudio2];

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
            document.images[i].onmouseup = reveal;
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

function reveal(event) {
    var img = event.target;
    if (started && solved != 6) {
        // display card
        img.src = rCards[img.id];
        // add img to revealed array if empty or img is different from the first clicked
        if (revealed.length === 0 || revealed[0].id != img.id) {
            revealed.push(img);
        }
    }

    // if two cards are revealed
    if (revealed.length == 2) {
        trials++;
        trialsElement.textContent = trials;
        check();
    }
}

function check() {
    // if two cards revealed
    if (solved != 6 && revealed.length == 2) {
        if (revealed[0].src == revealed[1].src) { // corret guess
            solved++;
            rightAudio.play();
            revealed[0].onmouseup = revealed[1].onmouseup = null;
        } else { // wrong guess, hide cards
            wrongAudio[Math.floor(Math.random() * wrongAudio.length)].play();
            wrong = [revealed[0], revealed[1]];
            revealed[1].onmouseleave = setWrongMoon;
        }
        
        // reset revealed array
        revealed = [];
        // update accuracy
        accuracyElement.textContent = (solved / trials).toFixed(2) * 100 + '%';
    }
}

function setWrongMoon() {
    wrong[0].src = wrong[1].src = moon;

    wrong[0].onmouseleave = wrong[1].onmouseleave = null;

    wrong = [];
}