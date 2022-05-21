var video_container = document.querySelector(".videoPlayerContainer");
var playButton = document.querySelector(".button.play");
var fullscreenButton = document.querySelector(".button.fullscreen");
var volumeButton = document.querySelector(".button.volume");
var video_info_container = document.querySelector(".container.video_info_container");
var videoPlayer = document.querySelector("#videoPlayer");
var duration_area = document.querySelector(".progress_bar>.time");
var overall_duration = document.querySelector(".info_wrapper>.duration");
var buffering_area = document.querySelector(".buffering");

var paused = true;
var volume = 100;
var temp_volume = 50;

var hover_timer;

video_container.addEventListener("mousemove", UpdateHover);
video_container.addEventListener("click", UpdateHover);

function UpdateHover() {
    if (episodesSlider.getAttribute("data-visible") === 'true') {
        video_container.setAttribute("hovered", false);
    } else {
        video_container.setAttribute("hovered", true);
        clearTimeout(hover_timer);
        hover_timer = setTimeout(() => {
            video_container.setAttribute("hovered", false);
        }, 2000);
    }
}

function SkipTime(e) {
    videoPlayer.currentTime += e;
    UpdateHover();
}

document.addEventListener("keydown", (e) => {
    switch (e.keyCode) {
        case 37: SkipTime(-5); break;
        case 39: SkipTime(5); break;
        case 32: ToggleVideo(); break;
        case 70: ToggleFullscreen(); break;
        default: break;
    }
});
// draggable start

var draggable = document.querySelectorAll("*[draggable]");
var draggable_container = document.querySelectorAll("*[dragArea]");

var temp_mouse = { x: 0, y: 0 };
var mouse = { x: 0, y: 0 };
var mouseDelta = { x: 0, y: 0 };
var mousePressed = false;

var render = () => {
    requestAnimationFrame(render);
    mouseDelta = { x: mouse.x - temp_mouse.x, y: mouse.y - temp_mouse.y }
    temp_mouse.x = mouse.x;
    temp_mouse.y = mouse.y;
}
render();
document.addEventListener("mousemove", e => {
    mouse.x = e.clientX;
    mouse.y = e.clientY;
    if (mousePressed) {
        draggable.forEach(v => {
            if (v.getAttribute("dragging") === 'true') {
                var area = GetDragArea(v.getAttribute("dragName"));
                var y = mouse.y - area.top > 0 ?
                    mouse.y - area.bottom > 0 ? area.height : mouse.y - area.top : 0;
                var x = mouse.x - area.left > 0 ?
                    mouse.x - area.right > 0 ? area.width : mouse.x - area.left : 0;

                if (v.getAttribute("dragAxis") == 'y' || v.getAttribute("dragAxis") == 'both')
                    v.style.top = y + "px";
                if (v.getAttribute("dragAxis") == 'x' || v.getAttribute("dragAxis") == 'both')
                    v.style.left = x + "px";
                v.setAttribute("dragValueX", x);
                v.setAttribute("dragValueY", y);
                if (v.getAttribute("class") == "current_trigger") {
                    videoPlayer.currentTime = x / area.width * videoPlayer.duration;
                }
            }
        });
    }
});

document.addEventListener("mousedown", e => {
    mousePressed = true;
});
document.addEventListener("mouseup", e => {
    mousePressed = false;
    draggable.forEach(v => v.setAttribute("dragging", false));
});

function GetDragArea(e) {
    return document
        .querySelectorAll(`*[dragArea][dragName='${e}']`)[0]
        .getBoundingClientRect();;
}
draggable.forEach(v => {
    v.setAttribute("dragValueX", 0);
    v.setAttribute("dragValueY", 0);
});
draggable.forEach(v => v.addEventListener("mousedown", e => {
    v.setAttribute("dragging", true);
    v.setAttribute("dragValueX", 0);
    v.setAttribute("dragValueY", 0);
}));

// draggable end

document.onfullscreenchange = (e) => {
    if (document.fullscreenElement) {
        fullscreenButton.setAttribute("data-fullscreen", true);
    } else {
        Compress();
    }
}

var loaded = false;
videoPlayer.onload = () => loaded = true;

function ToggleFullscreen() {
    fullscreenButton.getAttribute("data-fullscreen") === 'true' ? Compress() : Expand();
}

function ToggleVideo() {
    paused ? Play() : Pause();
}
function ToggleVolume() {
    volume = volume == 0 ? temp_volume : 0;
}
function Expand() {
    fullscreenButton.setAttribute("data-fullscreen", true);
    if (video_container.requestFullscreen) {
        video_container.requestFullscreen();
    } else if (video_container.webkitRequestFullscreen) { /* Safari */
        video_container.webkitRequestFullscreen();
    } else if (video_container.msRequestFullscreen) { /* IE11 */
        video_container.msRequestFullscreen();
    }
}
function Compress() {
    fullscreenButton.setAttribute("data-fullscreen", false);
    document.exitFullscreen();
}
function Play() {
    videoPlayer.setAttribute("episodes", false);
    videoPlayer.play();
    paused = false;
    playButton.setAttribute("data-play", true);
}
function Pause() {
    videoPlayer.setAttribute("episodes", true);
    videoPlayer.pause();
    paused = true;
    playButton.setAttribute("data-play", false);
}

var current_trigger = document.querySelector(".watching>.current_trigger");
var buffered = document.querySelector(".watching>.loaded");
var volume_trigger = document.querySelector(".volume_slider>.volume_trigger");

var current_area = document.querySelector(".watching");

current_area.addEventListener("mousedown", e => {
    var rect = current_area.getBoundingClientRect();
    var x = (e.clientX - rect.left);
    current_trigger.setAttribute("dragValueX", x);
    current_trigger.style.left = x + "px";
    videoPlayer.currentTime = x / rect.width * videoPlayer.duration;
});

setInterval(() => {
    var rect = current_area.getBoundingClientRect();
    var t = videoPlayer.currentTime / videoPlayer.duration * rect.width;
    volume = (100 - volume_trigger.getAttribute("dragValueY"));
    current_trigger.style.left = t + "px";
    current_trigger.setAttribute("dragValueX", t);
    document.querySelector(".button.volume")
        .setAttribute("data-volume", volume > 80 ? 100 : volume > 50 ? 50 : 0);
    if (current_trigger.getAttribute('dragging') === 'true') {
        Pause();
        videoPlayer.currentTime = (+current_trigger.getAttribute("dragValueX") / current_area.getBoundingClientRect().width) * videoPlayer.duration;
    }
    var current_minutes = Math.floor(videoPlayer.currentTime / 60);
    var current_seconds = Math.floor(videoPlayer.currentTime % 60);

    duration_area.innerHTML = duration_area.innerHTML = `${current_minutes < 10 ? '0' + current_minutes : current_minutes}:${current_seconds < 10 ? '0' + current_seconds : current_seconds}`;

    var minutes = Math.floor(videoPlayer.duration / 60);
    var seconds = Math.floor(videoPlayer.duration % 60);
    overall_duration.innerHTML = `${minutes < 10 ? '0' + minutes : minutes}:${seconds < 10 ? '0' + seconds : seconds}`;

    AdjustTriggers();
}, 50);


function AdjustTriggers() {
    document.querySelector(".watching>.current")
        .style.width = current_trigger.getAttribute("dragValueX") + "px";
    document.querySelector(".volume_slider>.current_volume")
        .style.height = 100 - volume_trigger.getAttribute("dragValueY") + "px";
    videoPlayer.volume = volume / 100;
}

videoPlayer.addEventListener('progress', function () {
    try {
        var range = 0;
        var bf = this.buffered;
        var time = this.currentTime;

        while (!(bf.start(range) <= time && time <= bf.end(range))) {
            range += 1;
        }
        var loadStartPercentage = bf.start(range) / this.duration;
        var loadEndPercentage = bf.end(range) / this.duration;
        var loadPercentage = loadEndPercentage - loadStartPercentage;
        buffering_area.setAttribute("buffering", false);
        buffered.style.width =
            loadPercentage * +current_area.getBoundingClientRect().width + 'px';
    } catch {
        buffering_area.setAttribute("buffering", true);
    }
});


var episodesSlider = document.querySelector('.episodes');
var episodesWrapper = document.querySelector('.episodes>.wrapper');
var episodes = document.querySelectorAll('.episode');

var currentEpisode = 1;
AdjustEpisodes();
episodesSlider.addEventListener('wheel', e => {
    e.preventDefault();
    if (e.deltaY < 0 && currentEpisode != 1)
        currentEpisode--;
    if (e.deltaY > 0 && currentEpisode != episodes.length - 1)
        currentEpisode++;

    AdjustEpisodes();
});

function GetEpisode(e) {
    return document.querySelector(`.episode[data-episode="${e}"]`);
}
function AdjustEpisodes() {
    episodes.forEach((v, i) => {
        v.setAttribute('active', false);
        let _t = Math.abs((i + 1) - currentEpisode);
        v.style.left = _t * _t * 20 + 'px';
    });
    let sliderHeight = episodesSlider.getBoundingClientRect().height;
    let _current = GetEpisode(currentEpisode);
    _current.setAttribute('active', true);
    episodesWrapper.style.top = (+_current.getAttribute('data-episode') * -110 + sliderHeight / 2) + 'px';
}
function ToggleEpisodes() {
    episodesSlider.setAttribute("data-visible", episodesSlider.getAttribute("data-visible") !== 'true');
    Pause();
}