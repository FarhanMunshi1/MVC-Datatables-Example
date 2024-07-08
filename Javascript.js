
$(document).ready(function () {
	
	// event listener that refreshes datatable whenever something is changed in search box
    $("#SearchBox").on("keyup", function () {
        $('#my-table').DataTable().ajax.reload();
    });

    CreateTable();
});

function CreateTable() {
    var table = $('#my-table').DataTable({
        "ordering": false,
        "proccessing": true,
        "serverSide": true,
        "searching": false,
        "ajax": {
            url: "/home/GetData",                          //where Ajax will get the data
            type: 'POST',                                   //send a POST request
            "dataSrc": function (json) {
                UpdatePageWithResults(json);                //The data is in JSON form
                return json.data;
            },
            'data': function (d) {
                d.searchString = $("#SearchBox").val(),     //the search string contains whatever is in the search box
                d.customValue = 33    					// custom value
            }
        },
        "lengthMenu": [10, 20, 30],
        "pageLength": 10,
        "order": [[0, 'asc']],
        "language": {
            "search": "",
            "searchPlaceholder": "Search...",
            "select": {
                "rows": ""
            }
        },
        "columns": [
            // data name must match the DataObject name
            { "data": "StudentId", "bSortable": false, },
            { "data": "Name", "bSortable": true, },
            { "data": "Age", "bSortable": true, },
        ]
    });
}

function UpdatePageWithResults(json) {
    $('#totalRecs').html("There are a total of " + json.recordsTotal + " records!");
}
