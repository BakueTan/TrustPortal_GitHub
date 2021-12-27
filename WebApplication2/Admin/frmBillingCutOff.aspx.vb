Imports System.Data.SqlClient
Public Class frmBillingCutOff
    Inherits System.Web.UI.Page
    Public cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
    Public cmd As SqlCommand
    Public sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = "BillingCutOff"
        If Not IsPostBack Then
            Dim period As String = ""
            sql = "select period from  resultscutoff "
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            Try
                period = cmd.ExecuteScalar()
                cnn.Close()
            Catch ex As Exception
                cnn.Close()
            End Try
            dpCutOffPeriod.SelectedValue = period
        End If


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
     
        sql = "update resultscutoff set period = '" & dpCutOffPeriod.SelectedValue & "'"
        cmd = New SqlCommand(sql, cnn)
        cnn.Open()


        Try
            cmd.ExecuteNonQuery()
            cnn.Close()
            lbstatus.Text = "Period Updated"
        Catch ex As Exception
            lbstatus.Text = ex.Message
            cnn.Close()
        End Try
    End Sub
End Class