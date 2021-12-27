Imports System.Data.SqlClient

Public Class Enrollment
    Public Property StudentID As String
    Public Property Level As Integer
    Public Property Semester As Integer
    Public Property Intake As String
    Public Property Session As String
    Public Property cls As Integer
    Public Property DateEnrolled As Date
    Public Property Program As String
    Public Property Gender As String
    Public Property Status As String
    Public Property DateCaptured As Date
    Public Property CapturedBy As String
    Public Property Reference As String
    Public Property Enroltype As String
    Public Property Current As Boolean
    Public Property Center As String
    Public Property DateLastEdited As Date
    Public Property LastEditedBy As String


    Public reader As SqlDataReader
    Dim sql As String

    Public erramsg As String = ""

    Dim cnn2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
    Dim cmd As New SqlCommand


    Public Sub New(stud As String, prog As String, lvl As Integer, sem As Integer)

        sql = "select studentid,program,year,semester,yearenrolled,session,intake,status,dateenrolled,datecaptured,capturedby,datelastedited,lasteditedby,[current],enrolref,center,enroltype,gender from enrollment  " &
         " where studentid = '" & stud & "' and [year] = '" & lvl & "' and semester = '" & sem & "' and program = '" & prog & "'"
        cmd.CommandText = sql
        cmd.Connection = cnn2
        cnn2.Open()
        reader = cmd.ExecuteReader

        While reader.Read
            StudentID = reader("StudentID")
            Level = reader("Year")
            Semester = reader("Semester")
            Intake = reader("Intake")
            Session = reader("Session")
            cls = reader("Yearenrolled")
            Try
                DateEnrolled = reader("DateEnrolled")
            Catch ex As Exception
                DateEnrolled = DateAdd(DateInterval.Month, -3, Now.Date)
            End Try

            Program = reader("Program")
            Gender = reader("Gender")
            Status = "Completed"
            Try
                DateCaptured = reader("DateCaptured")
            Catch ex As Exception
                DateCaptured = Now.Date()
            End Try

            Try
                CapturedBy = reader("CapturedBy")
            Catch ex As Exception
                CapturedBy = ""
            End Try

            Try
                Reference = reader("Reference")
            Catch ex As Exception
                Reference = ""
            End Try
            Try
                Enroltype = reader("EnrolType")
            Catch ex As Exception
                Enroltype = ""
            End Try
            Try
                DateLastEdited = reader("DateLastEdited")
            Catch ex As Exception
                DateLastEdited = Now.Date
            End Try
            Try
                LastEditedBy = reader("LastEditedBy")
            Catch ex As Exception
                LastEditedBy = StudentID
            End Try

            Current = 0
            Try
                Center = reader("Center")
            Catch ex As Exception
                Center = ""
            End Try





        End While


    End Sub


    Public Function SaveEnrol(ByVal Trans As SqlTransaction, cnn As SqlConnection) As Boolean
        sql = "Insert into enrollment (studentid,program,year,semester,yearenrolled,session,intake,status,DateEnrolled, DateCaptured, CapturedBy, DateLastEdited, LastEditedBy, [Current], Center, Enroltype,gender)" &
            "values ('" & StudentID.ToUpper & "','" & Program & "','" & Level & "','" & Semester & "','" & cls & "','" & Session & "','" & Intake & "','" & Status & "','" & changedate(DateEnrolled.Date) & "', '" & changedate(DateCaptured.Date) & "','" & CapturedBy & "','" & changedate(DateLastEdited.Date) & "','" & LastEditedBy & "','" & Current & "','" & Center & "','" & Enroltype & "','" & Gender & "')"
        cmd.CommandText = sql
        cmd.Connection = cnn
        cmd.Transaction = Trans


        Try
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Trans.Rollback()
            erramsg = ex.Message
            cnn.Close()
            Return False
        End Try


    End Function



End Class
