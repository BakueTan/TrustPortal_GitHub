Public Partial Class Unpaid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtBalance.Text = "Results could not be displayed you have an account balance of $" & Session("Amount")
    End Sub

End Class