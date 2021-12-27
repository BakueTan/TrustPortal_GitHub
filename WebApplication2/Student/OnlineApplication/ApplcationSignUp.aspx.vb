Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration

Public Class ApplcationSignUp
    Inherits System.Web.UI.Page
    Public sql As String
    Public cnn As SqlConnection
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Private appstud As New Enrol
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckRegStatus(TextBox1.Text)
    End Sub
    Private Sub CheckRegStatus(ByVal Email As String)
        Dim ref As Guid
        ref = Guid.NewGuid
        cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)

        Try
            With appstud
                .Email = Email
                .FullName = txtFullname.Text
            End With
            sql = "select * from NewStudRegistration where reg_email = '" & Email & "'"
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            drr = cmd.ExecuteReader()
            If drr.HasRows Then
                lbCreateUserResults.Text = "Email address already registered"
                cnn.Close()
            Else
                cnn.Close()
                If SendEmail(appstud, EmailType.ConfirmApplication, ref) Then
                    UpdateRegDetails(ref.ToString, Email, TextBox2.Text, txtFullname.Text)
                Else
                    lbCreateUserResults.Text = "Failed to Send Activation Link: " & linkmsg
                End If


            End If
        Catch ex As Exception
            lbCreateUserResults.Text = "Error creating account: " & ex.Message.ToString

        Finally
            cnn.Close()


        End Try

        ModalPopupExtender_Creater.Show()

    End Sub

    Private Sub UpdateRegDetails(ByVal ref As String, ByVal email As String, ByVal paswed As String, ByVal fullname As String)
        cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)

        param = New SqlParameter("@pass", paswed)
        sql = "INSERT INTO NewStudRegistration([Reg_email],[Reg_LinkSent],[Reg_LinkConfirmed],[Reg_Password],[Reg_TempStudentID],[Reg_ApplicationReference],reg_fullname,reg_PasswordReset)" &
            " values ('" & email & "','true','false',@pass,'','" & ref & "','" & fullname & "',0)"
        cmd = New SqlCommand(sql, cnn)

        Try
            cnn.Open()
            cmd.Parameters.Add(param)
            cmd.ExecuteNonQuery()
            lbCreateUserResults.Text = "Activation link sent to  " & email & " open link in email to activate registration."

        Catch ex As Exception

            lbCreateUserResults.Text = ex.Message
        Finally
            cnn.Close()
        End Try


    End Sub
End Class