Imports System
Imports System.Data.SqlClient
Module modDataAccess
    Public gcnnPos, gcnnPos2, gcnnPos3 As SqlConnection
    Public gcmdPos, gcmdPos2, gcmdPos3 As SqlCommand
    Public gblnRestore As Boolean
    Public Sub OpenConnection(Optional ByVal planB As Boolean = False, Optional ByVal planC As Boolean = False, _
                              Optional ByRef sqlTrans As SqlTransaction = Nothing, _
                              Optional ByVal DoTrans As Boolean = False, _
                              Optional ByVal TheFirst As Boolean = False)
        Static TransStart As Boolean = False
        If TheFirst Then TransStart = False
        If planB Then
            If TransStart And DoTrans Then
            Else
                Try
                    gcnnPos2 = New SqlConnection
                Catch ex As Exception
                End Try
                If gcnnPos2.State = ConnectionState.Open Then gcnnPos2.Close()
                With gcnnPos2
                    .ConnectionString = ConnectionString()
                    .Open()
                    If DoTrans And Not TransStart Then
                        TransStart = True
                        Try
                            sqlTrans = .BeginTransaction
                        Catch
                        End Try
                    End If
                End With
            End If
        ElseIf planC Then
            If TransStart And DoTrans Then
            Else
                Try
                    gcnnPos3 = New SqlConnection
                Catch ex As Exception
                End Try
                If gcnnPos3.State = ConnectionState.Open Then gcnnPos3.Close()
                With gcnnPos3
                    .ConnectionString = ConnectionString()
                    .Open()
                    If DoTrans And Not TransStart Then
                        TransStart = True
                        Try
                            sqlTrans = .BeginTransaction
                        Catch
                        End Try
                    End If
                End With
            End If

        Else
            Try
                If IsNothing(gcnnPos) Then
                    gcnnPos = New SqlConnection
                End If
            Catch ex As Exception
            End Try
            If Not DoTrans Then
                If gcnnPos.State = ConnectionState.Open Then gcnnPos.Close()
            End If
            With gcnnPos
                If .State = ConnectionState.Closed Then
                    .ConnectionString = ConnectionString()
                    .Open()
                End If
                If Not TransStart And DoTrans Then
                    Try
                        sqlTrans = .BeginTransaction
                        TransStart = True
                    Catch
                    End Try
                End If
            End With
        End If

    End Sub

    Public Sub CloseConnection(Optional ByVal planB As Boolean = False, Optional ByVal planC As Boolean = False)
        If planB Then
            If gcnnPos2.State = ConnectionState.Open Then gcnnPos2.Close()
        ElseIf planC Then
            If gcnnPos3.State = ConnectionState.Open Then gcnnPos3.Close()
        Else
            If gcnnPos.State = ConnectionState.Open Then gcnnPos.Close()
        End If

    End Sub
    Public Function ConnectionString() As String
        Dim strCnn$ = ""
        Try
            strCnn = Trim(My.Settings.soccerConnectionstring)
        Catch ex As Exception
        End Try
        Return strCnn
    End Function
    Public Function ExecuteScalar(ByVal sql As String, Optional ByVal PlanB As Boolean = False, Optional ByVal PlanC As Boolean = False) As Object
        Dim oResult As Object = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim cnn As SqlConnection = Nothing

        Try
            OpenConnection(PlanB, PlanC)
            Select Case True
                Case PlanB
                    gcmdPos2 = New SqlCommand
                    cmd = gcmdPos2
                    cnn = gcnnPos2
                Case PlanC
                    gcmdPos3 = New SqlCommand
                    cmd = gcmdPos3
                    cnn = gcnnPos3
                Case Else
                    gcmdPos = New SqlCommand
                    cmd = gcmdPos
                    cnn = gcnnPos
            End Select
            With cmd
                .Connection = cnn
                .CommandType = CommandType.Text
                .CommandText = sql
                Try
                    oResult = .ExecuteScalar()
                    era = False
                Catch ex1 As Exception
                    oResult = Nothing
                    era = True
                    eramsg = ex1.Message
                End Try
            End With
        Catch ex As Exception
            era = True
            eramsg = ex.Message
        End Try
        Return oResult
        ' era = False
    End Function
    Public Function ExecuteReader(ByVal sql As String, Optional ByVal PlanB As Boolean = False, Optional ByVal PlanC As Boolean = False,
                                  Optional ByVal sqlTrans As SqlTransaction = Nothing, Optional parameters As List(Of SqlParameter) = Nothing) As SqlDataReader
        Dim drR As SqlDataReader = Nothing
        OpenConnection(PlanB, PlanC, sqlTrans)
        Dim cmd As SqlCommand = gcmdPos
        Dim cnn As SqlConnection = gcnnPos

        Select Case True
            Case PlanB
                cmd = gcmdPos2
                cnn = gcnnPos2
            Case PlanC
                cmd = gcmdPos3
                cnn = gcnnPos3
        End Select
        Try
            cmd = New SqlCommand
            With cmd


                If Not IsNothing(parameters) Then
                    .Parameters.Clear()

                    For Each param As SqlParameter In parameters
                        .Parameters.Add(param)
                    Next
                End If

                .Connection = cnn
                .CommandType = CommandType.Text
                .CommandText = sql
                drR = .ExecuteReader
                era = False
            End With
        Catch ex As Exception
            ' MsgBox(ex.Message)
            era = True
        End Try
        Return drR
        'era = False
    End Function
    Public Sub PrepareCmdSp(ByVal sql$, Optional ByVal Param$ = Nothing)
        With gcmdPos
            .Connection = gcnnPos
            .CommandTimeout = 30
            .CommandType = CommandType.StoredProcedure
            .CommandText = sql
            If Not IsNothing(Param) Then
                Dim sqlparam As New SqlParameter
                With sqlparam
                    .DbType = DbType.String
                    .ParameterName = "@TheParameter"
                    .Value = Param
                End With
                .Parameters.Add(sqlparam)
            End If
        End With
    End Sub
    Public Sub ExecuteNonQuery(ByVal sql As String, Optional ByVal PlanB As Boolean = False,
                               Optional ByVal PlanC As Boolean = False,
                               Optional ByRef Erroneous As Boolean = False,
                               Optional ByRef sqlTrans As SqlTransaction = Nothing,
                               Optional ByVal DoTrans As Boolean = False,
                               Optional ByVal TheFirst As Boolean = False, Optional ByVal params As List(Of SqlParameter) = Nothing, Optional sqlcmd As Boolean = True)

        OpenConnection(PlanB, PlanC, sqlTrans, DoTrans, TheFirst)
        Dim cmd As SqlCommand = gcmdPos
        Dim cnn As SqlConnection = gcnnPos



        Select Case True
            Case PlanB
                If IsNothing(gcmdPos2) Then gcmdPos2 = New SqlCommand
                cmd = gcmdPos2
                cnn = gcnnPos2
            Case PlanC
                If IsNothing(gcmdPos3) Then gcmdPos3 = New SqlCommand
                cmd = gcmdPos3
                cnn = gcnnPos3
        End Select
        Try

            With cmd
                If Not IsNothing(sqlTrans) Then .Transaction = sqlTrans
                cmd.Parameters.Clear()
                If Not IsNothing(params) Then

                    For Each parameter As SqlParameter In params
                    cmd.Parameters.Add(parameter)

                Next
                End If
                .Connection = cnn
                If sqlcmd Then
                    .CommandType = CommandType.Text
                Else
                    .CommandType = CommandType.StoredProcedure
                End If
                .CommandText = sql
                .CommandTimeout = 0
                .ExecuteNonQuery()
                era = False
            End With
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Try
                'If Not IsNothing(sqlTrans) Then sqlTrans.Rollback()
            Catch
            End Try
            era = True
            eramsg = ex.Message
            ' Erroneous = True
        End Try
    End Sub


    Public Sub PrepareCmdText(ByVal sql$, Optional ByVal Limitless As Boolean = False, _
                          Optional ByVal planB As Boolean = False, Optional ByVal planC As Boolean = False)
        Try
            Select Case True
                Case planB
                    gcnnPos2 = New SqlConnection
                    gcnnPos2.ConnectionString = ConnectionString()
                    gcnnPos2.Open()
                Case planC
                    gcnnPos3 = New SqlConnection
                    gcnnPos3.ConnectionString = ConnectionString()
                    gcnnPos3.Open()
                Case Else
                    gcnnPos = New SqlConnection
                    gcnnPos.ConnectionString = ConnectionString()
                    gcnnPos.Open()
            End Select
        Catch
        End Try
        If IsNothing(gcmdPos) Then
            gcmdPos = New SqlCommand
        End If
        With gcmdPos
            If planB Then
                .Connection = gcnnPos2
            ElseIf planC Then
                .Connection = gcnnPos3
            Else
                .Connection = gcnnPos
            End If
            If Limitless Then
                .CommandTimeout = 0
            Else
                .CommandTimeout = 60
            End If
            .CommandText = sql
            .CommandType = CommandType.Text
        End With
    End Sub
End Module
