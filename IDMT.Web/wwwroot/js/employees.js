
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    var URL = "/Employees/GetAll";

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
            { "data": "id", "name": "Id", "width": "10%" },
            { "data": "firstName", "name": "FirstName", "width": "15%" },
            { "data": "fatherName", "name": "FatherName", "width": "15%" },
            { "data": "lastName", "name": "LastName", "width": "15%" },
            { "data": "spouseName", "name": "SpouseName", "width": "15%" },
/*            { "data": "lastSpouse", "name": "LastSpouse", "width": "10%" },*/
            {
                "data": "id",
                "render": function (data) {

                    return `<div class="text-center">
                             <a href="/employees/update?employeeId=${data}" class='btn btn-info'  style='cursor:pointer;'>
										<i class="bi bi-pencil-square"></i> Edit
									</a>
                            <a href="/employees/delete?employeeId=${data}" class='btn btn-danger' style='cursor:pointer;'>
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

