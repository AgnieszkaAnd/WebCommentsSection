// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


// skrot do funkcji document.load: $(functon() {...kod...})
$(function () {
	$("img.ratingStar").mouseover(function (e) {
		// this w JS można podmienić, najlepiej dać tutaj: mouseover(function (element) { ... uzycie element ... } - b.bezpieczne
		// nie polegać na this!!!; Angular i inne biblioteki podmieniają specjalnie this
		giveRating(e.target, "star-yellow.png");
	});

	$("img.ratingStar").mouseout(function () {
		giveRating(this, "star-empty.png");
		giveRating(this.previousElementSibling, "star-yellow.png");
	});


	$("img.ratingStar").click(function () {
		// disable stars events after first onclick - not possible to update rating
		// (user must reload page to update rating)
		$("img.ratingStar").unbind("mouseout mouseover click");

		var rating = 0;
		var starsCollection = document.getElementsByClassName("ratingStar");
		var stars = Array.from(starsCollection);
		stars.forEach(function (element) {
			// count if rating contains yellow star
			if (element.src.indexOf("star-yellow.png") != -1) {
				rating++;
			};
		});

		$("#rating").setAttribute("value", rating);

	});
});


function prevAll(element) {
	var result = [];

	while (element = element.previousElementSibling)
		result.push(element);
	return result;
}

function giveRating(img, image) {
	img.src = "/lib/images/" + image;
	previousStarsToFill = prevAll(img);
	previousStarsToFill.forEach(function (item) {
		item.setAttribute('src', "/lib/images/" + image);
	});
}
