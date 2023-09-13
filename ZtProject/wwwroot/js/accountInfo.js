$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/AccountInfo/getall' },
        columns: [
            { data: 'client.name', "width": "15%" },
            { data: 'iban', "width": "15%" },
            { data: 'accountType', "width": "15%" },
            { data: 'accountBalance', "width": "15%" },
            { data: 'accountStatus', "width": "15%" },
            { data: 'openingDate', "width": "15%" },
            {
                data: 'id',

                "render": function (data) {
                    return `<div class ="w-75 btn-group" role="group">
                  <a href="AccountInfo/Edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit </a> 
                    </div>`
                },

                "width": "15%"
            }
        ]

    });
}