
Imports System.Data.SqlClient


Public Class Subject
    Public Property Subject As String
    Public Property SubjectID As String


End Class
Public Class RegisterSubjects
    Inherits System.Web.UI.Page

    Private Property ActiveEnrollment As Boolean
    Private NextSemster As Integer = 0
    Private NextLevel As Integer = 0
    Private CurrLevel As Integer = 0
    Private CurrSemester As Integer = 0
    Private Program As String
    Private Proceed As Boolean
    Private Student As String
    Private Function getSubdesc(ByVal subjects As String) As String
        Dim sql As String = "select 'True' as Slct ,'Register' as Register, subjectid ,subject from subjects where subjectid  in ('" & subjects & "')"
        Return sql
    End Function


    Private Function SearchRegistration(ByVal Subjects As String, Level As Integer, semester As Integer) As Boolean
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim drr As SqlDataReader
        Dim regfound As Boolean = False



        Dim sql As String = " select r.subjectid from studentsubjects r  " &
             " where  r.studentid = '" & Session("userName") & "' and r.year = '" & Level & "' and r.semester = '" & semester & "' and program = '" & Session("Program") & "' " &
                 " except " &
                 "select distinct subjectid from subjects where subjectid   in ('" & Subjects & "') "
        '       " union " &
        '" select r.subjectid from studentsubjects r  " &
        '            " where  r.studentid = '" & Session("userName") & "' and r.year = '" & Level & "' and r.semester = '" & semester & "' and program = '" & Session("Program") & "')"


        cmd.CommandText = sql
        cnn.Open()
        cmd.Connection = cnn
        Try
            drr = cmd.ExecuteReader()
            If drr.HasRows Then
                regfound = True
            End If

        Catch ex As Exception
        Finally
            cnn.Close()


        End Try



        Return regfound
    End Function




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("ActivePage") = "SubjectRegistration"

        Dim sql As String
        Dim cnn As SqlConnection = New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand
        Dim drr As SqlDataReader
        Dim subjectdescr As String = ""
        If Not Page.IsPostBack Then
            Try


                Program = Session("Program")
                Student = Session("UserName")

                sql = "SpReturningStudents"
                cnn.Open()
                cmd = New SqlCommand(sql, cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@stud", Student)
                cmd.Parameters.AddWithValue("@prog", Program)
                drr = cmd.ExecuteReader

                If drr.HasRows Then

                    While drr.Read
                        '  Session("program") = drr(1)
                        '  Session("level") = drr(0)

                        lbSubjects.Visible = True
                        txtProgram.Text = Program

                        CurrLevel = drr("CurrentLevel")
                        CurrSemester = drr("CurrentSemester")
                        NextLevel = drr("NxtLvl")
                        NextSemster = drr("NxtSem")

                        Session("Level") = NextLevel
                        Session("Semester") = NextSemster


                        txtLvl.Text = CurrLevel
                        txtSem.Text = CurrSemester


                        If drr("HasExams") = "True" Then
                            btnRetrieveLevelSubs.Visible = False
                            txtNxtLvl.Enabled = False
                            txtNxtSem.Enabled = False
                            txtProgram.Enabled = False

                            ActiveEnrollment = False
                            pnlnextEnrollment.Visible = True
                            pnlRegister.Visible = True

                            Proceed = drr("Proceed")


                            If drr("Repeat") = "True" Then ' Repeating 
                                Dim subjects As String
                                If drr("RepeatSubs").ToString.Contains("Supplement") Then
                                    subjects = Mid(Trim(drr("RepeatSubs")), 11)
                                Else
                                    subjects = Mid(Trim(drr("RepeatSubs")), 7)
                                End If



                                '  subs = subjects.Split(",")
                                subjects = Trim(subjects.Replace(",", "','").Replace("& Review", ""))

                                If Not SearchRegistration(Trim(subjects), drr("NxtLvl"), drr("NxtSem")) Then ' 
                                    Label1.BackColor = Drawing.Color.Yellow
                                    Label1.Text = "Current enrollment still Active , You can  Print Enrollment Form to view Subjects Registered, or Update the Subjects"
                                    txtNxtLvl.Text = drr("NxtLvl")
                                    txtNxtSem.Text = drr("NxtSem")
                                    loadcurrentregistration()

                                    lbSubjects.Visible = True
                                    pnlRegister.Visible = True
                                    pnlnextEnrollment.Visible = True
                                    hlViewEnrollmentForm.Visible = True
                                    chkenableupdate.Checked = True

                                    Exit Sub


                                End If


                                If Not Proceed Then

                                    NextLevel = drr("NxtLvl")
                                    NextSemster = drr("NxtSem")
                                    Label1.BackColor = Drawing.Color.Red
                                    getlevelsubs(getSubdesc(Trim(subjects))) ' Get next level subjects add them to existing proceed carrying subs
                                    txtNxtLvl.Text = NextLevel
                                    txtNxtSem.Text = NextSemster
                                    btnRegister.Enabled = "true"
                                    Label1.Text = "Repeating failed subjects ( Not Proceeding)"
                                    chkenableupdate.Checked = False
                                Else
                                    Label1.BackColor = Drawing.Color.Green
                                    getlevelsubs(getSubdesc(Trim(subjects))) ' Get next level subjects add them to existing proceed carrying subs
                                    txtNxtLvl.Text = NextLevel
                                    txtNxtSem.Text = NextSemster
                                    btnRegister.Enabled = True
                                    Label1.Text = "Proceeding To Next level"
                                    chkenableupdate.Checked = False
                                End If







                            Else 'Not Repeating


                                If Proceed Then
                                    getlevelsubs("")
                                    Label1.BackColor = Drawing.Color.Green
                                    If (NextLevel = CurrLevel) And (NextSemster = CurrSemester) Then
                                        btnRegister.Enabled = False
                                        Label1.Text = "Graduating"
                                        txtNxtLvl.Text = NextLevel
                                        txtNxtSem.Text = NextSemster
                                        '          chkenableupdate.Checked = False
                                    Else
                                        btnRegister.Enabled = True
                                        Label1.Text = "Proceeding to Next Level"
                                        txtNxtLvl.Text = NextLevel
                                        txtNxtSem.Text = NextSemster
                                        chkenableupdate.Checked = False

                                    End If

                                    'Else
                                    '    getlevelsubs(drr(1), drr(0), "", proceed)
                                    '        Label1.BackColor = Drawing.Color.Red
                                    '        btnRegister.Enabled = True
                                    '        Label1.Text = "Repeating failed subjects ( Not Proceeding)"
                                    '        txtNxtLvl.Text = NextLevel
                                    '        txtNxtSem.Text = NextSemster
                                End If


                            End If
                        Else ' No exams found i.e current enrollment is active 
                            Label1.BackColor = Drawing.Color.Yellow
                            ActiveEnrollment = True
                            Label1.Text = "Current enrollment still Active ,To Register for Next Enrollment , Select Next Level and Semester and click Retrieve subjects to choose subjects available for the Respective Next Enrollment Details."
                            txtNxtLvl.Text = CurrLevel
                            txtNxtSem.Text = CurrSemester

                            loadcurrentregistration()
                            btnRetrieveLevelSubs.Visible = True
                            txtNxtLvl.Enabled = True
                            txtNxtLvl.ReadOnly = False
                            txtNxtSem.Enabled = True
                            txtNxtSem.ReadOnly = False


                            lbSubjects.Visible = True
                            pnlRegister.Visible = True
                            pnlnextEnrollment.Visible = True
                            hlViewEnrollmentForm.Visible = True
                            chkenableupdate.Checked = True

                        End If
                    End While


                End If
            Catch ex As Exception
                Label1.Text = ex.Message
            Finally
                cnn.Close()

            End Try
        End If




    End Sub

    Private Sub loadcurrentregistration()

        Dim cmd As New SqlCommand
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim sql As String
        Dim drr As SqlDataReader
        sql = "select 'True' as Slct , case regstatus when 'Registered' then 'Drop' when 'Dropped' then 'Register' end as Register ,studentsubjects.subjectid , subject from studentsubjects " &
            " inner join subjects on studentsubjects.subjectid = subjects.subjectid " &
            " Where studentsubjects.studentid = '" & Student & "' and studentsubjects.year = '" & CurrLevel & "' and studentsubjects.semester = '" & CurrSemester & "' and studentsubjects.program = '" & Program & "'"
        '           " union " &
        '           "select 'False' as Slct ,  'Drop'  as Register ,studentsubjects.subjectid , subject from studentsubjects " &
        '" inner join subjects on studentsubjects.subjectid = subjects.subjectid " &
        '           " Where studentsubjects.studentid = '" & Session("userName") & "' and studentsubjects.year = '" & CurrLevel & "' and studentsubjects.semester = '" & CurrSemester & "' and studentsubjects.program = '" & Session("Program") & "'"

        cmd.CommandText = sql
        cmd.Connection = cnn
        cnn.Open()


        drr = cmd.ExecuteReader()

        gdSubjects.DataSource = drr
        gdSubjects.DataBind()
        disableSelectColm(False)

    End Sub

    Public Function checkfees() As Double
        Dim sum As Double
        Dim cmd As New SqlCommand
        Dim cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim sql As String = " select isnull(sum(amount),0) from ledgertransactions where accnumber  = '" & Session("userName") & "' and pperiod <= ( select period from resultscutoff)"
        ' Dim sql1 As String = " select bbf from ledgerbbf where accnumber  = '" & Session("userName") & "'"
        cmd = New SqlCommand(sql, cnn)
        cnn.Open()
        Try
            sum = cmd.ExecuteScalar
            cnn.Close()
        Catch ex As Exception
            cnn.Close()
        End Try
        sum = Math.Round(sum, 2)

        If sum > 0 Then
            'Label1.Text = "Registration not possible ,Account balance is $ " & sum & ""
            'btnRegister.Enabled = False
            'lbSubjects.Visible = False
            Return True
        Else
            Return True
        End If
    End Function

    Private Sub getlevelsubs(ByVal addsubs As String)
        Dim cnn2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
        Dim drr As SqlDataReader
        Dim cmd As New SqlCommand
        Dim sql As String
        'Select Case subject from subjectprograms group by subject,program having  substring(subjectprograms.subject,5,1) =
        '" & YearComboBox2.Text & "' and  substring(subjectprograms.subject,6,1) =  '" & SemesterComboBox.Text & "' and program = '" & ProgramComboBox.Text & "'
        If proceed Then
            If addsubs <> "" Then



                sql = "select 'True' as Slct, 'Register' as Register,s.SubjectID ,s.Subject  from SubjectS S " &
        " inner join SubjectPrograms P on p.subject = s.SubjectID " &
        " where p.Program = '" & Trim(Program) & "' and p.level = " & NextLevel & " and  p.semester = " & NextSemster & " " &
          " union " & addsubs

                '   ListBox1.Items.Clear()

            Else


                sql = "select 'True' as Slct, 'Register' as Register ,s.SubjectID ,s.Subject  from SubjectS S " &
        " inner join SubjectPrograms P on p.subject = s.SubjectID " &
        " where p.Program = '" & Trim(Program) & "' and p.level = " & NextLevel & " and  p.semester =   " & NextSemster & ""





            End If
        Else ' Not Proceeding 

            sql = addsubs

        End If



        cmd.CommandText = sql
        cmd.Connection = cnn2
        cnn2.Open()


        drr = cmd.ExecuteReader()



        gdSubjects.DataSource = drr
        gdSubjects.DataBind()

        disableSelectColm(False)

    End Sub



    Private Sub disableSelectColm(disable As Boolean)
        For i = 0 To gdSubjects.Rows.Count - 1
            gdSubjects.Rows(i).Cells(0).Enabled = disable
        Next
    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        Activateenrollemnt()


    End Sub


    Private Sub Activateenrollemnt()
        Dim cnn2 As SqlConnection = New SqlConnection(ConnectionString)
        Dim cmd As SqlCommand
        Dim sql As String
        Dim ref As Guid
        Dim trans As SqlTransaction
        ref = Guid.NewGuid
        Dim cnt As Integer
        Dim subject As String

        Dim params As List(Of SqlParameter)

        Student = Session("userName")
        Program = txtProgram.Text


        For i = 0 To gdSubjects.Rows.Count - 1
            If CType(gdSubjects.Rows(i).FindControl("chkInclude"), CheckBox).Checked = True Then
                cnt += 1
            End If
        Next



        If cnt = 0 Then
            lbstatus.Text = "Select at Least 1 Subject."

            Exit Sub
        End If

        Try
            cnn2.Open()
            trans = cnn2.BeginTransaction

            sql = "spMigrateStudent"

            cmd = New SqlCommand(sql, cnn2, trans)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@stud", Student)
                .Parameters.AddWithValue("@oldprogram", Program)
                .Parameters.AddWithValue("@newprogram", Program)
                .Parameters.AddWithValue("@oldlevel", txtLvl.Text)
                .Parameters.AddWithValue("@newlevel", txtNxtLvl.Text)
                .Parameters.AddWithValue("@oldsem", txtSem.Text)
                .Parameters.AddWithValue("@newsem", txtNxtSem.Text)
                .Parameters.AddWithValue("@keepoldclass", True)
                .Parameters.AddWithValue("@user", Student)
                .ExecuteNonQuery()

            End With
            If Not chkenableupdate.Checked Then
                sql = "delete studentsubjects where studentid = '" & Student & "' and year = '" & txtNxtLvl.Text & "' and semester = '" & txtNxtSem.Text & "' and program = '" & Program & "'"
                cmd = New SqlCommand(sql, cnn2, trans)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
            End If


            For Each row As GridViewRow In gdSubjects.Rows
                params = New List(Of SqlParameter)
                Dim regstatus As String = CType(row.FindControl("Register"), DropDownList).Text
                Dim chkd As Boolean = CType(row.FindControl("chkInclude"), CheckBox).Checked

                If chkd Then
                    sql = "spRegisterSubjects"
                    subject = Trim(row.Cells(2).Text)

                    cmd = New SqlCommand(sql, cnn2, trans)

                    cmd.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@prog", Program)
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@sub", subject)
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@stud", Student)
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@lvl", txtNxtLvl.Text)
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@sem", txtNxtSem.Text)
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@regstatus", IIf(regstatus = "Register", "Registered", "Dropped"))
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@regtype", "Web")
                    cmd.Parameters.Add(param)

                    param = New SqlParameter("@user", Student)
                    cmd.Parameters.Add(param)

                    cmd.ExecuteNonQuery()
                End If


            Next


            trans.Commit()
            Session("Level") = Val(txtNxtLvl.Text)
            Session("Semester") = Val(txtNxtSem.Text)

            lbstatus.Text = "Registration successful,click on Link to print enrollment form"
            hlViewEnrollmentForm.Visible = True



            ' cnn2.Close()
        Catch ex As Exception

            lbstatus.Text = "Registration failed ,contact Registrar's office for assistance - " & ex.Message
            hlViewEnrollmentForm.Visible = False
        Finally
            cnn2.Close()
        End Try







    End Sub

    Protected Sub btnRetrieveLevelSubs_Click(sender As Object, e As EventArgs) Handles btnRetrieveLevelSubs.Click
        Dim cnn As New SqlConnection(ConnectionString)
        Dim sql As String = "spGetProgramSubjects_Level"
        Dim cmd As New SqlCommand(sql, cnn)
        cnn.Open()
        Dim subs As SqlDataReader = Nothing

        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@prog", txtProgram.Text)
            .Parameters.AddWithValue("@lvl", Val(txtNxtLvl.Text))
            .Parameters.AddWithValue("@sem", Val(txtNxtSem.Text))
            subs = .ExecuteReader
            gdSubjects.DataSource = subs
            gdSubjects.DataBind()

            disableSelectColm(True)

            If (Val(txtNxtLvl.Text) = Val(txtLvl.Text)) And (Val(txtNxtSem.Text) = Val(txtSem.Text)) Then
                chkenableupdate.Checked = True
            Else
                chkenableupdate.Checked = False
            End If


        End With
    End Sub
End Class