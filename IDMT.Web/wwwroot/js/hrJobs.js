
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    var URL = "/HrJobs/GetAll";

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
            { "data": "name", "name": "Name", "width": "80%" },
            {
                "data": "id",
                "render": function (data, type, row) {

                    return (`<div class="text-center">
                             <a href="/HrJobs/edit?hrJobId=${row.id}" class='btn btn-info' title='Edit HR Job'  style='cursor:pointer;'>
										<i class="bi bi-pencil-square"></i>
									</a>
                            <a href="/HrJobs/delete?hrJobId=${row.id}" class='btn btn-danger' title='Delete HR Job' style='cursor:pointer;'>
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>`);
                }, "orderable": false, "width": "20%"
            }


        ],
        "language": {
            "emptyTable": "no data found."
        },
        // "width": "100%"
    });

}

