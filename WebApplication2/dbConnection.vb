
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Public Class dbConnection
    Private Shared cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
    Private Shared aspcnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AspConn").ConnectionString)
    Public Shared ReadOnly Property Connection() As SqlConnection
        Get
            Return cnn
        End Get

    End Property

    Public Shared ReadOnly Property AspConnection() As SqlConnection
        Get
            Return aspcnn
        End Get

    End Property


End Class
