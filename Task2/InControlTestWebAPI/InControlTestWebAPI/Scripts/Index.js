var editor;
$(document).ready(function () {
        // Load data into Products table 
             $('#tblProducts').DataTable({
            ordering: true,
            paging: true,
            searching: true,
            ajax: "https://localhost:44372/api/product",
            columns: [
                { data: 'ProductID', className: "text-right" },
                { data: 'ProductName' },
                { data: 'SupplierID', className: "text-right" },
                { data: 'CategoryID', className: "text-right" },
                { data: 'QuantityPerUnit', className: "text-right" },
                { data: 'UnitPrice', className: "text-right" },
                { data: 'UnitsInStock', className: "text-right" },
                { data: 'UnitsOnOrder', className: "text-right" },
                { data: 'ReorderLevel', className: "text-right" },
                { data: 'Discontinued' }
            ],
            dom: 'Bfrtip',
            buttons: [
                'excelHtml5',
                'pdfHtml5'
            ]

        });

      // Editor for Datatable

        editor = new $.fn.dataTable.Editor({

    idSrc: 'SupplierID',
    table: "#tblSuppliers",
    fields: [{
        "label": "SupplierID:",
         "name": "SupplierID"
          },{
        label: "Company Name:",
        name: "CompanyName"
            }, {
        label: "Contact Name:",
        name: "ContactName"
            }, {
        label: "Contact Title:",
        name: "ContactTitle"
            }, {
        label: "Address:",
        name: "Address"
            }, {
        label: "City:",
        name: "City"
            }, {
        label: "Region:",
        name: "Region"
            }, {
        label: "PostalCode:",
        name: "PostalCode"
            }, {
        label: "Country:",
        name: "Country"
            }, {
        label: "Phone:",
        name: "Phone"
            }, {
        label: "Fax:",
        name: "Fax"
            }, {
        label: "HomePage:",
        name: "HomePage"
}
]
});

// create a Supplier
        $('a.editor_create').on('click', function (e) {
        e.preventDefault();

    editor.create({
        title: 'Create new Supplier',
    buttons: 'Add'
});
});

// Edit Supplier
        $('#tblSuppliers').on('click', 'a.editor_edit', function (e) {
        e.preventDefault();

    editor.edit($(this).closest('tr'), {
        title: 'Edit record',
    buttons: 'Update'
});
});

// Delete a Supplier
        $('#tblSuppliers').on('click', 'a.editor_remove', function (e) {
        e.preventDefault();

    editor.remove($(this).closest('tr'), {
        title: 'Delete record',
    message: 'Are you sure you wish to remove this record?',
    buttons: 'Delete'
});
});

        $('#tblSuppliers').DataTable({
        ordering: true,
    paging: true,
    searching: true,
    ajax: "https://localhost:44372/api/supplier",
    columns: [
                {data: 'SupplierID', className: "text-right" },
                {data: 'CompanyName' },
                {data: 'ContactName' },
                {data: 'ContactTitle' },
                {data: 'Address' },
                {data: 'City' },
                {data: 'Region' },
                {data: 'PostalCode' },
                {data: 'Country' },
                {data: 'Phone' },
                {data: 'Fax' },
                {data: 'HomePage' },
                {
                    data: null,
                    className: "center",
                    defaultContent: '<a href="" class="editor_edit">Edit</a> / <a href="" class="editor_remove">Delete</a>'
                }
     ],
    dom: 'Bfrtip',
    buttons: [
        'excelHtml5',
        'pdfHtml5'

     ]

    });

        $('#tblCategories').DataTable({

        ordering: true,
        paging: true,
        searching: true,
        ajax: "https://localhost:44372/api/category",

        columns: [
                {data: 'CategoryID', className: "text-right" },
                {data: 'CategoryName' },
                {data: 'Description' },
                {
                    "data": "PictureBase64String",
                    "render": function (data) {

                        return '<img src="data:image/jpg;base64,' + data + '" />';


                    }
                },
            ],
        dom: 'Bfrtip',
        buttons: [
        'excelHtml5',
        'pdfHtml5'
        ]

    });
});
