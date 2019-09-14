function setValidationRule() {
    $("#frmContactUs").validate({
        rules: {
            CTtxtName: {
                required: true,
            },
            CTtxtEmail: {
                required: true,
            },
            CTtxtMessage: {
                required: true,
            },
        }
    });
}

function saveCTU() {
    if (!$("#frmContactUs").valid()) {
        return;
    }
    var data = JSON.stringify({      
        "Name": $("#CTtxtName").val(),
        "Email": $("#CTtxtEmail").val(),
        "Message": $("#CTtxtMessage").val(),
    });

    $.ajax({    //this is Asyncronous =>
        type: "POST",
        url: "/ContactUs/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Your Message is Sending Successful To PHOTOLIO!");
            }
            else {
                $("#pMessage").text("Try Again, there is error for sending message!");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}



function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),       
        "Name": $("#CTtxtName").val(),
        "Email": $("#CTtxtEmail").val(),
        "Message": $("#CTtxtMessage").val(),

        
    });
    return data;
}

function update() {
    if (!$("#frmContactUs").valid()) {
        return;
    }
    var data = getInputDataForUpdate();

    

    $.ajax({                                           //this is Asyncronous =>
        type: "POST",
        url: "/ContactUs/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Updating is Complete!");
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
        url: "/ContactUs/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {                        //=> include call back function
            if (data == "success") {
                $("#pMessage").text("Deleting is Complete!");
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



