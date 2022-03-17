var video_container = document.querySelector(".videoPlayerContainer");
var playButton = document.querySelector(".button.play");
var fullscreenButton = document.querySelector(".button.fullscreen");
var volumeButton = document.querySelector(".button.volume");
var video_info_container = document.querySelector(".container.video_info_container");
var video = document.querySelector("#video");
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
	video_container.setAttribute("hovered", true);
	clearTimeout(hover_timer);
	hover_timer = setTimeout(() => {
		video_container.setAttribute("hovered", false);
	}, 2000);
}

function SkipTime(e) {
	video.currentTime += e;
	UpdateHover();
}
document.addEventListener("keydown", (e) => {
	//e.preventDefault();
	switch (e.keyCode) {
		case 37: SkipTime(-5); break;
		case 39: SkipTime(5); break;
		case 32: ToggleVideo(); break;
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
					video.currentTime = x / area.width * video.duration;
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
video.onload = () => loaded = true;


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
	video.play();
	paused = false;
	playButton.setAttribute("data-play", true);
}
function Pause() {
	video.pause();
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
	video.currentTime = x / rect.width * video.duration;
});

setInterval(() => {
	var rect = current_area.getBoundingClientRect();
	var t = video.currentTime / video.duration * rect.width;
	volume = (100 - volume_trigger.getAttribute("dragValueY"));
	current_trigger.style.left = t + "px";
	current_trigger.setAttribute("dragValueX", t);
	document.querySelector(".button.volume")
		.setAttribute("data-volume", volume > 80 ? 100 : volume > 50 ? 50 : 0);
	if (current_trigger.getAttribute('dragging') === 'true') {
		Pause();
		video.currentTime = (+current_trigger.getAttribute("dragValueX") / current_area.getBoundingClientRect().width) * video.duration;
	}
	var current_minutes = Math.floor(video.currentTime / 60);
	var current_seconds = Math.floor(video.currentTime % 60);

	duration_area.innerHTML = duration_area.innerHTML = `${current_minutes < 10 ? '0' + current_minutes : current_minutes}:${current_seconds < 10 ? '0' + current_seconds : current_seconds}`;

	var minutes = Math.floor(video.duration / 60);
	var seconds = Math.floor(video.duration % 60);
	overall_duration.innerHTML = `${minutes < 10 ? '0' + minutes : minutes}:${seconds < 10 ? '0' + seconds : seconds}`;

	AdjustTriggers();
}, 50);


function AdjustTriggers() {
	document.querySelector(".watching>.current")
		.style.width = current_trigger.getAttribute("dragValueX") + "px";
	document.querySelector(".volume_slider>.current_volume")
		.style.height = 100 - volume_trigger.getAttribute("dragValueY") + "px";
	video.volume = volume / 100;
}

video.addEventListener('progress', function () {
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