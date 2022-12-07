var index = 0, interval;

function resume() {
    interval = setInterval(() => {
        document.images[index].src = './imgs/marble1.jpg';
        index = index == 4 ? 0 : index+1;
        document.images[index].src = './imgs/marble3.jpg';
    }, 200);
}

function pause() {
    clearInterval(interval);
}

document.addEventListener("DOMContentLoaded", function(event) { 
    resume();
});