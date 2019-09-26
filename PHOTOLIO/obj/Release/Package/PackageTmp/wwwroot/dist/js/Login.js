//function setValidationRule() {
//    $("#frmLogin").validate({
//        rules: {
//            txtName: {
//                required: true,
//            },
//            txtPassword: {
//                required: true,
//            },
//        }
//    });
//}
//function login() {
//    if (!$("#frmLogin").valid()) {
//        return;
//    }

//    var data = getInputData();

//    $.ajax({
//        type: "POST",
//        url: "/Home/Index",
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        data: data,
//        cache: false,
//        success: function (data) {
//            if (data == "success") {
//                window.location = "/Home/Contactform";
//            } else {
//                $("#pMessage").text("User name or password is invalid.");
//                $("#divError").modal('toggle');
//            }
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//}

//function getInputData() {
//    return JSON.stringify({
//        "Name": $("#txtName").val(),
//        "Password": $("#txtPassword").val(),
//    });
//}

//function enter(e) {
//    e = e || window.event;
//    if (e.keyCode == 13) {
//        login();
//    }
//}