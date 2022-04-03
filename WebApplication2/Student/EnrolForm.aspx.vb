Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms

Public Class EnrolForm
    Inherits System.Web.UI.Page

    Private Sub EnrolForm_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        'Dim sql As String
        'Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        'Dim cmd As New SqlCommand
        'Dim drr As SqlDataReader

        'sql = "select top 1 year,program,semester from enrollment where  studentid = '" & Session("userName") & "' and program = 'BMIS' order by  [year] desc, semester desc"
        'cmd.CommandText = sql
        'cnn.Open()
        'cmd.Connection = cnn
        'drr = cmd.ExecuteReader()
        'If drr.HasRows Then

        '    While drr.Read
        '        Session("program") = drr(1)
        '        Session("level") = drr(0)
        '        Session("semester") = drr(2)
        '    End While
        'Else
        '    Session("program") = "init"
        '    Session("level") = "1"
        '    Session("semester") = "1"
        'End If

        'cnn.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Dim ex As RenderingExtension() = ReportViewer1.LocalReport.ListRenderingExtensions()


        Dim exportOption As String = "EXCELOPENXML"

        Dim expopt2 As String = "WORDOPENXML"





        Dim extension As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Contains(exportOption))
        If extension IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension, False)
        End If

        extension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Contains(expopt2))
        If extension IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension, False)
        End If
    End Sub
End Class