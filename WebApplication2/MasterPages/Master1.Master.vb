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
            '   lnkChangePassword2.Visible = False
            HlHome.Visible = False
            hlStudExams.Visible = False
            hlStudExams2.Visible = False
            lnkChangePassword.Visible = False
            lnkLoginStats.Text = "Login"

            '     lnkLoginStats2.Text = "Login"

            hlPayments.Visible = False
            lnkReturningStudent.Visible = False

            hlPayments2.Visible = False
            lnkReturningStudent2.Visible = False
            Hlhome2.Visible = False
            imgDdMenu.Visible = False

        Else

            If Session("Group") = "Students" Then
                imgDdMenu.Visible = True
                lnkLoggeduser.Text = Session("FullName")
                HlHome.Visible = True
                Hlhome2.Visible = True
                hlStudExams.Visible = True
                hlStudExams2.Visible = True



                lnkChangePassword.Visible = True
                lnkLoginStats.Text = "LogOut"
                hlPayments.Visible = True
                hlPayments2.Visible = True

                lnkReturningStudent.Visible = True
                lnkReturningStudent2.Visible = True

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
            lbCopyRight.Text = strcopyright
            GetActivepage()

        Catch ex As Exception

        End Try


    End Sub



    Private Sub GetActivepage()
        Select Case Session("ActivePage")
            Case "ExamResults"
                hlStudExams.CssClass = "MenuLinkHighlighted"
                hlStudExams2.CssClass = "MenuLinkHighlighted"
                HlHome.CssClass = "MenuLink"
                Hlhome2.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                hlPayments2.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"
                lnkReturningStudent2.CssClass = "MenuLink"

            Case "FeesPayments"
                hlPayments.CssClass = "MenuLinkHighlighted"
                hlPayments2.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                hlStudExams2.CssClass = "MenuLink"
                HlHome.CssClass = "MenuLink"
                Hlhome2.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"
                lnkReturningStudent2.CssClass = "MenuLink"
            Case "Home"
                HlHome.CssClass = "MenuLinkHighlighted"
                Hlhome2.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                hlStudExams2.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                hlPayments2.CssClass = "MenuLink"
                lnkReturningStudent.CssClass = "MenuLink"
                lnkReturningStudent2.CssClass = "MenuLink"
            Case "SubjectRegistration"
                lnkReturningStudent.CssClass = "MenuLinkHighlighted"
                lnkReturningStudent2.CssClass = "MenuLinkHighlighted"
                hlStudExams.CssClass = "MenuLink"
                hlStudExams2.CssClass = "MenuLink"
                hlPayments.CssClass = "MenuLink"
                hlPayments2.CssClass = "MenuLink"
                HlHome.CssClass = "MenuLink"
                Hlhome2.CssClass = "MenuLink"
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