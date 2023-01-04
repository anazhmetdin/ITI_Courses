const video = document.getElementsByTagName('video')[0];

const current = document.getElementById('current');
const total   = document.getElementById('total');
const time    = document.getElementById('currentTime');
const speed   = document.getElementById('speed');

video.onloadeddata = () => {
    time.max = video.duration;
    total.innerText = (video.duration/60).toFixed() + ':' + (video.duration % 60).toFixed().padStart(2, '0');
};

video.ontimeupdate = () => {
    time.value = video.currentTime;
    current.innerText = (video.currentTime/60).toFixed() + ':' + (video.currentTime % 60).toFixed().padStart(2, '0');
};

Array.prototype.map.call(document.getElementsByClassName('rate'), (element) => {
    element.oninput = () => {
        video[element.id] = element.value;
    }
});

Array.prototype.map.call(document.getElementsByClassName('controller'), (element) => {
    element.onclick = () => {
        video[element.id]();
    }
});

document.getElementById('reset').onclick = () => {
    video.currentTime = 0;
};

Array.prototype.map.call(document.getElementsByClassName('skip'), (element) => {
    element.onclick = () => {
        video.currentTime += Number.parseInt(element.value);
    }
});

document.getElementById('end').onclick = () => {
    video.currentTime = video.duration;
};

document.getElementById('mute').onclick = (event) => {
    video.muted = !video.muted;
    event.target.classList.toggle('active');
};

document.getElementById('playbackRate').onchange = (event) => {
    speed.innerText = event.target.value;
};