$(function () {
  $(document).scroll(function () {
    var $nav = $(".navbar-fixed-top");
    $nav.toggleClass('scrolled', $(this).scrollTop() > $nav.height());
  });
});





window.onscroll = function() {myFunction()};

var navbar = document.getElementById("sticky-header");
var sticky = navbar.offsetTop;

function myFunction() {
	if (document.body.scrollTop > 500 || document.documentElement.scrollTop > 500) {

	  	  document.getElementById("navbar").style.backgroundColor =  "black";



 
	}
  
}// JavaScript Document