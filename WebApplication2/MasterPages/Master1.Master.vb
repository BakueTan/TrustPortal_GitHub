Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Partial Public Class Master1
    Inherits System.Web.UI.MasterPage








    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        '  If Session("Group") = "Students" Then
        If IsNothing(Session("userName")) Or Session("userName") = "" Then
            lnkLoggeduser.Text = "Login"
            'Login1.Enabled = True
            lnkChangePassword.Visible = False
            HlHome.Visible = False
            hlStudExams.Visible = False

            lnkLoginStats.Text = "Login"

            hlPayments.Visible = False
            lnkReturningStudent.Visible = False

        Else

            If Session("Group") = "Students" Then

                lnkLoggeduser.Text = Session("FullName")
                HlHome.Visible = True
                hlStudExams.Visible = True



                lnkChangePassword.Visible = True
                lnkLoginStats.Text = "LogOut"
                hlPayments.Visible = True

                lnkReturningStudent.Visible = True

            ElseIf Session("Group") = "Lects" Then

                HlHome.Visible = True
                hlStudExams.Visible = False




                hlPayments.Visible = False



            ElseIf Session("Group") = "Prnts" Then

                HlHome.Visible = True
                hlStudExams.Visible = True

                '  HyperLink3.Visible = False

                '  lbLoggedUser.Visible = True
                '  LoginName1.Enabled = True

                hlPayments.Visible = True
                lnkReturningStudent.Visible = False
                '  hlStudPers.Visible = False
                'Login1.CreateUserText = ""
                ' Login1.PasswordRecoveryText = ""




            ElseIf Session("Group") = "Staff" Then

                lnkReturningStudent.Visible = False

                HlHome.Visible = False
                hlStudExams.Visible = False
                '  HyperLink3.Visible = True

                lnkLoginStats.Text = "LogOut"
                '  lbLoggedUser.Visible = True
                ' LoginName1.Visible = True
                lnkChangePassword.Visible = False
                hlPayments.Visible = False
                ' hlStudPers.Visible = True
                'Login1.CreateUserText = ""
                'Login1.PasswordRecoveryText = ""
                'Login1.Enabled = False
                'Login2.Enabled = False
                'Login3.Enabled = False
                lnkLoggeduser.Text = Session("FullName")
                ' LoginStatus.Visible = True

            ElseIf Session("Group") = "Application" Then



                HlHome.Visible = False
                hlStudExams.Visible = False




                '  lbLoggedUser.Visible = True
                ' LoginName1.Visible = True

                hlPayments.Visible = False
                ' hlStudPers.Visible = True
                'Login1.CreateUserText = ""
                'Login1.PasswordRecoveryText = ""
                'Login1.Enabled = False
                'Login2.Enabled = False
                'Login3.Enabled = False





            End If


            End If

        ' Else

        ' End If
        Try
            Label2.Text = strcopyright
            GetActivepage()

        Catch ex As Exception

        End Try


    End Sub



    Private Sub GetActivepage()
        Select Case Session("ActivePage")
            Case "ExamResults"
                hlStudExams.CssClass = "MenuLinkHighlighted"
                HlHome.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"
            Case "FeesPayments"
                hlPayments.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                HlHome.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"
            Case "Home"
                HlHome.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"

            Case "SubjectRegistration"
                lnkReturningStudent.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                HlHome.CssClass = "MenuLink"
        End Select
    End Sub

    Protected Sub lnkLoginStats_Click(sender As Object, e As EventArgs) Handles lnkLoginStats.Click
        If lnkLoginStats.Text = "LogOut" Then
            FormsAuthentication.SignOut()
            Session.Clear()
            Session.Abandon()
            Response.Redirect("~/Login.aspx")
            ' LoginStatus.LoginText = "Login"
            lnkLoginStats.Text = "Login"
        Else
            Response.Redirect("~/Login.aspx")
        End If
    End Sub
End Class