Public Class ProductViewModel
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property SupplierID As Nullable(Of Integer)
    Public Property CategoryID As Nullable(Of Integer)
    Public Property QuantityPerUnit As String
    Public Property UnitPrice As Nullable(Of Decimal)
    Public Property UnitsInStock As Nullable(Of Short)
    Public Property UnitsOnOrder As Nullable(Of Short)
    Public Property ReorderLevel As Nullable(Of Short)
    Public Property Discontinued As Boolean
End Class
