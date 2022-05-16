$(document).ready(function () {
    var oTable = $('#example').DataTable({
        /*   "processing": true,*/
        "serverSide": true,
        "filter": true, // this is for disable filter (search box)    
        "orderMulti": false, // for disable multiple column at once   
        "ajax": {
            "url": '/Home/LoadProductAgreements',
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false,
        },{
                'targets': [4, 5, 6, 7, 8, 9], /* column index */
                'orderable': false, /* true or false */
         }],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "username", "name": "UserName", "autoWidth": true },
            {
                "data": "productgroupcode", "name": "GroupCode", "autoWidth": true, "render": function (data, type, full, meta) {
                    return '<span data-toggle="tooltip" title="' + full.productgroupdescription + '">' + data + '</span>';
                }
            },
            {
                "data": "productnumber", "name": "ProductNumber", "autoWidth": true, "render": function (data, type, full, meta) {
                    return '<span data-toggle="tooltip" title="' + full.productdescription + '">' + data + '</span>';
                }
            },
            {
                "data": "effectivedate", "name": "EffectiveDate", "autoWidth": true, render: function (data, type, row) {
                    if (type === "sort" || type === 'type') {
                        return data;
                    }
                    return moment(data).format("MM-DD-YYYY");
                }
            },
            {
                "data": "expirationdate", "name": "ExpirationDate", "autoWidth": true, render: function (data, type, row) {
                    if (type === "sort" || type === 'type') {
                        return data;
                    }
                    return moment(data).format("MM-DD-YYYY");
                }
            },
            { "data": "productprice", "name": "ProductPrice", "autoWidth": true },
            { "data": "newprice", "name": "NewPrice", "autoWidth": true },
            {
                "data": "id", "render": function (data) {
                    return '<a class="popup btn btn-primary" href="/home/save/' + data + '">Edit</a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
                }
            }
        ]
    });
    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })
    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
            .html($pageContent)
            .dialog({
                draggable: false,
                autoOpen: false,
                resizable: false,
                model: true,
                title: 'Popup Dialog',
                height: 550,
                width: 600,
                close: function () {
                    $dialog.dialog('destroy').remove();
                }
            })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })
        $dialog.dialog('open');
    }
});
function DeleteData(Id) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(Id);
        return true;
    }
    else {
        return false;
    }
}
function Delete(Id) {
    var url = "Home/DeleteAgreement";
    $.post(url, { ID: Id }, function (data) {
        if (data == "Deleted") {
            alert("Delete Product Agreement!");            
        }
        else {
            alert("Something Went Wrong!");
        }
    });
}
