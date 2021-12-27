
Imports System.Data.SqlClient
Public Class clsUser

    Private mstrUsername, mstrPassWord, mstrFullName, mstrGroup, mstrgrpname As String

    Public Property userName() As String

        Get
            Return mstrUsername
        End Get

        Set(ByVal value As String)
            mstrUsername = value
        End Set

    End Property
    Public Function updateLoginHistory() As Boolean
        Dim reader As SqlDataReader
        Dim sql As String = " select distinct terminal from loginhistory where [user] = '" & mstrUsername & "' and loginstate = 'true' "

        reader = ExecuteReader(sql, True)

        If reader.HasRows And Group <> "0" Then
            While reader.Read

                MsgBox("Active Login state found for " & mstrUsername & " on termnial " & reader(0) & "")
                Return False
                '   End If


            End While
        Else

            sql = "insert into LoginHistory ([user],terminal,datelogged,timelogin,loginstate)" &
            " values('" & mstrUsername & "','" & SystemInformation.ComputerName & "','" & changedate(Now.Date) & "','" & Mid(Now.TimeOfDay.ToString, 1, 8) & "','true')"

            ExecuteNonQuery(sql,, True)
            If era Then
                ' MsgBox("User already logged in on this terminal")
                '   Return False
            End If
        End If


        Return True
    End Function
    Public ReadOnly Property UserIsValid() As Boolean

        Get
            Dim sql As String = ""
            Dim Valid As Boolean = False
            Dim oResult As Object = Nothing
            Try
                sql = "SELECT COUNT(Usr_User) FROM dbo.Users WHERE Usr_User ='" & mstrUsername &
                "' AND Usr_Password ='" & mstrPassWord & "'"
                oResult = ExecuteScalar(sql)
                If Not IsNothing(oResult) Then
                    If CInt(oResult) > 0 Then
                        '   If updateLoginHistory() Then
                        Valid = True
                        '   End If


                    End If
                End If
            Catch ex As Exception
            End Try
            'Test Harness
            'Valid = True

            Return Valid
        End Get

    End Property



    Public Sub New(ByVal userNme As String, ByVal passWd As String)
        userName = userNme
        passWord = passWd
        Try
            mstrFullName = ""
            mstrFullName = GetTableValue("Users", "Usr_User", "Usr_FullName", userName, False).ToString
            If mstrFullName = "No Data" Then
                mstrFullName = ""
            End If
        Catch ex As Exception

        End Try

        Try
            mstrGroup = ""
            mstrgrpname = ""
            mstrGroup = GetTableValue("Users", "Usr_User", "Usr_UserGroup", userName, False).ToString
            '  mstrgrpname = GetTableValue("Users", "Usr_User", "Usr_UserGroup", userName, False).ToString
            If mstrGroup = "No Data" Then
                mstrGroup = ""
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Property passWord() As String
        Get
            Return mstrPassWord
        End Get
        Set(ByVal value As String)
            mstrPassWord = value

        End Set
    End Property
    Public ReadOnly Property FullName() As String
        Get
            Return mstrFullName
        End Get
    End Property
    Public ReadOnly Property Group() As String
        Get
            Return mstrGroup
        End Get
    End Property
End Class
