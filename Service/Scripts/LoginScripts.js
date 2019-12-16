$("#submit").click(function() {
    var username = $("#username").val();
    var password = $("#password").val();

    alert(username);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/api/Users/Login",
        data: JSON.stringify({
            Username: username,
            Password: password
        }),
        success: function(resultData) {
            window.location.replace("/Things/List");
        },
        error: function() {
            alert("Login failed");
        }
    });
});