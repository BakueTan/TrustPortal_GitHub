Public Partial Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ViewReport.Click
        If ReportViewer1.Visible Then
            ReportViewer1.ShowRefreshButton = True
            ReportViewer1.Visible = False
        Else
            ReportViewer1.ShowRefreshButton = True
            ReportViewer1.Visible = True
        End If

        '  Response.Redirect("HighSchoolReport.5aspx")
    End Sub

    
End Class