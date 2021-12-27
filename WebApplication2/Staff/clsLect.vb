


Imports System.Data.SqlClient
Public Class clsLect
    Private mstrName, mstrSurname As String

    Public ReadOnly Property firstName()
        Get
            Return mstrName
        End Get

    End Property

    Public ReadOnly Property lstName()
        Get
            Return mstrSurname
        End Get

    End Property

    Public Sub New(ByVal userid As String)

        Dim sql As String
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
        Dim drr As SqlDataReader = Nothing
        sql = "select name,surname from staffpersonaldetails where staffid = '" & userid & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        conn.Open()

        drr = cmd.ExecuteReader

        While (drr.Read)
            mstrName = drr(0).ToString
            mstrSurname = drr(1).ToString
        End While


    End Sub

End Class



