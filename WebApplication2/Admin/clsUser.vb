
Imports System.Data.SqlClient
Imports System
Public Class clsUser

    Private mstrUsername, mstrPassWord, mstrFullName, mstrGroup, mstrgrpname As String

    Public Property StaffId As String

    Public PublishExam As String

    Public Property StudentName As String
    Public Property Program As String
    Public Property Sem As String
    Public Property Lvl As String
    Public Property Section As String

    Public Property Img As Byte()


    Public Property StaffType As String
    Public Property LoginErroMsg As String

    Public Property GroupName As String

    Public Property userName() As String
    Public Property UserEmail As String

    Public Property Email As String



        Get
            Return mstrUsername
        End Get

        Set(ByVal value As String)
            mstrUsername = value
        End Set

    End Property
    Public Property UserType As String
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

            'sql = "insert into LoginHistory ([user],terminal,datelogged,timelogin,loginstate)" &
            '" values('" & mstrUsername & "','" & SystemInformation.ComputerName & "','" & changedate(Now.Date) & "','" & Mid(Now.TimeOfDay.ToString, 1, 8) & "','true')"

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

            Dim param As SqlParameter
            Dim cnn As New SqlConnection(ConnectionString)

            Try

                cnn.Open()
                Dim cmd As New SqlCommand
                cmd.CommandText = "spAunticateLogin"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cnn
                param = New SqlParameter("@acc", userName)
                cmd.Parameters.Add(param)
                param = New SqlParameter("@password", passWord)
                cmd.Parameters.Add(param)
                param = New SqlParameter("@type", UserType)
                cmd.Parameters.Add(param)
                param = New SqlParameter()
                param.ParameterName = "@usertype"
                param.Size = 50
                param.Direction = ParameterDirection.Output
                param.DbType = DbType.String
                cmd.Parameters.Add(param)

                sql = "spAunticateLogin"

                cmd.ExecuteNonQuery()

                StaffType = cmd.Parameters("@usertype").Value.ToString
                '      UserEmail = cmd.Parameters("@usermail").Value.ToString


                Valid = True

            Catch ex As Exception
                Valid = False
                LoginErroMsg = ex.Message
            Finally
                cnn.Close()
            End Try






            Return Valid
        End Get

    End Property



    Public Sub New(ByVal userNme As String, ByVal passWd As String, ByVal ustype As String)
        userName = userNme
        passWord = passWd
        UserType = ustype
        Dim cnn As New SqlConnection(ConnectionString)
        Dim stud As SqlDataReader

        Try
            cnn.Open()
            sql = "spGetLoggedInDetails"
            Dim cmd As New SqlCommand(sql, cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@stud", userName)
            cmd.Parameters.AddWithValue("@type", ustype)
            stud = cmd.ExecuteReader()
            If ustype = "Staff" Then
                If stud.HasRows Then
                    While stud.Read

                        mstrFullName = stud("StaffFullName")
                        GroupName = stud("GroupName")

                    End While
                End If
            ElseIf ustype = "Student" Then

                If stud.HasRows Then
                    While stud.Read
                        Program = stud("Program")
                        Lvl = stud("Year")
                        mstrFullName = stud("StudentFullName")
                        Sem = stud("Semester")
                        Section = stud("Section")
                        Email = stud("Email")



                    End While
                End If
            End If

        Catch ex As Exception
        Finally
            cnn.Close()

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


Public Class clsParent

End Class