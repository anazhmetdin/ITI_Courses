const image = document.getElementsByTagName('img')[0];
var index = 1, sliding;

function prev() {
    index = index==1 ? 6 : index-1;
    image.src = image.src.replace(/\/[0-9].jpg/, `/${index}.jpg`);
}

function next() {
    index = index==6 ? 1 : index+1;
    image.src = image.src.replace(/\/[0-9].jpg/, `/${index}.jpg`);
}

function start() {
    sliding = setInterval(() => {
        next();
    }, 500);
}

function stop() {
    clearInterval(sliding);
}