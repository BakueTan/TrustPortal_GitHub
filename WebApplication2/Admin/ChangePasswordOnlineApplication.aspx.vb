Imports System.Data.SqlClient
Public Class ChangePassword

    Inherits System.Web.UI.Page


    Public sql As String
    Public cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TextBox1.Text = Session("Password")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        parameters = New List(Of SqlParameter)
        param = New SqlParameter("@pass", txtOldPassword.Text)
        '    parameters.Add(param)

        If Page.IsValid Then
            sql = "select * from NewStudRegistration where reg_email = '" & Session("Email") & "' and reg_password = @pass "
            cmd = New SqlCommand(sql, cnn)
            cmd.Parameters.Add(param)
            cnn.Open()
            Try
                drr = cmd.ExecuteReader()
                If drr.HasRows Then
                    cnn.Close()
                    sql = "update NewStudRegistration set reg_password = @pass , reg_passwordreset = '0' where reg_email = '" & Session("Email") & "'"
                    cmd = New SqlCommand(sql, cnn)
                    cnn.Open()
                    param = New SqlParameter("@pass", TextBox2.Text)
                    '    parameters.Add(param)
                    cmd.Parameters.Add(param)
                    cmd.ExecuteNonQuery()
                    ErrorStatus.Text = "Reset Successful"
                Else
                    ErrorStatus.Text = "Wrong Password"
                End If

            Catch ex As Exception
                ErrorStatus.Text = ex.Message
            End Try
        Else
            ErrorStatus.Text = "Validation failed" 
        End If
       
    End Sub
End Class