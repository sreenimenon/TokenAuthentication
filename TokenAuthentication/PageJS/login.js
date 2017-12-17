"use strict";


var loginUser = function (event) {
    clearErrors();
    var userId = $('#login-userid').val();
    var password = $('#login-password').val();
    if (userId === '') {
        setErrorMessageToLogin('User email is mandatory.');
    } else if (password === '') {
        setErrorMessageToLogin('Password is mandatory.');
    } else {
        checkloginForUserService(userId, password);
    }
};

var clearErrors = function () {
    $('.error-message').html('');
};

var setErrorMessageToLogin = function (msg) {
    $('#login-error').html(msg);
};

var checkloginForUserService = function (username, password) {
    showOverlay();
    var saveDataObject = { "username": username, "password": password };
    $.ajax({
        type: "POST",
        url: "/api/user/login",
        data: JSON.stringify(saveDataObject),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (response) {
            var result = (response);
            console.log(response);
            if (response !== undefined) {
                localStorage.setItem('accesstoken', response);
                window.location.href = '/home/index/';
            }
            hideOverlay();
        },
        error: function (response) {
            console.log(response);
            if (response == undefined || response == "") {
                setErrorMessageToLogin("Error Occured.");
                hideOverlay();
            } else {
                setErrorMessageToLogin(response.responseJSON.message);
                hideOverlay();
            }

        }
    });
};

var hideOverlay = function () {
    var isHidden = $('#overlay').hasClass('hideEle');
    if (!isHidden) {
        $('#overlay').addClass('hideEle');
    }
};

var showOverlay = function () {
    var isHidden = $('#overlay').hasClass('hideEle');
    if (isHidden) {
        $('#overlay').removeClass('hideEle');
    }
};

var hideErrorMessage = function () {
    var isHidden = $('#main-error-message').hasClass('hideEle');
    if (!isHidden) {
        $('#main-error-message').addClass('hideEle');
    }
};
