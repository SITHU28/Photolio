function setValidationRule() {
    $("#frmProduct").validate({
        rules: {
            selFile: {
                required: true,
            },
            txtName: {
                required: true,
            },
            txtDescription: {
                required: true,
            },
            txtPrice: {
                required: true,
            },
            selCategory: {
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
            $('#imgPrev').attr('src', ImageDir.target.result);
        }
    }
}

function save() {
    if (!$("#frmProduct").valid()) {
        return;
    }
    var UserID = $("#hiUserId").val();
    var file = $("#selImage").get(0).files;
    var Name = $("#txtName").val();
    var Description = $("#txtDescription").val();
    var Price = $("#txtPrice").val();
    var CategoryId = $("#selCategory").val();

    var data = new FormData;

    data.append("UserID", UserID);
    data.append("ImageFile", file[0]);
    data.append("Name", Name);
    data.append("Description", Description);
    data.append("Price", Price);
    data.append("CategoryId", CategoryId);

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Product/Entry",
        contentType: 'application/json; charset=utf-8',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#sMessage").text("Saving Successful!");
                $("#divSuccess").modal('toggle');
            }
            else {
                //if (data == "duplicate") {
                //    $("#fMessage").text("Your Photo Name is already exist!");
                //} else {
                //    $("#fMessage").text("Saving is fail!");
                //}
                $("#divFailure").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmProduct").valid()) {
        return;
    }
    var UserID = $("#hiUserId").val();
    var Id = $("#hidId").val();
    var Version = $("#hidVersion").val();
    var file = $("#selImage").get(0).files;
    var Name = $("#txtName").val();
    var Description = $("#txtDescription").val();
    var Price = $("#txtPrice").val();
    var CategoryId = $("#selCategory").val();

    var data = new FormData;

    data.append("UserID", UserID);
    data.append("Id", Id);
    data.append("Version", Version);

    data.append("ImageFile", file[0]);
    data.append("Name", Name);
    data.append("Description", Description);
    data.append("Price", Price);
    data.append("CategoryId", CategoryId);

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Product/Edit",
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

function fillData(selectedCategoryId) {
    $("#selCategory").val(selectedCategoryId);
}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function remove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Product/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Deleting is successful.");
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

//function getInputData() {
//    return JSON.stringify({
//        "Photo": $("#selImage").get(0).files,
//        "Name": $("#txtName").val(),
//        "Description": $("#txtName").val(),
//        "Name": $("#txtName").val(),
//    });
//}

function convertToByteArray() {

    $.ajax({
        type: "GET",
        url: "/Product/GetFileData",
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

