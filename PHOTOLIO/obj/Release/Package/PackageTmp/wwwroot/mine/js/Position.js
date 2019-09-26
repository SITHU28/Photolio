function setValidationRule() {
    $("#frmPosition").validate({
        rules: {
            txtName: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmPosition").valid()) {
        return;
    }
   
    var data = JSON.stringify({
        "Name": $("#txtName").val(),
    });

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Position/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Saving Complete!");
            }
            else {
                $("#pMessage").text("Saving is fail!");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}



function update() {
    if (!$("#frmPosition").valid()) {
        return;
    }

    var data = JSON.stringify({
        "Name": $("#txtName").val(),
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
    });

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Position/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
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

function remove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/Position/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Deleting is done!");
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