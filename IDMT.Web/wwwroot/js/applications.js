
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    var URL = "/Applications/GetAll";

    $('#tblData').DataTable({
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "filter": true,
        "ajax": {
            "url": URL,
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "name": "Name", "width": "65%" },
            {
                "render": function (data, type, row) {

                    return (row.isActive ? '<center><i class="bi bi-check-lg h4 text-success"></i></center>'
                        : '<center><i class="bi bi-x-lg h4 text-danger"></i></center>')
                }, "width": "15%",
            },
            {
                "data": "id",
                "render": function (data) {

                    return `<div class="text-center">
                             <a href="/applications/edit?applicationId=${data}" class='btn btn-info'  title='Edit Application' style='cursor:pointer;'>
										<i class="bi bi-pencil-square"></i> Edit
									</a>
                            <a href="/applications/delete?applicationId=${data}" class='btn btn-danger'  title='Delete Application' style='cursor:pointer;'>
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                }, "orderable": false, "width": "20%"
            }


        ],
        "language": {
            "emptyTable": "no data found."
        },
        // "width": "100%"
    });

}

