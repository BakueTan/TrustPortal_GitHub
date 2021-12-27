Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Net.Mail
Public Class Forgot_Password
    Inherits System.Web.UI.Page

    Public sql As String
    Public cnn As SqlConnection
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = "select * from NewStudRegistration where reg_email = '" & Trim(TextBox1.Text) & "'"

        cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        cmd = New SqlCommand(sql, cnn)

        Try
                 cnn.Open()
            drr = cmd.ExecuteReader()

            If drr.HasRows Then

                GenerateResetPassword(Trim(TextBox1.Text))
                lbCreateUserResults.Text = "Reset Instructions Sent to " & TextBox1.Text
            Else

                lbCreateUserResults.Text = "No Account is associated with this Email Address"
            End If


        Catch ex As Exception
            lbCreateUserResults.Text = ex.Message
        Finally
            cnn.Close()

        End Try

        ModalPopupExtender_Creater.Show()
    End Sub

    Private Sub GenerateResetPassword(ByVal email As String)

        Dim osmtp As New CSmtp

        Dim password As String
        password = Membership.GeneratePassword(6, 1)
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Dim link As String = "Use this Password to Login : " & password
        'Net.NetworkCredential("tangaiwasb@gmail.com", "bothwell")
        SmtpServer.Credentials = New Net.NetworkCredential(osmtp.MailFrom, osmtp.Password)
        ' Net.NetworkCredential("tangaiwasb@gmail.com", "bothwell")

        SmtpServer.Port = osmtp.port
        SmtpServer.EnableSsl = True
        '  SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.Host = osmtp.Server
        mail = New MailMessage()
        mail.From = New MailAddress(osmtp.MailFrom)
        mail.To.Add(email)
        mail.Subject = "Password Reset"
        mail.Body = link
        SmtpServer.Send(mail)
        UpdateResetDetails(email, password)

    End Sub
    Private Sub UpdateResetDetails(ByVal email As String, password As String)
        cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)

        sql = "update NewStudRegistration set Reg_Password = '" & password & "' , Reg_PasswordReset = '1' where reg_email = '" & email & "'"

        Try
            cnn.Open()
            cmd = New SqlCommand(sql, cnn)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            lbCreateUserResults.Text = "Unexpected error occured!!"
        Finally
            cnn.Close()

        End Try




    End Sub

End Class