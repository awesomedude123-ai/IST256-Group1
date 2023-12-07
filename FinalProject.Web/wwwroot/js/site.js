// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#submit").click(function () {
        if (validate()) {
            $("#submit").removeClass("btn-danger btn-warning").addClass("btn-success");
            $("#submit").prop("disabled", false);
            alert("Your order has been processed and went through successfully!");

        }
    });
});

function validate() {
    var inputName = $("#inputName").val();
    var inputEmail = $("#inputEmail").val();
    var inputAddress = $("#inputAddress").val();
    var inputAddress2 = $("#inputAddress2").val();
    var inputCity = $("#inputCity").val();
    var inputState = $("#inputState").val();
    var inputZip = $("#inputZip").val();
    var errorMessages = [];

    if (inputName === "") {
        errorMessages.push("Please enter your name");
    }

    if (inputEmail === "") {
        errorMessages.push("Please enter a valid email");
    }

    if (inputAddress === "" || inputAddress2 === "") {
        errorMessages.push("Please enter a valid address");
    }

    if (inputCity === "" ) {
        errorMessages.push("Please enter your city");
    }
    
    var zipCheck = /^\d{5}$/;
    if (!zipCheck.test(inputZip)) {
        errorMessages.push("Please enter a valid zip code");
    }

    if (errorMessages.length > 0) {
        alert("Please update the following:\n\n" + errorMessages.join("\n"));
        return false;
    }

    return true;
}
