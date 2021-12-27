Public Class Application
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Reference") = "" Then

            HyperLink1.Visible = False
            HyperLink2.Visible = False
            hlChangePass.Visible = False
            Welcome.Visible = False
            Welcome.Text = ""
            Button1.Visible = True
            Button1.Text = "Login"
            Button2.Visible = True

        Else


         
            Button1.Visible = True
            Button1.Text = "LogOut"
            HyperLink1.Visible = True
            HyperLink2.Visible = True
            hlChangePass.Visible = True
            Welcome.Visible = True
            Welcome.Text = "Welcome " & Session("userName")
            Button2.Visible = False
        End If
        Label2.Text = strcopyright
        SubGetActivepage()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()
        Button1.Text = "Login"
        Response.Redirect("~/Student/OnlineApplication/ApplicationLogin.aspx")
        Button1.Visible = False
    End Sub

    Private Sub SubGetActivepage()
        Select Case Session("ActivePage")
            Case "ApplicationForm"
                HyperLink1.CssClass = "MenuLinkHighlighted"
                HyperLink2.CssClass = "MenuLink"
            Case "MyApplications"
                HyperLink2.CssClass = "MenuLinkHighlighted"
                HyperLink1.CssClass = "MenuLink"

        End Select
    End Sub

End Class