// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//document.getElementById("test").onmouseover = function () {
//	document.getElementById("test").src = "/lib/images/star-empty.png";
//}

$(function () {
	$("img.ratingStar").mouseover(function () {
		giveRating(this, "star-yellow.png");
	});

	//$("img.ratingStar").mouseout(function () {
	//	giveRating($(this), "star-empty.png");
	//	refilRating($(this));
	//});
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

//function refilRating(img1) {
//	//var rt = $(img1).closest('tr').find("span.avr").text();
//	//var img = $(img1).closest('tr').find("img[id='" + parseInt(rt) + "']");
//	img.attr("src", "/lib/images/star-yellow.png").prevAll("img.ratingStar").attr("src", "/lib/images/star-yellow.png");
//}


//      $("img.ratingStar").click(function (e) {
//         // $("img.rating").unbind("mouseout mouseover click");
	//	$(this).css('color', 'red');
	//	// alert(e.currentTarget + ' was clicked!');
	//	// call ajax methods to update database
	//	var url = "/Movies/PostRating?rating=" + parseInt($(this).attr("id")) + "&mid=" + parseInt($(this).attr("mid"));
//          $.post(url, null, function (data) {
//              $(e.currentTarget).closest('tr').find('div.result').text(data).css('color','red') // $("#result").text(data);
	//	});
	//});


