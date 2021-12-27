Imports System.Data.SqlClient
Partial Public Class CreateUser
    Inherits System.Web.UI.Page

    Private Sub CreateUserWizard1_CreatedUser(sender As Object, e As EventArgs) Handles CreateUserWizard1.CreatedUser
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        ' Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        Dim cmd As SqlCommand
        Dim stud As Object = Nothing
        Dim userid As Object = Nothing
        Dim sql As String
        '  Dim drr As SqlDataReader
        If CreateUserWizard1.UserName <> "Admin" Then
            '  MsgBox("soccer")
            sql = " select studentid from studentpersonaldetails where studentid  = '" & CreateUserWizard1.UserName.ToString & "'"
            cmd = New SqlCommand(sql, cnn)
            cnn.Open()
            stud = cmd.ExecuteScalar
        Else
            stud = "Admin"
        End If


        Try


            If IsNothing(stud) Then

                CreateUserWizard1.DisableCreatedUser = True
                lbCreateUser.Text = "Invalid Student ID!!"
                CreateUserWizard1.ContinueDestinationPageUrl = "Login.aspx"


                CreateUserWizard1.DisableCreatedUser = True


                cnn.Close()
                Dim cnn2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("localServer").ConnectionString)
                sql = "select userid  from aspnet_users  where username =  '" & CreateUserWizard1.UserName.ToString & "'"
                cmd = New SqlCommand(sql, cnn2)
                cnn2.Open()
                userid = cmd.ExecuteScalar
                cnn2.Close()
                sql = "delete aspnet_membership  where userid = '" & userid.ToString & "' "
                cmd = New SqlCommand(sql, cnn2)
                cnn2.Open()
                cmd.ExecuteNonQuery()
            Else

                Response.Write("User created")
                lbCreateUser.Text = "User Successfully Created!!!!"
                CreateUserWizard1.ContinueDestinationPageUrl = "~/Login.aspx"
                cnn.Close()
            End If
        Catch ex As Exception
            'CreateUserWizard1.DisableCreatedUser = True
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CreateUserWizard1_CreatingUser(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles CreateUserWizard1.CreatingUser
        '    Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        '    Dim cmd As SqlCommand
        '    Dim stud As Object = Nothing
        '    '  Dim drr As SqlDataReader
        '    Dim sql As String = " select studentid from studentpersonaldetails where studentid  = '" & CreateUserWizard1.UserName.ToString & "'"
        '    cmd = New SqlCommand(sql, cnn)
        '    cnn.Open()

        '    Try
        '        stud = cmd.ExecuteScalar

        '        If IsNothing(stud) Then
        '            CreateUserWizard1.DisableCreatedUser = True
        '            CreateUserWizard1.CompleteSuccessText = "Invalid StudentID"
        '            CreateUserWizard1.ContinueDestinationPageUrl = "CreateUser.aspx"
        '            CreateUserWizard1.DisableCreatedUser = True
        '        Else
        '            CreateUserWizard1.ContinueDestinationPageUrl = "Login.aspx"
        '        End If
        '    Catch ex As Exception
        '        If IsNothing(stud) Then
        '            CreateUserWizard1.DisableCreatedUser = True
        '            CreateUserWizard1.CompleteSuccessText = "Invalid StudentID,Press Continue"
        '            CreateUserWizard1.ContinueDestinationPageUrl = "CreateUser.aspx"
        '            CreateUserWizard1.DisableCreatedUser = True
        '        Else
        '            CreateUserWizard1.ContinueDestinationPageUrl = "Login.aspx"
        '        End If
        '    End Try

    End Sub



End Class