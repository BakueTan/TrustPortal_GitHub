Public Class DeclineLetter
    Inherits System.Web.UI.Page

    Private Sub DeclineLetter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("ActivePage") = ""
    End Sub
End Class