Imports System.Data.SqlClient
Partial Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim cmd As SqlCommand
        Dim sql, section As String
        Try
            sql = " select section from forms inner join studentpersonaldetails on program = forms " & _
                " where studentid = '" & Session("userName") & "'"
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()

            section = cmd.ExecuteScalar.ToString
            If section = "High School" Then
                Response.Redirect("HighSchoolReport.aspx")
            ElseIf section = "ICT" Then
                Response.Redirect("StudentReport.aspx")
            ElseIf section = "Business School" Then

            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
        

    End Sub

End Class