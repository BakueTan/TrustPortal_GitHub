Imports System.Data.SqlClient
Public Class Enrol
    Private stud As String
    Private prog As String
    Private lvl As Integer
    Private sem As Integer
    Private intk As String
    Private sess As String
    Private _clas As String
    Private cnn As New SqlConnection(ConnectionString)
    Private cmd As SqlCommand
    Private sql As String

    Public Sub New(studid As String)
        Dim studdet As SqlDataReader
        cnn = New SqlConnection(ConnectionString)
        Try
            cnn.Open()
            sql = "spGetStudentDetails"
            cmd = New SqlCommand(sql, cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@stud", studid)
            studdet = cmd.ExecuteReader
            While studdet.Read
                FullName = studdet("StudentFullName")
            End While
        Catch ex As Exception
        Finally
            cnn.Close()
        End Try




    End Sub
    Public Sub New()


    End Sub


    Public Property Student() As String
        Get
            Student = stud
        End Get
        Set(value As String)
            stud = value
        End Set

    End Property


    Public Property Program As String
        Get
            Program = prog
        End Get
        Set(value As String)
            prog = value
        End Set

    End Property

    Public Property Level As String
        Get
            Level = lvl
        End Get
        Set(value As String)
            lvl = value
        End Set

    End Property

    Public Property Semester As String
        Get
            Semester = sem
        End Get
        Set(value As String)
            sem = value
        End Set

    End Property

    Public Property Session As String
        Get
            Session = sess
        End Get
        Set(value As String)
            sess = value
        End Set

    End Property

    Public Property Intake As String
        Get
            Intake = intk
        End Get
        Set(value As String)
            intk = value
        End Set

    End Property

    Public Property Clas As String
        Get
            Clas = _clas
        End Get
        Set(value As String)
            _clas = value
        End Set

    End Property

    Public Property Email As String

    Public Property FullName As String
End Class
