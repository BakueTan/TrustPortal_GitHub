
Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class ApplicationLogin
    Inherits System.Web.UI.Page
    Public sql As String
    Public cnn As SqlConnection
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    '    Response.Redirect("~/Student/OnlineApplication/ApplcationSignUp.aspx")



    'End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Resetpassword As Boolean = False
        cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)




        If Page.IsValid Then
            Dim drr As SqlDataReader
            Dim email As String = ""

            Try
                cnn.Open()
                sql = "spOnlineApplicationLogin"
                cmd = New SqlCommand(sql, cnn)
                cmd.CommandType = CommandType.StoredProcedure

                parameters = New List(Of SqlParameter)

                param = New SqlParameter("@password", TextBox2.Text)
                parameters.Add(param)

                param = New SqlParameter("@acc", Trim(TextBox1.Text))
                parameters.Add(param)

                param = New SqlParameter("@type", "Reg")
                parameters.Add(param)

                For Each par As SqlParameter In parameters
                    cmd.Parameters.Add(par)
                Next


                drr = cmd.ExecuteReader


                If drr.HasRows Then
                    While drr.Read
                        Session("Group") = "Application"
                        Session("userName") = drr("Reg_FullName").ToString
                        Session("Email") = drr("Reg_Email").ToString
                        Resetpassword = drr("Reg_PasswordReset")
                        Session("Reference") = drr("Reg_ApplicationReference").ToString
                    End While
                    If Resetpassword Then
                        Response.Redirect("~/Admin/ChangePasswordOnlineApplication.aspx")
                    Else
                        Response.Redirect("~/Student/OnlineApplication/ApplicationForm.aspx")
                    End If



                End If

            Catch ex As Exception

                errorstatus.Text = ex.Message
            Finally
                cnn.Close()
            End Try
        Else
            errorstatus.Text = "Validation failed"
        End If


    End Sub


End Class