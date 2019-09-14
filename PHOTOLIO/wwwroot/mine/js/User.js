function setValidationRule() {
    $("#frmUser").validate({
        rules: {
            selPosition: {
                required: true,
            },
            selFile: {
                required: true,
            },
            txtUserName: {
                required: true,
            },
            txtUserPassword: {
                required: true,
            },
            txtBIO: {
                required: true,
            },
            txtFullAddress: {
                required: true,
            },
            txtPhoneNo: {
                required: true,
            },
            txtEmail: {
                required: true,
            },
        }
    });
}
function ShowPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.readAsDataURL(input.files[0]);
        ImageDir.onload = function (ImageDir) {
            $('#ProfilePrev').attr('src', ImageDir.target.result);
        }
    }
}

function saveuser() {
    if (!$("#frmUser").valid()) {
        return;
    }
    //var data = getInputDataForUser();
   

    var file = $("#selProfile").get(0).files;
    var Name = $("#txtUserName").val();
    var Email = $("#txtEmail").val();
    var Password = $("#txtUserPassword").val();
    var UserBio = $("#txtBIO").val();
    var Address = $("#txtFullAddress").val();
    var Phone = $("#txtPhoneNo").val();

    var data = new FormData;

    data.append("ProfileImage", file[0]);
    data.append("Name", Name);
    data.append("Email", Email);
    data.append("Password", Password);
    data.append("UserBio", UserBio);
    data.append("FullAddress", Address);
    data.append("PhoneNo", Phone);
    

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/User/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Sign Up Successful!");
                $("#divSuccess").modal('toggle');
            }
            else if (data == "duplicate") {
                    $("#pMessage").text("Your Name is already exist!");
                } else {
                    $("#pMessage").text("Sign Up fail!");
                }
                $("#divFailure").modal('toggle');
            },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmUser").valid()) {
        return;
    }
    var Id = $("#hidId").val();
    var Version = $("#hidVersion").val();

    var file = $("#selProfile").get(0).files;
    var Name = $("#txtUserName").val();
    var Email = $("#txtEmail").val();
    var Password = $("#txtUserPassword").val();
    var UserBio = $("#txtBIO").val();
    var Address = $("#txtFullAddress").val();
    var Phone = $("#txtPhoneNo").val();

    var data = new FormData;

    data.append("Id", Id);
    data.append("Version", Version);

    data.append("ProfileImage", file[0]);
    data.append("Name", Name);
    data.append("Email", Email);
    data.append("Password", Password);
    data.append("UserBio", UserBio);
    data.append("FullAddress", Address);
    data.append("PhoneNo", Phone);


    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/User/Edit",
        contentType: 'application/json; charset=utf-8',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Updating Complete!");
            }
            else {
                $("#pMessage").text("Updating is fail!");
            }

            $("#divSuccess").modal('toggle');
        },

        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function userremove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/User/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Deleting is successful!");
            }
            else {
                $("#pMessage").text("Deleting is fail!");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData() {
    return JSON.stringify({
        "Profile": $("#selProfile").get(0).files,
        "Name": $("#txtName").val(),
        "Email": $("#txtEmail").val(),
        "Password": $("#txtUserPassword").val(),
        "UserBio": $("#txtBIO").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
    });
}

function convertToByteArray() {

    $.ajax({
        type: "GET",
        url: "/User/GetFileData",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {
            return data;
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}

var file;
function handleFileSelect() {
    if (!window.File || !window.FileReader || !window.FileList || !window.Blob) {
        alert('The File APIs are not fully supported in this browser.');
        return;
    }

    input = document.getElementById('selFile');
    if (!input) {
        alert("Um, couldn't find the fileinput element.");
    }
    else if (!input.files) {
        alert("This browser doesn't seem to support the `files` property of file inputs.");
    }
    else if (!input.files[0]) {
        alert("Please select a file before clicking 'Load'");
    }
    else {
        file = input.files[0];
        fr = new FileReader();
        fr.onload = receivedText;
        //fr.readAsText(file);
        fr.readAsText(file);
    }
}

function receivedText() {
    document.getElementById('editor').appendChild(document.createTextNode(fr.result));
}
/*--------------------------Login form ---------------------------*/
function LogIn() {
    if (!$("#frmLogin").valid()) {
        return;
    }
    function getInputData() {
        var data = JSON.stringify({
            "Email": $("#LoginEmail").val(),
            "Password": $("#LoginPassword").val(),
        });
        return data;
    }
    var data = getInputData();

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/User/LogIn",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Welcome User");

                location.reload();
            }
            else {
                $("#pMessage").text("User Name or Password is invalid!");
                $("#divError").modal('toggle');
            }

        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}

