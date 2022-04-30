var id = 0;
$(document).ready(function () {
    $(document).on("click", ".editRecord", editRecord)
        .on("click", ".handleSubmit", handleSubmit)
        .on("click", ".deleteRecord", deleteRecord);
    GetData();
});

function GetData() {
    $.ajax({
        type: 'POST',
        url: '/Home/GetEvenList',
        dataType: 'json',
        data: {},
        success: function (data) {
            var str = '';

            for (var i = 0; i < data.length; i++) {
                str += '';
                str += '<tr>';
                str += '<td class="text-center"><button class="button editRecord" data-id="' + data[i].Id + '" data-title="' + data[i].Title + '" data-completed="' + data[i].Completed + '">Edit</button></td>';
                str += '<td class="text-center">' + (i + 1) + '</td>';
                str += '<td>' + data[i].Title + '</td>';
                str += '<td class="text-center">' + (data[i].Completed ? "Completed" : "Not Completed") + '</td>';
                str += '<td class="text-center"><button class="button button3 deleteRecord" data-id="' + data[i].Id + '">Delete</button></td>';
                str += '</tr>';
            }
            if (str == "") {
                str = '<tr><td colspan="5">No Data</td></tr>';
            }

            $(".tbody").html(str);
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
}

function editRecord() {
    $(".form-div").removeClass("hide");
    id = $(this).data("id");
    $("#title").val($(this).data("title"));
    $("#status").val($(this).data("completed").toString());
}

function handleSubmit() {
    if (IsValidate()) {
        $.ajax({
            type: 'POST',
            url: '/Home/SaveEven',
            dataType: 'json',
            data: { id: id, title: $("#title").val(), status: $("#status").val() },
            success: function (data) {
                if (data == true) {
                    $(".form-div").addClass("hide");
                    GetData();
                    alert("Record Saved.");
                } else {
                    alert("There is some issue with request.");
                }
            },
            error: function (ex) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
    }
}

function IsValidate() {
    $(".errorMessage").remove();

    if ($.trim($("#title").val()) == "") {
        $("#title").after("<div class='errorMessage'>Required</div>");
        return false;
    }
    return true;
}
function deleteRecord() {
    id = $(this).data("id");
    if (confirm("Are you sure you want to delete this record?")) {
        $.ajax({
            type: 'POST',
            url: '/Home/DeleteEvenRecord',
            dataType: 'json',
            data: { id: id },
            success: function (data) {
                if (data == true) {
                    GetData();
                    alert("Record Deleted.");
                } else {
                    alert("There is some issue with request.");
                }
            },
            error: function (ex) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
    }
}