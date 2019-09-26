//function setValidationRule() {
//    $("#frmLogin").validate({
//        rules: {
//            LoginEmail: {
//                required: true,
//            },
//            LoginPassword: {
//                required: true,
//            },
//        }
//    });
//}

//function LogIn() {
//    if (!$("#frmLogin").valid()) {
//        return;
//    }

//    var data = getInputData();

//    $.ajax({                                           //this is Asyncronous =>
//        type: "POST",
//        url: "/User/LogIn",
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        data: data,
//        cache: false,
//        success: function (data) {                        //=> include call back function
//            if (data == "success") {
//                $("#pMessage").text("Welcome User");
              
//                location.reload();
//            }
//            else {
//                $("#pMessage").text("User Name or Password is invalid!");
//                $("#divError").modal('toggle');
//            }

//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });

//}

//function getInputData() {
//    var data = JSON.stringify({
//        "Email": $("#LoginEmail").val(),
//        "Password": $("#LoginPassword").val(),
//    });
//    return data;
//}

//function enter(e) {
//    e = e || window.event;
//    if (e.keyCode == 13) {
//        LogIn();
//    }
//}
