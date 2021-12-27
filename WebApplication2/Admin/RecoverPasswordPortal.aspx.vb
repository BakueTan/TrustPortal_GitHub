Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Net.Mail
Public Class RecoverPasswordPortal
    Inherits System.Web.UI.Page

    Public sql As String
    Public cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
    Public cmd As SqlCommand
    Public drr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Button1.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
        Else
            Button1.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = "spVerifyPasswordAnswer"
        Dim loginid, loginpassword As String

        Try
            cnn.Open()

            cmd = New SqlCommand(sql, cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@email", TextBox1.Text)
                .Parameters.AddWithValue("@question", txtPasswordQ.Text)
                .Parameters.AddWithValue("@answer", txtPasswordA.Text)
                Dim param As New SqlParameter
                param.ParameterName = "@password"
                param.Size = 50
                param.Direction = ParameterDirection.Output
                .Parameters.Add(param)
                param = New SqlParameter
                param.ParameterName = "@userid"
                param.Size = 50
                param.Direction = ParameterDirection.Output
                .Parameters.Add(param)

                .ExecuteNonQuery()
                loginpassword = .Parameters("@password").Value
                loginid = .Parameters("@userid").Value

                Dim stud As New Enrol(loginid) With {
                    .Email = TextBox1.Text
                }


                If SendEmail(stud, EmailType.PasswordRequest,, PasswordMsg(loginpassword, loginid)) Then
                    Errorstatus.Text = "An Email has been sent to " & TextBox1.Text & "  with your login details." & vbNewLine & " NB: The email will not be delivered if this is a non-existent email address."
                Else
                    Errorstatus.Text = "Failed To send email , please contact Trust Academy IT department For further assistance.Thank You."
                End If


            End With







        Catch ex As Exception
            Errorstatus.Text = ex.Message
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Function PasswordMsg(pass As String, id As String) As String

        Dim msg = "You have requested your Password For the Trust Academy Students' Portal." & vbNewLine &
        " Below are the login details stored in the System for your account  : " & vbNewLine &
        " User Name : " & id & " " & vbNewLine &
        " Password : " & pass & "" & vbNewLine &
        " If you did not initiate the request , please contact Trust Academy exams department for further investigations." & vbNewLine &
        " Please note , this is an automatically generated email , you can't respond to it .For any further assistance please contact TRUST ACADEMY IT department."

        Return msg

    End Function


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

        SmtpServer.Port = osmtp.Port
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
        sql = "update applicationusers set Password = '" & password & "' , passwordreset = '1' where email = '" & email & "'"
        cmd = New SqlCommand(sql, cnn)
        cnn.Open()

        cmd.ExecuteNonQuery()
        cnn.Close()



    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim cnn As New SqlConnection(ConnectionString)
        Dim sql As String = "spRetrievePasswordQuestion"
        Try


            cnn.Open()
            Dim cmd = New SqlCommand(sql, cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@email", Trim(TextBox1.Text))
                Dim param As New SqlParameter
                param.ParameterName = "@question"
                param.Size = 100
                param.Direction = ParameterDirection.Output
                .Parameters.Add(param)
                .ExecuteNonQuery()
                txtPasswordQ.Text = .Parameters("@question").Value
                pnlSecurity.Visible = True
                txtPasswordA.Text = ""
                Errorstatus.Text = ""
            End With
        Catch ex As Exception
            Errorstatus.Text = ex.Message
            pnlSecurity.Visible = False
        Finally
            cnn.Close()

        End Try

    End Sub
End Class