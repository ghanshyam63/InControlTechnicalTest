Public Class ReOrderItemDTO
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property QuantityPerUnit As String
    Public Property UnitPrice As Nullable(Of Decimal)
    Public Property UnitsInStock As Nullable(Of Short)
    Public Property UnitsOnOrder As Nullable(Of Short)
    Public Property ReorderLevel As Nullable(Of Short)

End Class
