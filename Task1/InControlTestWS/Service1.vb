Imports System.IO
Imports System.Threading
Imports System.Configuration
Imports System.Net.Http
Imports System.Web.Script.Serialization

Public Class Service1

    Protected Overrides Sub OnStart(ByVal args() As String)
        Console.WriteLine("Get Items To ReOrder Service started at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        Me.GetDataFromWebAPI()
    End Sub

    Protected Overrides Sub OnStop()
        Console.WriteLine("Get Items To ReOrder Service Stopped at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
    End Sub
    Private Schedular As Timer
    Public Async Sub GetDataFromWebAPI()
        Try
            Schedular = New Timer(New TimerCallback(AddressOf SchedularCallback))
            'Set the Default Time.
            Dim scheduledTime As DateTime = DateTime.MinValue


            scheduledTime = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings("ScheduledTime"))
            If DateTime.Now > scheduledTime Then
                'If Scheduled Time is passed set Schedule for the next day.
                scheduledTime = scheduledTime.AddDays(1)
            End If
            Dim client As New HttpClient
            Dim serializer As New JavaScriptSerializer()
            Dim data As String
            client.BaseAddress = New Uri("https://localhost:44372/")
            Dim response = client.GetAsync("api/GetAllProducts?Discontinued=false")
            data = Await response.Result.Content.ReadAsStringAsync()
            Dim dto = serializer.Deserialize(Of List(Of ReOrderItemDTO))(data)
            If dto.Count > 0 Then
                Console.WriteLine("Following Product should be Reordered.")
                Console.WriteLine("========================================================")
                Console.WriteLine("ProductID\t ProductName\t QtyPerUnit \t ReorderLevel \t UnitPrice \t UnitsInStock \t UnitsOnOrder")
                For Each item In dto

                    Console.WriteLine(item.ProductID + " \t" + item.ProductName + " \t" + item.QuantityPerUnit + " \t" + item.ReorderLevel + " \t" + item.UnitPrice + " \t" + item.UnitsInStock + " \t" + item.UnitsOnOrder)

                Next
            Else

            End If








        Catch ex As Exception
            Using serviceController As New System.ServiceProcess.ServiceController("IncontrolService")
                serviceController.[Stop]()
            End Using
        End Try
    End Sub
    Private Sub SchedularCallback(e As Object)
        Console.WriteLine("Simple Service Log: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        Me.GetDataFromWebAPI()
    End Sub
End Class
