
<script src="~/Scripts/View/Index.js" type="text/javascript"></script>
<div class="row">
    <div class="col-sm-10">
        <h3>List of All Products </h3>
        <hr />
        <table id="tblProducts" class="table table-bordered table-condensed table-hover table-striped table-sm table-responsive">
            <thead>
                <tr>
                    <th>Product Id</th>
                    <th>Product Name</th>
                    <th>Supplier Name</th>
                    <th>Category Name</th>
                    <th>Qty Per Unit</th>
                    <th>Unit Price</th>
                    <th>Units In Stock</th>
                    <th>Units On Order</th>
                    <th>Reorder Level</th>
                    <th>Discontinued</th>
                </tr>
            </thead>
        </table>
    </div>

    <div class="row">
        <div class="col-sm-10">
            <h2>List of All Suppliers </h2>
            <a class="editor_create btn btn-success m-3">Create new Supplier</a>
            <table id="tblSuppliers" class="table table-bordered table-condensed table-hover table-striped table-sm">
                <thead>
                    <tr>
                        <th>Supplier ID</th>
                        <th>Company Name</th>
                        <th>Contact Name</th>
                        <th>Contact Title</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>Region</th>
                        <th>Postal Code</th>
                        <th>Country</th>
                        <th>Phone</th>
                        <th>Fax</th>
                        <th>HomePage</th>
                        <th>Edit/Delete</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-10">
            <h2>List of All Categories </h2>

            <table id="tblCategories" class="table table-bordered table-condensed table-hover table-striped table-sm table-responsive">
                <thead>
                    <tr>
                        <th>Category ID</th>
                        <th>Category Name</th>
                        <th>Description</th>
                        <th>Picture</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</div>