document.addEventListener('DOMContentLoaded', function () {
	var splide = new Splide('.splide', {
		type: 'loop',
		drag: 'free',
		snap: true,
		perPage: 5,
		classes: {
			arrows: 'splide__arrows your-class-arrows',
			arrow: 'splide__arrow your-class-arrow',
			prev: 'splide__arrow--prev your-class-prev',
			next: 'splide__arrow--next your-class-next',
		},
	});

	splide.mount();
});