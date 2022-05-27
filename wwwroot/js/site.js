// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Slider
let counter = 1;
setInterval(function () {
    document.getElementById('radio-button-' + counter).checked = true;
    counter++;
    if (counter > 4) {
        counter = 1;
    }
}, 3000)
//End of Slider

//Contact Form in _Layout.cshtml