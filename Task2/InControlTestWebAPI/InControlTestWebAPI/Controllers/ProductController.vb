Imports System.Net
Imports System.Web.Http
Imports System
Imports System.Data.Entity
Imports InControlTestWebAPI
Imports InControlTestWebAPI.InControlTestWebAPI

Public Class ProductController
    Inherits ApiController


    ' GET api/GetAllProducts
    Public Function GetAllProducts() As IHttpActionResult
        Dim Products As List(Of ProductViewModel) = Nothing
        Try
            Using ctx As New NORTHWNDEntities
                Products = ctx.Products.Select(Function(prod) _
                    New ProductViewModel With {
                        .ProductID = prod.ProductID,
                        .SupplierID = prod.SupplierID,
                        .CategoryID = prod.CategoryID,
                        .QuantityPerUnit = prod.QuantityPerUnit,
                        .UnitPrice = prod.UnitPrice,
                        .UnitsInStock = prod.UnitsInStock,
                        .UnitsOnOrder = prod.UnitsOnOrder,
                        .ReorderLevel = prod.ReorderLevel,
                        .Discontinued = prod.Discontinued
                    }
                 ).ToList()
            End Using
        Catch ex As Exception
            Return NotFound()
        End Try

        If Products.Count = 0 Then
            Return NotFound()
        End If

        Return Ok(Products)
    End Function
    ' GET api/GetProductsNeedToReOrder
    Public Function GetProductsNeedToReOrder(Discontinued As Boolean) As IHttpActionResult
        Dim ReOrderItems As IList(Of ReOrderItemViewModel) = Nothing

        Using ctx As New NORTHWNDEntities
            ReOrderItems = ctx.Products.Where(Function(p) p.UnitsInStock <= p.ReorderLevel And p.Discontinued = Discontinued).Select(Function(prod) _
                New ReOrderItemViewModel With {
                    .ProductID = prod.ProductID,
                    .QuantityPerUnit = prod.QuantityPerUnit,
                    .UnitPrice = prod.UnitPrice,
                    .UnitsInStock = prod.UnitsInStock,
                    .UnitsOnOrder = prod.UnitsOnOrder,
                    .ReorderLevel = prod.ReorderLevel
                    }
                ).ToList()
        End Using
        If ReOrderItems.Count = 0 Then
            Return NotFound()
        End If

        Return Ok(ReOrderItems)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
