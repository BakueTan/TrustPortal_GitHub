Imports System.Data.SqlClient

Partial Public Class Reports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Try
            Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
            Dim cmd As SqlCommand
            Dim sum As Double = 0.0
            ' Dim section As String
            '  Dim drr As SqlDataReader
            Dim sql As String = " select sum(amount) from ledgertransactions where accnumber = '" & Session("userName") & "'"
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            Try
                sum = cmd.ExecuteScalar.ToString
            Catch ex As Exception
                sum = 0.01
            End Try

            If sum <= 0 Then



                Response.Redirect("~/Students/Redirection.aspx")
            Else
                Response.Redirect("~/Students/Unpaid.aspx")
            End If




        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try





    End Sub


End Class