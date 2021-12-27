
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.FormView
Partial Public Class WebForm7
    Inherits System.Web.UI.Page
    'Inherits System.Web.UI.WebControls





    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        GridView1.Visible = True
    End Sub



    Public Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        Dim cmd As SqlCommand
        Dim stud As Object = Nothing
        Dim sql As String
        Dim exammark, coursemark, finalmark As Double


        ' finalmark =
        sql = "UPDATE StudentMarks SET  ExamMark = @ExamMark, CourseMark = @CourseMark, FinalMark = @FinalMark, Points = @Points, Decision = @Decison, ExamStatus = @ExamStatus, RerefenceName = @RerefenceName WHERE (StudentID = @studentid) AND (SubjectID = @subjectid)"

        cmd.CommandText = sql
        'cmd.Parameters .AddWithValue(@ExamMark,FormView1 .Row.FindControl ("ExamMarkTextBox")

    End Sub

   
    
   
    
    
End Class