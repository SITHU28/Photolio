function setValidationRule() {
    $("#frmOrder").validate({
        rules: {
            txtProductId: {
                required: true,
            },
            txtDate: {
                required: true,
            },
            
            txtQuantity: {
                required: true,
            },
            txtTotalPrice: {
                required: true,
            },
            txtAddress: {
                required: true,
            },
            txtTownship: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmOrder").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Order/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Your order is successful");
            } else {
                $("#pMessage").text("Your order is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmOrder").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Order/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Updating Complete");
            } else {
                $("#pMessage").text("Updating is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "UserId": $("#hiUserId").val(),
        "ProductId": $("#hiProductId").val(),
        "Date": $("#txtDate").val().replace(/-/g, ''),
        "Quantity": $("#txtQuantity").val(),
        "TotalPrice": $("#txtTotalPrice").val(),
        "Address": $("#txtAddress").val(),
        "Township": $("#txtTownship").val(),
    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "ProductId": $("#hiProductId").val(),
        "Price": $("#txtPrice").val(),
        "Date": $("#txtDate").val().replace(/-/g, ''),
        "Quantity": $("#txtQuantity").val(),
        "TotalPrice": $("#txtTotalPrice").val(),
        "Address": $("#txtAddress").val(),
        "Township": $("#txtTownship").val(),
    });

    return data;
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

    $.ajax({
        type: "POST",
        url: "/Order/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Deleting is done");
            } else {
                $("#pMessage").text("Deleting is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function totalprice() {
    
    var price = parseInt("1", 1);

    var quantity = 0;
    price =  document.getElementById("txtPrice").value;
    quantity = document.getElementById("txtQuantity").value;
    document.getElementById("txtTotalPrice").value = price * quantity;
}
