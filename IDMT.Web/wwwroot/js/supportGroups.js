
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    var URL = "/SupportGroups/GetAll";

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
            { "data": "name", "name": "Name", "width": "40%" },
            { "data": "email", "name": "Email", "width": "25%" },
            {
                "render": function (data, type, row) {

                    return (row.isActive ? '<center><i class="bi bi-check-lg h4 text-success"></i></center>'
                        : '<center><i class="bi bi-x-lg h4 text-danger"></i></center>')
                }, "width": "15%",
            },
            {
                "data": "id",
                "render": function (data, type, row) {

                    return (row.isActive ? `<div class="text-center">
                             <a href="/SupportGroups/edit?supportGroupId=${row.id}" class='btn btn-info' title='Edit Support Group'  style='cursor:pointer;'>
										<i class="bi bi-pencil-square"></i>
									</a>
                            <a href="/SupportGroups/delete?supportGroupId=${row.id}" class='btn btn-danger' title='Delete Support Group' style='cursor:pointer;'>
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>`
                        : `<div class="text-center"></div>`);
                }, "orderable": false, "width": "20%"
            }


        ],
        "language": {
            "emptyTable": "no data found."
        },
        // "width": "100%"
    });

}

