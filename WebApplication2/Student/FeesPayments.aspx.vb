Imports System.Data.SqlClient

Partial Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = "FeesPayments"

        'tected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim cmd As SqlCommand
        Dim sum As Decimal
        Dim bbf As String = "0.00"
        Dim sql2 As String = ""

        ' sql2 = "select period from "
        Dim sql As String = " select sum(amount) from vwLedgertrans where accnumber  = '" & Session("userName") & "' and pperiod <= ( select period from resultscutoff)"
        ' Dim sql1 As String = " select bbf from ledgerbbf where accnumber  = '" & Session("userName") & "'"
        cmd = New SqlCommand(sql, cnn)
        Try
            cnn.Open()

            sum = cmd.ExecuteScalar

        Catch ex As Exception
        Finally
            cnn.Close()
        End Try
        sum = Math.Round(sum, 2)






        Label1.Text = "Account balance is $ " & sum & ",below is a detailed statement of the Payments"



    End Sub


End Class