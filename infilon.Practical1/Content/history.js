$(document).ready(function () {
    GetData();
});

function GetData() {
    $.ajax({
        type: 'POST',
        url: '/Home/GetHistoryList',
        dataType: 'json',
        data: {},
        success: function (data) {
            var str = '';

            for (var i = 0; i < data.length; i++) {
                str += '';
                str += '<tr>';
                str += '<td class="text-center">' + (i + 1) + '</td>';
                str += '<td class="text-center">' + data[i].ReferenceId + '</td>';
                str += '<td>' + data[i].Title + '</td>';
                str += '<td class="text-center">' + (data[i].Completed ? "Completed" : "Not Completed") + '</td>';
                str += '<td class="text-center">' + data[i].Action + '</td>';
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