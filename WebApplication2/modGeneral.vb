
Imports System
Imports System.Data.SqlClient
Imports System.Net.Mail

''Imports atlantic_BLL_01
''Imports atlantic_BLL_02
''Imports atlantic_BLL_libAtlantic

Public Enum EmailType
    ConfirmApplication = 6
    ApplicationSubmitted = 1
    DecisionMade = 5
    StudentAccepted = 3
    StudentDeclined = 4
    StudentIDAssigned = 2
    ApplicationReceived = 7
    OfferAccepted = 8
    ApplicationWithDrawn = 9
    PasswordRequest = 10
    UserCreated
    ExamRegistration
    RegistrationCancelled
End Enum

Public Module modGeneral

    Public strcopyright As String = "©" & Year(Now.Date) & " Imela Technologies"
    Public linkmsg As String

    Public osmtpclient As New CSmtp()
    Public oSchoolInfo As New cSchoolInfo()
    ' Public filetype As List(Of String)
    Public staffreg, studfeesstatement As Boolean
    Public Const const_persdetails As String = "PersonalDetails"
    Public Const const_enroldetails As String = "EnrolDetails"
    Public Const const_contdetails As String = "ContDetails"
    Public Const const_sponsordetails As String = "SponsorDetails"
    Public Const const_Medicaldetails As String = "MedicalDetails"
    Public Const const_PrevSchooldetails As String = "PrevSchoolDetails"
    Public Const const_Bankingdetails As String = "BankingDetails"

    Public postedfile As HttpPostedFile = Nothing
    Public Const const_image As String = "Image"
    Public parameters As List(Of SqlParameter)
    Public param As SqlParameter
    Public PendingUpdate As Boolean
    Public pos As Integer = 0
    Public sessions(1) As String
    Public studs As Integer = 0
    Public staffnumber, staffname, staffsurname, gstrcuttoff As String
    Public temp1(400) As Byte
    Public temp2(400) As Byte
    Public sql As String = ""
    Public drr As SqlDataReader = Nothing

    Public clas, intake, session, level, sem, program As String
    Public cnctera, getinfoera, drawera, nodev_era As Boolean
    Public gstrReceipt As String
    Public sesscollection As String = ""
    Public gblnsinglebil, gblnsinglemsg, gblnsinglesub, gblnsingleliv, gblnsinglemark, studcheckList As Boolean
    Public idinit, genderinit, proginit, yearinit, enrolinit, sessint, seminit, intakeinit, date_enrolinit As String
    Public gblnconfirmUpdate As Boolean = False
    Public goUser As clsUser
    '  Public Loggeduser As clsUser
    Public gblnaddbookissue, gblnaddbook As Boolean
    Public gstrstudid, gstrstud2, gstrstaffid As String
    Public enteredsupedit As Boolean = False
    Public enteredrepedit As Boolean = False
    Public enteredredoedit As Boolean = False
    Public gblErrorMarks, gblDelMarks As Boolean
    Public gblClassList As Boolean = False
    'Public goCashSale As clsCashSale
    Public garrSaleData(,) As String
    Public gstrCustomPath, gstrCondensedPath, gstrReportPath As String
    Public gstrCompanyName, gstrUserName, gstrCompanyDepoID As String
    Public gstrDepoName, gstrRecPrefix, gstrInvPrefix As String
    Public gstrDebtorPrefix$
    Public gintDPrefixLength%
    Public gstrSystemDate, gstrLastAgedDate As String
    Public gdteSystemDate, gdteLastAgedDate As Date
    Public gintRecPrefLen, gintInvPrefLen As Integer
    ' Public gcrvMain As CrystalReportViewer

    Public gdtFinYearStart, gdtFinYearEnd As Date
    ''Public goKernel As clsAllDeclarations
    ''Public goMajorDomo As clsMajorDomo
    Public gintTheGroup
    Public gsngDaysToAge As Single
    Public gblnError, gblnCreditSale As Boolean
    Public gstrPayType, gstrCustomerName, gstrCustomerAddress, gstrcashtype, gstruser As String
    Public gstridgroup, gstridclass, gstridterm, gstridsess1, gstridsess2, gstridyr1, gstridyr2 As String
    Public gstrpassrateboard, gstrpassrateprog As String
    Public gstrStaffstatus As String
    Public gblnstaffbyType, gblnstaffbydesignation, gblnstaffbycontract, gblnstaffQualByStaff, gblnstaffqualbyqual, gblnSchoolParticulars, gblnSchoolCurricula As Boolean

    Public gblnpassrateperboard, gblnpassrateperpro As Boolean
    Public gblnidbyClass, gblnidbyGroup As Boolean
    Public gdatelogfrm, gdatelogTo As Date
    Public gblnlogdin, gblnbysuer, gblnbydate As Boolean
    Public gstrTelephone, gstrIDNo, gstrChq As String
    Public gstrBankNm, gstraAccNo, gstrDebtorAcc As String
    Public gblnDebtorsExist
    Public gintDebtorsCount
    Public gstrTvSelNod As String, gstrSlectedprog, gstrSlectedStudID As String, gstrSelectedYear As String, gstrSelectedSem, gstrTransRef, gstrTrsnsClass, gstrtransintake As String, transyears As Boolean
    Public gstrSubSlctedStud, gstrSubSlctdYear, gstrSubSlctdSem, gstrSubSlctdProg, gstrsubSlctdClass, gstrSubSlctdSess As String, subyears, rbClassSubs, rbSubSpec As Boolean
    Public gstrSubStudsSlctID, gstrSubStudsSlctdYear, gstrSubStudsSection, gstrstudsubSect, gstrsubstudlvl, gstrsubstudsem, gstrsubstudsess As String
    Public gstrClassStudsSlctProg, gstrClassSection, gstrClassStudsenrol, gstrClassStudsenIntake, gstrClassYr, gstrClassYr2, gsrtClassStudsSem, gstrClassStudsSess, gstrClassStudsSess2, gstrClassStudsSex As String
    Public allsexes As Boolean
    Public gstrSchoolEnrolCls, gstrschoolsection, gstrSchoolEnrolStatus, gstrSchoolEnrolSession, gstrschoolEnrolSemester, gstrknwhowanalprog, gstrknwhowanalclass, gstrknwhowanallevl, gstrknwhowanalsem, gstrknwhowanalintak, gstrknwhowanalsess As String
    Public gdtenrolPeriodAnalysisDatefrom, gdtenrolPeriodAnalysisDateTo As Date
    Public allstatus As Boolean
    Public gstrSubPntEnrol, gstrSubPntSub, gstrStudPersStatus, gstrSubPntIntake, gstrSubPntSect, gstrSubPntSess As String
    Public gstrDetailedMarksProg, gstrDetailedMarksLevel, gstrDetailedMarksClass, gstrDetailedMarksSem, gstrDetailedMarkRef, gstrDetailedMarkSect, gstrTransSumStud, gstrDetailedMarksIntake As String, gblDetRes, gblSumRes, gblDispRes, gblnTransSum, gblnResltStat, gblnResPublish As Boolean
    Public gstrStudContactsSession, gstrcontactsProgram, gstrContactsLevel, gstrContactsSemester, gstrContactsSubject, gstrContactsClass, gstrContactsIntk, gstrcontactssect As String
    Public gstrContSectionChecked, gstrContSubChecked, gstrContClassChecked, gstrAllContacts As Boolean
    Public gstrsubCourseMark, gstrExamMark As String
    Public gblnCancelledMarks As Boolean = False
    Public addforms As Boolean = False
    Public gstrprofilestud, gstrprofileexam, gstrprofileperiod As String
    Public gstrHsMarksProg, gstrHsMarksStud, gstrHsMarksClass, gstrHsMarksLev, gstrHsMarkSess, gstrHsMarkSessto, gstrHsMarksSem, gstrHsMarksRef, gstrHsMarksSub, gstrMarkSection As String
    Public gblnHsMarksPerClass, gblnHsMarksPerLev, gblnHsMarksPerStud, gblnHsMarksPerSub, gblnHsPublish, gblnReportPerstud, gblnreportPerClass, gblnmailperclass, gblnconsolmarks, gblna4Reports, gblnBookletReports As Boolean
    Public gstrExamAttExam, gstrExamAttSub As String
    Public gblnAllSubStuds, gblnExamAtt, gblnMarkSheet, gblnCourseWek, gblnPerSubject, gblnPerProgram As Boolean
    Public gstrmarksheetExam, gstrmarksheetProg, gstrmatrksheetintk As String
    Public gstrAccPrgm, gstrAccClass, gstrAccClass2, gstrAccStatus, gstrAccLvl, gstrAccLvl2, gstrAccSem, gstrAccPrdFrom, gstrAccSection, gstrAccPrdTo, gstrAccIntk, gblnAccPerClass, gblnAccPerForm, gblnAccDebtors, gblnAccPerSub, gstrAccSub, gstrAccSess, gstrAccSess2, gblnAccPerStud, gblnClassStat, gblnSectDebts, gstrAccStud, gstraccAddinfo As String
    Public gdatefrom, gdateTo, gpdatefrom, gpdateto As Date
    Public gstrfizpaypfrom, gstrfizpaypto, gstrYearLeft, gstrtermleftfrom, gstrtermleftTo, gstrReasonLeft As String
    Public chckdtaerange As Boolean
    Public gblnFeesDetail, gblnFeesAnalysis, gblnByType, gblnBymode, gblnbyUser As Boolean
    Public addLibMem As Boolean, enrolPeriodAnalysis, clsperiodanalysis As Boolean
    Public gstrSubStudsProg, gstrSubStudsCls, gstrSubStudsIntk, gstrSubStudsLvl, gstrSubStudsSem, gstrSubStudsSess As String
    Public gdtdropdSubFrom, gdtdrpsubTo As Date
    Public schoolsections, panel, groups As Boolean
    Public gstrKnowHowYear As String
    Public gstrperiod As String = ""
    Public era As Boolean = False
    Public eramsg As String
    Public gstrLectAssLect, gstrLectAssProg, gstrLectAssSub, gstrLectAssYr, gstrLectAssSem, gstrLectAssSess, gstrLectAssIntk, gstrLectAssCls, gstrLectAssSect As String
    Public gstrDeptAssSchool, gstrDeptAssCls, gstrDeptAssIntk, gstrDeptAssSem As String
    Public gblnAllDeptAnal As Boolean = False
    Public gstrLectRatingSect, gstrLectRatingCls, gstrLectRatingIntk As String
    Public gblnBysection As Boolean
    Public gblnStaffAssPerClass, gblnStaffAssPerLect, gblnStaffAssPerSub, gblnStaffAssPerSect As Boolean
    Public gblnDepartmentalAssessment, gblnDepartmentAssessmentDel, gblnLectureAssessmentDel As Boolean
    '  gblnDepartmentalAssessment = false :
    'gblnDepartmentAssessmentDel = false : gblnLectureAssessmentDel = false 
    Public gstrColAvgClas, gstrColAvgIntk As String
    Public gstrSubtotClas, gstrSubtotteacher, gstrSubtotTerm, gstrSubtotSub As String
    Public gblnsubtaughtperteacher, gblnsubtaughtpersubject As Boolean
    Public gstrGeneralAnalClass, gstrGeneralAnalIntk, gstrGeneralAnalSect As String
    Public gstrEnrolFormStud, gstrEnrolFormLvl, gstrEnrolFormSem As String
    Public gstrreg3prog, gstrreg3session, gstrreg3section, gstrreg3class, gstrreg3intake, gstrreg3subject As String
    Public gstrSubRegCls, gstrSubRegIntk, gstrSubRegSub, gstrSubRegSect, gstrSubRegSess, gstrSubRegLvl, gstrSubRegProg, gstrSubRegSem As String
    Public gstrClsRegCls, gstrClsRegForm, gstrClsRegTerm, gstrClsRegSess, gstrClsRegStud As String
    Public gstrstaffregdatefrm, gstrstaffregdateto As Date
    Public gblnstaffregbydate, gblnstaffregbystaff As Boolean
    Public gblnreceipt, gblnReceiptCopy, gblnSubRegPerStud, gblnsubregpersub, gblnClsRegPerDay, gblnClsRegPerCls, gblnClsRegPerStud, gblnhardcopy, receiptprnt, studprnt, lectprnt, enrolform, stmntprnt, clsprint As Boolean
    Public gstrSubRegDateFrom, gstrSubRegDateTo, gstrClsRegDateto, gstrclsregatefrom, gstrSubRegStud, gstrissueno, gstrcreditorsPrdTo, gstrcreditorsPrdfrom As String
    Public rbBookmasterPerbook, rbBookmasterPerLvl, rbBookmasterSummary, rbBookmasterSummaryPerProg, gblnIncExpDetailed, gblnIncExpSummary, rbissuesbybook, rbissuesbyStud, gblnborrowhisPerBook, gblnBorrowhisPerStud, rbissuesbyDate, gblncreditorstatement, gblnAllCreditors, gstraddtitle, lbryissue, gblnOtherDebtors As Boolean
    Public gstrIncExpdatefrm, gstrIncExpdateTo, gstrbookissuefrm, gstrdueby, gstrbookissueTo As Date

    Public gstrIncExpCrt, gstrcreditorsCreditor As String
    Public gstrbookref, gstrborrowhist As String
    Public gblnprntbk As Boolean
    Public studreg As Boolean
    Public emailsent As Boolean = False
    Public Function getHOD(school As String) As List(Of Enrol)
        Dim hods As New List(Of Enrol)
        Dim hod As Enrol
        Dim reader As SqlDataReader
        Dim grp As String = ""


        Select Case school
            Case "Business School"
                grp = "HOD_BusSchool"
            Case "IT"
                grp = "HOD_IT"

        End Select

        sql = "select   usr_fullname , usr_email from users " &
         " inner join usergroups on ugp_usergroup =  usr_usergroup " &
        " where ugp_groupname in  ('Registrar','Admissions Office','" & grp & "')"

        reader = ExecuteReader(sql,, True)
            While reader.Read
                Dim enrol As Enrol = New Enrol
                hod = enrol
                hod.FullName = reader(0).ToString
                hod.Email = reader(1).ToString
                hods.Add(hod)
            End While


        Return hods


    End Function


    Public Function fillAllStuds(ByVal offset As Integer, ByVal filter As Integer, nextbtn As Button, prevbtn As Button, lbDisplay As Label, prog As String, clas As Integer, lvl As Integer, Sem As Integer, sess As String, intk As String) As SqlDataReader

        Dim sql, program As String
        Dim adapter As New SqlDataAdapter()
        Dim cnn As New SqlConnection(My.Settings.soccerConnectionString)
        cnn.Open()
        Dim drr As SqlDataReader
        Dim itms As Integer = 0

        If filter > 0 Then
            sql = "Select  StudentPersonalDetails.StudentID, StudentPersonalDetails.StudentName, StudentPersonalDetails.StudentSurname,studentpersonaldetails.session,count(*) over() as cnt ,enrolref " &
   " FROM            StudentPersonalDetails INNER JOIN " &
           " enrollment On StudentPersonalDetails.StudentID = enrollment.StudentID  " &
   " WHERE        enrollment.Program = '" & prog & "' AND enrollment.yearjoined = '" & clas & "'  AND enrollment.Year = '" & lvl & "' AND enrollment.Semester = '" & Sem & "' AND " &
           " enrollment.Intake = '" & intk & "'  AND enrollment.Session  = '" & sess & "' " &
           " and studentpersonaldetails.studentid not in (select studentid from studentleaving )" &
           " order by  StudentPersonalDetails.StudentID " &
           " offset " & offset & " rows fetch next  " & filter & " rows  only "
            drr = ExecuteReader(sql,, True)


            If drr.HasRows Then

                While drr.Read
                    itms = drr("cnt")
                    Exit While
                End While

            End If

            GridDisplayPanel(offset, filter, itms, prevbtn, nextbtn, lbDisplay)
        Else
            sql = "Select  StudentPersonalDetails.StudentID, StudentPersonalDetails.StudentName, StudentPersonalDetails.StudentSurname,studentpersonaldetails.session,count(*) over() as cnt ,enrolref" &
   " FROM            StudentPersonalDetails INNER JOIN " &
           " enrollment On StudentPersonalDetails.StudentID = enrollment.StudentID " &
   " WHERE        enrollment.Program = '" & prog & "' AND enrollment.[YearJoined] = '" & clas & "'  AND enrollment.Year = '" & lvl & "' AND enrollment.Semester = '" & Sem & "' AND " &
           " enrollment.Intake = '" & intk & "'  AND enrollment.Session  = '" & sess & "'" &
                    " and studentpersonaldetails.studentid not in (select studentid from studentleaving )" &
           " order by  StudentPersonalDetails.StudentID " &
           " offset 0 rows "
            drr = ExecuteReader(sql,, True)


            If drr.HasRows Then

                While drr.Read
                    itms = drr("cnt")
                    Exit While
                End While

            End If

            GridDisplayPanel(offset, itms, itms, prevbtn, nextbtn, lbDisplay)
        End If


        'adapter.SelectCommand = New SqlCommand(sql, cnn)
        'adapter.Fill(DSclassStuds, "StudentPersonalDetails")
        'cnn.Close()




        '   dgClassStudents.Visible = True
        Return drr


    End Function

    Public Sub GridDisplayPanel(ByVal offset As Integer, filter As Integer, itms As Integer, prev As Button, nxt As Button, disp As Label)
        If offset = 0 Then
            If itms <= filter Then
                disp.Text = "1 to " & itms & " of " & itms
                disableGridButtons(prev, nxt, True)
            Else
                disp.Text = "1 to " & filter & " of " & itms
                disableGridButtons(prev, nxt)
            End If

        ElseIf offset + filter >= itms Then
            disp.Text = (offset + 1) & " to " & itms & " of " & itms

            disableGridButtons(nxt, prev)
        Else
            disp.Text = (offset + 1) & " to " & offset + filter & " of " & itms

            disableGridButtons(nxt, nxt)

            disableGridButtons(prev, prev)
        End If


    End Sub
    Public Function initfiles(entry As String, school As String, program As String) As List(Of String)
        Dim filetype As List(Of String) = New List(Of String)
        Dim docs As SqlDataReader
        Dim sql As String = "select doc from progdocs where program = '" & program & "' and school = '" & school & "' and entrytype = '" & entry & "'"
        docs = ExecuteReader(sql,, True)
        While docs.Read
            filetype.Add(docs(0))
        End While

        Return filetype
    End Function

    Public Sub disableGridButtons(disabled As Button, enabled As Button, Optional ByVal disableboth As Boolean = False)

        If disableboth Then
            disabled.Enabled = False
            enabled.Enabled = False
        Else
            If enabled.ID = disabled.ID Then
                enabled.Enabled = True
            Else
                disabled.Enabled = False
                enabled.Enabled = True
            End If
        End If




    End Sub

    Public Function SendEmail(ByVal stud As Enrol, emailtype As EmailType, Optional ByRef UI As Guid = Nothing, Optional msg As String = "") As Boolean
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        osmtpclient = New CSmtp()
        Dim emailfrom As String = osmtpclient.MailFrom
        Dim password As String = osmtpclient.Password
        Dim messages As SqlDataReader
        linkmsg = ""
        Dim link As String

        If stud.Email = "" Then
            Return False
        End If

        Dim strmessage As String = ""
        Dim subject As String = ""


        Dim cnn As New SqlConnection(ConnectionString)

        Try

            sql = "select [content],description from messages where [type] = '" & emailtype & "'"
            cnn.Open()
            Dim cmd As New SqlCommand(sql, cnn)
            messages = cmd.ExecuteReader
            If msg <> "" Then
                strmessage = msg

            ElseIf messages.HasRows Then
                While messages.Read
                    strmessage = messages(0)
                    subject = messages(1)
                End While
            Else
                '      Throw New Exception("Messages not maintaned")
                Return False
            End If


        Catch ex As Exception
        Finally
            cnn.Close()
        End Try




        strmessage = "Dear " & stud.FullName & vbNewLine & strmessage


        pos = InStr(Trim(strmessage), "#")
        If pos > 0 Then

            strmessage = Mid(Trim(strmessage), 1, pos - 1) & " " & stud.Student & " " & Mid(Trim(strmessage), (pos + 1))
        End If

        Try
            'Net.NetworkCredential("tangaiwasb@gmail.com", "bothwell")
            SmtpServer.Credentials = New _
        Net.NetworkCredential(emailfrom, password)
            SmtpServer.Port = osmtpclient.Port '587
            SmtpServer.EnableSsl = True
            '  SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.Host = osmtpclient.Server
            mail = New MailMessage()
            mail.From = New MailAddress(emailfrom)
            mail.To.Add(stud.Email)
            If emailtype = EmailType.ConfirmApplication Then
                '    link = "http://192.168.1.4:8000/Student/OnlineApplication/RegConfirm.aspx?Reference=" & UI.ToString
                link = "https://exams.trustacademy.co.zw:444//Student/OnlineApplication/RegConfirm.aspx?Reference=" & UI.ToString
                '  link = "http://localhost:51310/Student/OnlineApplication/RegConfirm.aspx?Reference=" & UI.ToString
                mail.Subject = subject
                mail.Body = "Please click link below to activate application:  " & vbNewLine & link
            ElseIf emailtype = EmailType.ApplicationSubmitted Then
                mail.Subject = subject
                mail.Body = strmessage
            ElseIf emailtype = EmailType.DecisionMade Then
                mail.Subject = subject
                mail.Body = strmessage

            ElseIf emailtype = EmailType.StudentDeclined Then
                mail.Subject = subject
                mail.Body = strmessage
            ElseIf emailtype = EmailType.StudentIDAssigned Then
                mail.Subject = subject
                mail.Body = strmessage
            ElseIf emailtype = EmailType.StudentAccepted Then
                mail.Subject = "Student Enrolled"
                mail.Body = strmessage

            ElseIf emailtype = EmailType.ApplicationReceived Then
                mail.Subject = "Application received"
                mail.Body = strmessage

            ElseIf emailtype = EmailType.ApplicationWithDrawn Then
                mail.Subject = "Application WithDrawn"
                mail.Body = strmessage
            ElseIf emailtype = EmailType.UserCreated Then

                mail.Subject = "Trust Academy Portal Account"
                mail.Body = strmessage
            ElseIf emailtype = EmailType.PasswordRequest Then

                mail.Subject = "Password Request"
                mail.Body = strmessage

            ElseIf emailtype = EmailType.ExamRegistration Then

                mail.Subject = stud.ExamSession & " Registration"
                mail.Body = strmessage

            ElseIf emailtype = emailtype.RegistrationCancelled Then

                mail.Subject = stud.ExamSession & " Registration Cancelled"
                mail.Body = strmessage

            End If

            SmtpServer.Send(mail)
            Return True
            '   errorstatus.Text = ""
        Catch ex As Exception
            linkmsg = ex.Message
            Return False
        End Try






    End Function

    Public Function GetNextTableID2%(ByVal Tbl$, ByVal Fld$, ByVal Rec As Boolean, Optional ByVal Prefix% = 0,
                                  Optional ByVal Cdn$ = "", Optional ByVal CastAsInt As Boolean = False,
                                  Optional ByVal planB As Boolean = False, Optional ByVal planC As Boolean = False)
        Dim sql$ = ""
        Dim intResult% = 1
        Dim oResult As Object = Nothing
        Dim StartingPos% = 0
        StartingPos = Prefix + 1
        Try
            If CastAsInt Then
                If Prefix > 0 Then
                    sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" & Fld & ", " & StartingPos & ", LEN(" & Fld & ") - " & Prefix & " ) AS INTEGER)),0) + 1 FROM " & Tbl
                Else
                    sql = "SELECT ISNULL(MAX(CAST(" & Fld & " AS INTEGER)),0) + 1 FROM " & Tbl
                End If
            Else
                If Rec = True Then
                    If Prefix > 0 Then
                        sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" & Fld & ", " & StartingPos & ", LEN(" & Fld & ") - " & Prefix & " ) AS INTEGER)),0) + 1 FROM " & Tbl &
                        " where invoice is null "
                    Else
                        sql = "SELECT ISNULL(MAX(" & Fld & "),0) + 1 FROM " & Tbl & " where invoice is null"
                    End If
                Else
                    sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" & Fld & ", " & 5 & ", LEN(" & Fld & ") - " & 4 & " ) AS INTEGER)),0) + 1 FROM " & Tbl


                End If
            End If

            sql += Cdn
            oResult = ExecuteScalar(sql, planB, planC)
            If Not IsNothing(oResult) Then
                intResult = CInt(oResult)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "error getting next id")
        Finally
            CloseConnection(planB, planC)
        End Try
        Return intResult
    End Function
    Public Function checkInbuilt(ByVal strchktxt As String) As Boolean
        If InStr(strchktxt, "-") > 0 Or InStr(strchktxt, "'") > 0 Or InStr(strchktxt, " ") > 0 Then
            MsgBox("Invalid Code make sure there are no spaces or inbuilt characters in the code")
            Return True
        End If
        Return False
    End Function

    Public Sub ProductView(ByVal Coy$)
        Dim sql$ = ""
        Dim AnError As Boolean = False
        sql = "IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwCompanyProducts]')) " &
            "DROP VIEW [dbo].[vwCompanyProducts] "
        ExecuteNonQuery(sql, , , AnError)
        sql = "CREATE VIEW [dbo].[vwCompanyProducts] " &
            "AS " &
            "SELECT     Stk_Code, Stk_Code + ' - ' + Stk_Description AS Description, " &
                "Stk_UoM, Stk_UnitPrice, Stk_EntryID, Stk_Supplier, STk_Group " &
        "FROM StockItems " &
        "WHERE Stk_Group IN (SELECT Com_Group FROM dbo.CompanyMaterials " &
        "WHERE Com_Company ='" & Coy & "')"
        ExecuteNonQuery(sql, , , AnError)
    End Sub
    Public Sub CheckDebtors()
        Dim sql As String
        Dim oResult As Object = Nothing
        sql = "SELECT COUNT(Det_Code) FROM dbo.Debtors"
        oResult = ExecuteScalar(sql)
        If Not IsNothing(oResult) Then
            gintDebtorsCount = CInt(oResult)
        End If
    End Sub



    Public Function GetCorrectAmt(ByVal txt As String) As Double
        Dim TheAmt As Double = 0
        Dim TheText As String = ""
        Try
            If InStr(txt, "$ ") > 0 Then
                TheText = Mid(txt, 2)
                TheAmt = CDbl(TheText)
            Else
                TheAmt = CDbl(txt)
            End If
        Catch
        End Try
        Return TheAmt
    End Function

    Public Function CamelCase(ByVal Passed$) As String
        Dim TheThing$ = ""
        Dim i, j, k As Integer
        i = 0 : j = 0 : k = 0
        Try
            TheThing = UCase(Mid(Passed, 1, 1))
            TheThing = TheThing + LCase(Mid(Passed, 2))
        Catch
            TheThing = Passed
        End Try
        Return TheThing
    End Function
    ''Private Sub CheckQty()
    ''    Try
    ''        Sql = "SELECT Stk_Quantity FROM dbo.StockItems WHERE Stk_Code ='" & Itm & "'"
    ''        oResult = ExecuteScalar(Sql)
    ''        If Not IsNothing(oResult) Then
    ''            k = CInt(oResult)
    ''            If Val(txtQty.Text) > k Then
    ''                ItsOk = False
    ''                MsgBox("Amount in stock is " & k & " enter a valid amount", MsgBoxStyle.Exclamation, "qauntity too large")
    ''                Exit Sub
    ''            End If
    ''        End If
    ''    Catch ex As Exception
    ''    End Try
    ''End Sub
    'Public Sub RptPreview(ByVal frm As Form, ByVal CloseBtn As System.Windows.Forms.Button, _
    '   ByVal PreviewBtn As System.Windows.Forms.Button, ByVal rpt$, _
    'Optional ByVal Exportable As Boolean = True, _
    'Optional ByVal Dt As DataSet = Nothing, _
    'Optional ByVal DataTable$ = "", _
    'Optional ByVal arrDtSub() As DataSet = Nothing, _
    'Optional ByVal arrDataTableSub$() = Nothing, _
    'Optional ByVal ZoomLevel% = 100, _
    'Optional ByVal Customised As Boolean = False, _
    'Optional ByVal Condensed As Boolean = False, _
    'Optional ByVal Pnl As Panel = Nothing, _
    'Optional ByVal ReportTile$ = "<< Report Preview >>", _
    'Optional ByVal JustPrintItOk As Boolean = False)
    ' Try
    '     Try
    '         If Dt.Tables(DataTable).Rows.Count = 0 Then
    '             MsgBox("no data for the current selection range", MsgBoxStyle.Information, "no data for report")
    '             Exit Sub
    '         End If
    '     Catch ex As Exception
    '     End Try
    '     frm.Cursor = Cursors.WaitCursor
    '     gstrReportPath = My.Application.Info.DirectoryPath & "\Reports\"
    '     goCurrentForm = frm
    '     InitViewer(Pnl, ReportTile)
    '     If Not IsNothing(PreviewBtn) Then PreviewBtn.Visible = False
    '     If Not IsNothing(CloseBtn) Then CloseBtn.Visible = False
    '     ''frm.Hide()
    '     Dim thePath$
    '     If Customised Then
    '         thePath = gstrCustomPath & rpt
    '     Else
    '         If Condensed Then
    '             thePath = gstrCondensedPath & rpt
    '         Else
    '             thePath = gstrReportPath & rpt
    '         End If
    '     End If
    '     Dim Crx As New ReportDocument
    '     Crx.FileName = thePath

    '     Crx.Database.Tables.Item(DataTable).SetDataSource(Dt)

    '     If Not IsNothing(arrDataTableSub) Then
    '         Dim i% = arrDataTableSub.GetUpperBound(0)
    '         Dim j% = 0
    '         For j = 0 To i
    '             Crx.Subreports(arrDataTableSub(j)).SetDataSource(arrDtSub(j))
    '         Next
    '     End If

    '     With gcrvMain
    '         .ReportSource = Crx
    '         If JustPrintItOk Then
    '             Try
    '                 Crx.PrintToPrinter(1, False, 1, 1)
    '                 If IsNothing(Pnl) Then
    '                     frmReportPreview.Close()
    '                 Else
    '                     Pnl.Dispose()
    '                 End If
    '             Catch
    '             End Try
    '         Else
    '             .Dock = DockStyle.Fill
    '             .ShowExportButton = CType(IIf(Exportable, True, False), Boolean)
    '             .Zoom(ZoomLevel)
    '             .Visible = True
    '         End If
    '     End With
    ' Catch ex As Exception
    '     MsgBox(ex.Message, MsgBoxStyle.Exclamation, "error with report data")
    ' End Try
    ' If Not IsNothing(PreviewBtn) Then PreviewBtn.Visible = True
    ' If Not IsNothing(CloseBtn) Then CloseBtn.Visible = True
    ' frm.Cursor = Cursors.Default
    'End Sub

    Public Function restoredate(ByVal dat As String) As String
        Dim arr As String()

        Dim det, month, yr, fulldate As String
        Try

            arr = dat.Split("-")

            yr = arr(0).ToString
            det = arr(2).ToString

            month = arr(1).ToString

            fulldate = det & "/" & month & "/" & yr
            Return fulldate

        Catch ex As Exception

            Return "01-01-01"
        End Try


    End Function
    Public Function changedatetime(ByVal dat As String) As String
        Dim arr As String()

        Dim det, month, yr, yr2, fulldate As String
        Dim tym As String
        Try

            arr = dat.Split("/")

            yr = arr(2).ToString
            det = arr(0).ToString

            month = arr(1).ToString
            arr = yr.Split(" ")
            yr2 = arr(0)
            tym = arr(1)



            fulldate = yr2 & "-" & month & "-" & det & " " & tym

            Return fulldate

        Catch ex As Exception

            Return "01-01-01"
        End Try


    End Function

    Public Function changefulldate(ByVal dat As String) As String
        Dim arr, arr1 As String()

        Dim det, month, yr2, fulldate, tim, yr As String
        Try

            arr = dat.Split("/")

            yr2 = arr(2).ToString
            arr1 = yr2.Split(" ")
            yr = arr1(0)
            tim = arr1(1)
            det = arr(0).ToString

            month = arr(1).ToString

            fulldate = yr & "-" & month & "-" & det '& " " & tim
            Return fulldate

        Catch ex As Exception

            Return "01-01-01 00:00:00"
        End Try
    End Function

    Public Function TrueDate$(ByVal Dte$, Optional ByVal plsql As Boolean = False, Optional ByVal ABAP As Boolean = False)
        Try
            If plsql Then
                Return Mid(Dte, 8, 4) & "-" & GetMonth(Mid(Dte, 3, 2)) & "-" & Mid(Dte, 1, 2)
            Else
                If ABAP Then
                    Return Mid(Dte, 1, 2) & Mid(Dte, 4, 2) & Mid(Dte, 7, 4)
                Else
                    Return Mid(Dte, 7, 4) & "-" & Mid(Dte, 4, 2) & "-" & Mid(Dte, 1, 2)
                End If
            End If
        Catch ex As Exception
            Return "1900-01-01"
        End Try
    End Function
    Public Function GetVat(ByVal Amt As Double, ByVal Perc As Double, ByVal Incl As Boolean) As Double
        Dim TheVat As Double = 0
        Dim i, j, k As Double
        i = 0 : j = 0 : k = 0
        Try
            If Incl Then
                i = Amt / (1 + (Perc * (0.01)))
                TheVat = Amt - i
            Else
                TheVat = Perc * 0.01 * Amt
            End If
        Catch ex As Exception

        End Try
        Return TheVat
    End Function
    Private Function GetMonth$(ByVal mnth$)
        Dim Num$ = ""
        Select Case LCase(mnth)
            Case "jan"
                Num = "01"
            Case "feb"
                Num = "02"
            Case "mar"
                Num = "03"
            Case "apr"
                Num = "04"
            Case "may"
                Num = "05"
            Case "jun"
                Num = "06"
            Case "jul"
                Num = "07"
            Case "aug"
                Num = "08"
            Case "sep"
                Num = "09"
            Case "oct"
                Num = "10"
            Case "nov"
                Num = "11"
            Case "dec"
                Num = "12"
        End Select
        Return Num
    End Function
    Public Function changedate(ByVal dat As String) As String
        Dim arr As String()

        Dim det, month, yr, fulldate As String
        Try

            arr = dat.Split("/")

            yr = arr(2).ToString
            det = arr(0).ToString

            month = arr(1).ToString

            fulldate = yr & "-" & month & "-" & det
            Return fulldate

        Catch ex As Exception

            Return "01-01-01"
        End Try


    End Function

    Public Function CleanComboVal$(ByVal theVal$)
        Dim CleanValue$ = " "
        Dim i% = 0, j% = 0
        Try
            i = Len(theVal)
            j = InStr(theVal, "-")
            If j > 1 Then CleanValue = Trim(Mid(theVal, 1, j - 1))
        Catch ex As Exception
            CleanValue = " "
        End Try
        Return CleanValue
    End Function
    Public Function CleanComboVal$(ByVal theVal$, ByVal Left$)
        Dim CleanValue$ = " "
        Dim i% = 0, j% = 0
        Try
            i = Len(theVal)
            j = InStr(theVal, "- ")
            If j > 1 Then CleanValue = Trim(Mid(theVal, j + 1))
        Catch ex As Exception
            CleanValue = " "
        End Try
        Return CleanValue
    End Function
    Public Function GetNextTableID%(ByVal Tbl$, ByVal Fld$, Optional ByVal Prefix% = 0,
                                    Optional ByVal Cdn$ = "", Optional ByVal CastAsInt As Boolean = False,
                                    Optional ByVal planB As Boolean = False, Optional ByVal planC As Boolean = False)
        Dim sql$ = ""
        Dim intResult% = 1
        Dim oResult As Object = Nothing
        Dim StartingPos% = 0
        StartingPos = Prefix + 1
        Try
            If CastAsInt Then
                If Prefix > 0 Then
                    sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" & Fld & ", " & StartingPos & ", LEN(" & Fld & ") - " & Prefix & " ) AS INTEGER)),0) + 1 FROM " & Tbl
                Else
                    sql = "SELECT ISNULL(MAX(CAST(" & Fld & " AS INTEGER)),0) + 1 FROM " & Tbl
                End If
            Else
                If Prefix > 0 Then
                    sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" & Fld & ", " & StartingPos & ", LEN(" & Fld & ") - " & Prefix & " ) AS INTEGER)),0) + 1 FROM " & Tbl
                Else
                    sql = "SELECT ISNULL(MAX(" & Fld & "),0) + 1 FROM " & Tbl
                End If
            End If

            sql += Cdn
            oResult = ExecuteScalar(sql, planB, planC)
            If Not IsNothing(oResult) Then
                intResult = CInt(oResult)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "error getting next id")
        Finally
            CloseConnection(planB, planC)
        End Try
        Return intResult
    End Function
    Public Function FillSpace(ByVal ValuePassed As String, ByVal Chr As String, ByVal ChrNumber As Integer,
                               ByVal Left As Boolean) As String
        Dim i, j, k As Integer
        Dim ValueReturned As String = ""
        i = 0 : j = 0 : k = 0
        If Left Then
            ValueReturned = StrDup(ChrNumber, Chr) & ValuePassed
            i = Len(ValueReturned)
            j = i - ChrNumber + 1
            If j > 0 Then
                ValueReturned = Mid(ValueReturned, j)
            Else
                ValueReturned = ValuePassed
            End If
        Else
            ValueReturned = ValuePassed & StrDup(ChrNumber, Chr)
            ValueReturned = Mid(ValueReturned, 1, ChrNumber)
        End If
        Return ValueReturned
    End Function






    Public Function GetTableValue(ByVal Tbl$, ByVal KeyFld$, ByVal SoughtFld$, ByVal Val$,
                         ByVal Numerical As Boolean, Optional ByVal PlanB As Boolean = False,
                         Optional ByVal PlanC As Boolean = False) As Object
        Dim oResult As Object = Nothing
        Dim sql$ = ""
        Dim cnt% = 0
        If Numerical Then
            sql = "SELECT " & SoughtFld & " FROM " & Tbl & " WHERE " & KeyFld & " = " & Val
        Else
            sql = "SELECT " & SoughtFld & " FROM " & Tbl & " WHERE " & KeyFld & " = '" & Val & "'"
        End If

        Try
            While cnt < 3
                Try
                    OpenConnection(PlanB, PlanC)
                    PrepareCmdText(sql, , PlanB, PlanC)
                    oResult = gcmdPos.ExecuteScalar()
                    cnt = 3
                Catch
                    cnt += 1
                End Try
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, " error getting value from the table : " & Tbl)
        Finally
            CloseConnection(PlanB, PlanC)
        End Try
        If IsNothing(oResult) Then
            oResult = "-1"
        End If
        Return oResult
    End Function

End Module
