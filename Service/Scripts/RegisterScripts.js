$("#submit").click(function() {
    var username = $("#username").val();
    var password = $("#password").val();
    var cpassword = $("#cpassword").val();
    var email = $("#email").val();
    var fname = $("#fname").val();
    var lname = $("#lname").val();
    var phone = $("#phone").val();

    alert("Sending");
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/api/Users/Register",
        data: JSON.stringify({
            Username: username,
            Password: password,
            ConfirmPassword: cpassword,
            Email: email,
            FName: fname,
            LName: lname,
            PhoneNumber: phone
        }),
        success: function(resultData) {
            window.location.replace("/Things/List");
        },
        
    });
});

