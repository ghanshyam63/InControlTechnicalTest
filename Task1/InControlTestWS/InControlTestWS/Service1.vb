Imports System.IO
Imports System.Threading
Imports System.Configuration
Imports System.Net.Http

Public Class Service1

    Protected Overrides Sub OnStart(ByVal args() As String)
        Console.WriteLine("Get Items To ReOrder Service started at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        Me.GetDataFromWebAPI()
    End Sub

    Protected Overrides Sub OnStop()
        Console.WriteLine("Get Items To ReOrder Service Stopped at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
    End Sub
    Private Schedular As Timer
    Public Sub GetDataFromWebAPI()
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
            Dim response As HttpResponseMessage

            client.BaseAddress = New Uri("http://localhost:8888/")
            response = client.GetAsync("api/products/1").Result

            Dim dto = response.Content.ReadAsStreamAsync.Result



            'response.Content.ReadAsAsync < ImportResultDTO > ().Result


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
