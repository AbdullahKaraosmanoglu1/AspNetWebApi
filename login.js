function loginUser() {
    var userLogin = {
        email: $('#emailInput').val(),
        password: $('#passwordInput').val()
    };

    $.ajax({
        url: "https://localhost:7238/api/Login/UserLogin",
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(userLogin),

        success: function (response) {
            console.log('Giriþ Baþarýlý');
            localStorage.setItem('token', response.data);
            console.log(response);
            window.location.href = 'index.html';
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

$(document).ready(function () {
    $('#loginBtn').click(function (event) {
        event.preventDefault();
        loginUser();
    });
});
