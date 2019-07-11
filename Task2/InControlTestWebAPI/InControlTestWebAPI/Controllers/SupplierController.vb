Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports InControlTestWebAPI.InControlTestWebAPI

Namespace Controllers
    Public Class SupplierController
        Inherits System.Web.Http.ApiController

        Private db As New NORTHWNDEntities

        ' GET: api/Supplier
        Function GetSuppliers() As IHttpActionResult
            Dim Suppliers As List(Of SupplierViewModel) = Nothing
            Try

                Suppliers = db.Suppliers.Select(Function(sup) _
                    New SupplierViewModel With {
                        .SupplierID = sup.SupplierID,
                        .CompanyName = sup.CompanyName,
                        .Address = sup.Address,
                        .City = sup.City,
                        .ContactName = sup.ContactName,
                        .ContactTitle = sup.ContactTitle,
                        .Country = sup.Country,
                        .Fax = sup.Fax,
                        .HomePage = sup.HomePage,
                        .Phone = sup.Phone,
                        .PostalCode = sup.PostalCode,
                        .Region = sup.Region
                    }
                 ).ToList()

            Catch ex As Exception
                Return NotFound()
            End Try

            If Suppliers.Count = 0 Then
                Return NotFound()
            End If

            Return Ok(Suppliers)
        End Function

        ' GET: api/Supplier/5
        Async Function GetSupplier(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim supplier As Supplier = Nothing
            supplier = Await db.Suppliers.FindAsync(id)
            If IsNothing(supplier) Then
                Return NotFound()
            End If

            Return Ok(supplier)
        End Function

        Async Function PutSupplier(ByVal supplier As SupplierViewModel) As Task(Of IHttpActionResult)
            Dim supplierToAdd As Supplier = Nothing
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Try

                supplierToAdd.Address = supplier.Address
                    supplierToAdd.City = supplier.City
                    supplierToAdd.CompanyName = supplier.CompanyName
                    supplierToAdd.ContactName = supplier.ContactName
                    supplierToAdd.ContactTitle = supplier.ContactTitle
                    supplierToAdd.Country = supplier.Country
                    supplierToAdd.Fax = supplier.Fax
                    supplierToAdd.HomePage = supplier.HomePage
                    supplierToAdd.Phone = supplier.Phone
                    supplierToAdd.PostalCode = supplier.PostalCode
                    supplierToAdd.Region = supplier.Region
                db.Suppliers.Add(supplierToAdd)
                Await db.SaveChangesAsync()


            Catch ex As DbUpdateConcurrencyException

            End Try



            Return StatusCode(HttpStatusCode.Created)
        End Function

        ' POST: api/Supplier
        Async Function PostSupplier(ByVal id As Integer, ByVal supplier As SupplierViewModel) As Task(Of IHttpActionResult)
            Dim supplierToAdd As Supplier = Nothing
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            ElseIf SupplierExists(id) = False Then
                Return BadRequest("Supplier does'nt exist.")
            End If

            Try

                supplierToAdd.Address = supplier.Address
                    supplierToAdd.City = supplier.City
                    supplierToAdd.CompanyName = supplier.CompanyName
                    supplierToAdd.ContactName = supplier.ContactName
                    supplierToAdd.ContactTitle = supplier.ContactTitle
                    supplierToAdd.Country = supplier.Country
                    supplierToAdd.Fax = supplier.Fax
                    supplierToAdd.HomePage = supplier.HomePage
                    supplierToAdd.Phone = supplier.Phone
                    supplierToAdd.PostalCode = supplier.PostalCode
                    supplierToAdd.Region = supplier.Region
                db.Suppliers.Add(supplierToAdd)
                Await db.SaveChangesAsync()

            Catch ex As Exception
                ex.ToString()
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = supplier.SupplierID}, supplier)
        End Function

        ' DELETE: api/Supplier/5
        Async Function DeleteSupplier(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim supplier As Supplier = Await db.Suppliers.FindAsync(id)
            If IsNothing(supplier) Then
                Return NotFound()
            End If

            db.Suppliers.Remove(supplier)
            Await db.SaveChangesAsync()
            Return Ok(supplier)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SupplierExists(ByVal id As Integer) As Boolean
            Return db.Suppliers.Count(Function(e) e.SupplierID = id) > 0
        End Function
    End Class
End Namespace