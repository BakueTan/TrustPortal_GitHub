Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Net.Mail

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Public sql As String
    Private cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Private Loggeduser As clsUser







    'Private Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn

    '    Dim stud As Object = Nothing
    '    Dim usertyp As DropDownList
    '    Dim type As String
    '    '  Dim drr As SqlDataReader
    '    ' cnn.Close()
    '    usertyp = Login1.FindControl("UserType")

    '    type = usertyp.SelectedValue



    '    If type = "Student" Then


    '        Dim sql As String = " select studentid from studentpersonaldetails where studentid  = '" & Login1.UserName.ToString & "'"
    '        cmd = New SqlCommand(sql, cnn)
    '        cnn.Open()
    '        Try
    '            Session("userName") = Login1.UserName.ToString()
    '            Dim loggedUser As clsUser = New clsUser(Session("userName"))
    '            Session("firstName") = loggedUser.firstName
    '            Session("lasName") = loggedUser.lstName
    '            Session("Program") = loggedUser.program
    '            Session("Section") = loggedUser.section
    '            Session("Group") = "Students"
    '            Session("Image") = loggedUser.img
    '            Session("Level") = loggedUser.lvl
    '            Session("Semester") = loggedUser.sem
    '            Response.Redirect("~/Student/LoggedIn.aspx")

    '        Catch ex As Exception

    '        End Try
    '        Try
    '            stud = cmd.ExecuteScalar

    '            If Not IsNothing(stud) Then

    '            Else
    '                FormsAuthentication.SignOut()
    '                Session.Clear()
    '                Session.Abandon()
    '                Response.Redirect("~/Login.aspx")
    '                Login1.FailureText = "Invalid UserName"

    '            End If
    '        Catch ex As Exception

    '            Login1.FailureText = "Wrong Section"
    '            '  Login1.FailureAction =
    '            'MsgBox(ex.Message)
    '        End Try

    '        cnn.Close()
    '    ElseIf type = "Lecturer" Then
    '        Dim sql As String = " select staffid from staffpersonaldetails where staffid   = '" & Login1.UserName.ToString & "'"
    '        cmd = New SqlCommand(sql, cnn)
    '        cnn.Open()

    '        stud = cmd.ExecuteScalar

    '        If Not IsNothing(stud) Then
    '            Try
    '                Session("userName") = Login1.UserName.ToString()
    '                Dim loggedUser As clsLect = New clsLect(Session("userName"))
    '                Session("firstName") = loggedUser.firstName
    '                ' Session("lasName") = loggedUser.lstName
    '                Session("Group") = "Lects"
    '            Catch
    '            End Try


    '        Else
    '            FormsAuthentication.SignOut()
    '            Session.Clear()
    '            Session.Abandon()
    '            Response.Redirect("~/Login.aspx")


    '        End If

    '    ElseIf type = "Admin" Then
    '        Try
    '            Session("userName") = Loggeduser.userName


    '            Session("Group") = Loggeduser.Group
    '            ' Response.Redirect("LoggedIn.aspx")
    '            Response.Redirect("~/Admin/frmUserAdmin.aspx")

    '        Catch ex As Exception

    '        End Try

    '        '  Response.Redirect("StudentRe
    '    End If

    'End Sub



    Public Function EncodePassword(ByVal pass As String, ByVal salt As String) As String
        Dim bytes() As Byte = Encoding.Unicode.GetBytes(pass)
        Dim src() As Byte = Encoding.Unicode.GetBytes(salt)
        Dim dst() As Byte = Encoding.Unicode.GetBytes(src.Length + bytes.Length)
        '  Buffer.(src, 0, dst, 0, src.Length)
        '  Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length)
        Dim algorithm As HashAlgorithm = HashAlgorithm.Create("SHA1")
        Dim inArray() As Byte = algorithm.ComputeHash(dst)
        Return Convert.ToBase64String(inArray)
    End Function

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        Dim type As String = UserType.SelectedValue

        If Page.IsValid Then

            If type = "Staff" Then
                Loggeduser = New clsUser(UserName.Text, Password.Text, "Staff")

                If Loggeduser.UserIsValid Then



                    Session("userName") = Loggeduser.userName
                    Session("userType") = type
                    Session("Stafftype") = Loggeduser.StaffType
                    Session("FullName") = Loggeduser.FullName
                    Session("Group") = "Staff"
                    Session("GroupName") = Loggeduser.GroupName

                    Response.Redirect("~/Admin/frmUserAdmin.aspx")

                Else

                    FailureText.Text = Loggeduser.LoginErroMsg



                End If
            ElseIf type = "Student" Then

                Loggeduser = New clsUser(UserName.Text, Password.Text, "Student")

                If Loggeduser.UserIsValid Then



                    Session("userName") = Loggeduser.userName
                    Session("userType") = type
                    Session("Stafftype") = Loggeduser.StaffType
                    Session("FullName") = Loggeduser.FullName




                    Session("Program") = loggedUser.program
                    Session("Section") = loggedUser.section
                    Session("Group") = "Students"
                    Session("Image") = Loggeduser.Img
                    Session("Level") = loggedUser.lvl
                    Session("Semester") = loggedUser.Sem
                    Session("Email") = Loggeduser.Email
                    ' Session("UserEmail") = Loggeduser.UserEmail


                    Response.Redirect("~/Student/LoggedIn.aspx")

                Else

                    FailureText.Text = Loggeduser.LoginErroMsg



                End If


            Else
                FailureText.Text = "Account not yet activated"
            End If

        Else

        End If

    End Sub
End Class