Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Partial Public Class _Default
    Inherits System.Web.UI.Page





    Public Sub page_load() Handles Me.Load
        Session("ActivePage") = "Home"
        '   Private Sub Login1_Load(sender As Object, e As System.EventArgs) Handles Login1.Load

   
        Try
            lbStudEmailError.Text = ""
        Catch ex As Exception

        End Try

        If Not Page.IsPostBack Then
            Try
                lbStudProgram.Text = "Latest Enrollment :   " & Session("Program") & "-" & Session("Level") & " : " & Session("Semester")



                recoveremail.Text = Session("Email")
            Catch ex As Exception

            End Try





            '  LOADIMAGE()
        End If

    End Sub

    Private Sub LOADIMAGE()

        Dim img As Byte()
        Dim cmd As SqlCommand
        Using con As New SqlConnection(My.Settings.soccerConnectionString)

            con.Open()
            Dim SQL As String = "SELECT IMAGE FROM STUDENTPERSONALDETAILS WHERE STUDENTID = '" & Session("userName") & "'"
            cmd = New SqlCommand(SQL, con)
            'cmd.Connection = cnn
            Try
                img = cmd.ExecuteScalar
                imgStud.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(img)
            Catch ex As Exception
                Try
                    imgStud.ImageUrl = "~/Images/noimage.jpg"
                Catch

                End Try

            End Try





        End Using



    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim email As String
        Dim sql1 As String
        email = recoveremail.Text
        Dim cnn As SqlConnection = dbConnection.Connection
        Dim cmd As SqlCommand
        sql1 = "update studentlogin set email = '" & email & "' where userid = '" & Session("userName") & "'"
        cmd = New SqlCommand(sql1, cnn)
        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()
            lbStudEmailError.Text = "Recovery Email Updated"
       '     Response.Redirect("LoggedIn.aspx")
        Catch ex As Exception
            lbStudEmailError.Text = ex.Message
        Finally

            cnn.Close()
        End Try





    End Sub


End Class