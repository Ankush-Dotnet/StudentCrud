var dataTable;
$(document).ready(function(){
    loadDataTable()
})
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "Get",
            "data type":"json"
        },
        "columns": [
            { "data": "id", "width": "20%" },
            { "data": "firstName", "width": "20%" },
            { "data": "lastName", "width": "20%" },
            { "data": "class", "width": "20%" },
            { "data": "subject", "width": "20%" },
            { "data": "marks", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                             <a class="btn btn-info" href="/booklist/Upsert?id=${data}">Edit</a>
                              <a class="btn btn-danger" onclick=Delete("api/book?id=${data}")>Delete</a>
                               </div>
                                       `;
                }
            }
             ]
    })
}
function Delete(url) {
    swal({
        title: "Want To Delete Data ?",
        icon: "warning",
        text: "Delete information !!!",
        dangerModel: true,
        buttons : true
    }).then((willDelete)=> {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(
                           data .message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}