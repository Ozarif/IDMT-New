// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

	SetActiveLinkInNavbar();

});

function SetActiveLinkInNavbar() {
	//var currentLocation = window.location.href;
	var currentLocation = window.location.pathname;
	$('.navbar-nav').find('a').each(function () {
		console.log($(this).attr('href'));

		$(this).removeClass('active');

		if ($(this).attr('href') === currentLocation) {
			$(this).addClass('active');
		}
	});
}