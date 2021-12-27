
Imports System.Data.SqlClient


Public Class CSmtp
    Private drr As SqlDataReader
    Public Property Server As String
    Public Property MailFrom As String
    Public Property Port As Integer
    Public Property Password As String

    Public Sub New()
        Dim sql As String = "select * from smtp "
        drr = ExecuteReader(sql,, True)

        While drr.Read
            Server = drr("Server")
            MailFrom = drr("MailFrom")
            Port = drr("Port")
            Password = drr("Password")




        End While
    End Sub

End Class

Public Class cSchoolInfo
    Private drr As SqlDataReader
    Public Property SchoolName As String
    Public Property MerchantCode As String
    Public Property ApplicationFees As Double
    Public Property BaseCurrenncy As String

    Public Sub New()
        Dim sql As String = "select * from schoolinfo "
        drr = ExecuteReader(sql,, True)

        While drr.Read
            SchoolName = drr("name")
            Try
                MerchantCode = drr("MerchantCode")
            Catch ex As Exception
                MerchantCode = ""
            End Try
            Try
                ApplicationFees = drr("ApplicationFees")
            Catch ex As Exception
                ApplicationFees = 0
            End Try
            Try
                BaseCurrenncy = drr("BaseCurrency")
            Catch ex As Exception
                BaseCurrenncy = ""
            End Try





        End While
    End Sub

End Class
