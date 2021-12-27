Public Class Admin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("userName")) Or Session("userName") = "" Then
            lnkBillingCutOff.Visible = False
            lnkResetPassword.Visible = False
            lnkLoggeduser.Text = "Login"
            lnkLoginStats.Text = "Login"
            lnkApproveApplications.Visible = False
            lnkChangePassword.Visible = False
        Else
            lnkLoggeduser.Text = Session("userName")
            lnkLoginStats.Text = "LogOut"
            lnkChangePassword.Visible = False
        End If
        Label2.Text = strcopyright
        GetActivepage()
    End Sub




    Private Sub GetActivepage()
        Select Case Session("ActivePage")
            Case "BillingCutOff"
                lnkBillingCutOff.CssClass = "MenuLinkHighlighted"
                lnkResetPassword.CssClass = "MenuLink"
                lnkApproveApplications.CssClass = "MenuLink"

            Case "ResetPassword"
                lnkResetPassword.CssClass = "MenuLinkHighlighted"
                lnkBillingCutOff.CssClass = "MenuLink"
                lnkApproveApplications.CssClass = "MenuLink"
            Case "ViewApplications"
                lnkApproveApplications.CssClass = "MenuLinkHighlighted"
                lnkResetPassword.CssClass = "MenuLink"
                lnkBillingCutOff.CssClass = "MenuLink"

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