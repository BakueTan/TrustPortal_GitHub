Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class ApplicationForm
    Inherits System.Web.UI.Page
    Public sql As String
    Public cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Public NXTCONTROL As New Control

    Public ref As String = ""
    Private Docs As List(Of csDocs)
    Private appstud As New Enrol


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        '   ScriptManager1.RegisterAsyncPostBackControl(FileUpload1)
        Session("ActivePage") = "ApplicationForm"


        Dim sql As String

        If Session("Email") <> "" Then


            txtEmail.Text = Session("Email")
            ref = Request.QueryString("Ref")
            lbPAyConfirmation.Text = " Send an application fee of " & oSchoolInfo.BaseCurrenncy & oSchoolInfo.ApplicationFees & " to Merchant Code : " & oSchoolInfo.MerchantCode
            If Not Page.IsPostBack Then

                Dim dobdate As Date

                wzAppForm.ActiveStepIndex = 0
                LoadKnowHow()
                ' ref =
                Dim info As SqlDataReader = Nothing


                If ref <> "" Then
                    sql = "select * from studentapplication where appreference = '" & ref & "'"

                    info = ExecuteReader(sql, True)

                    While info.Read
                        txtEmail.Text = Session("Email")
                        txtFirstNAme.Text = info("FirstName").ToString
                        txtLastName.Text = info("LastName").ToString
                        Date.TryParse(info("dob").ToString, dobdate)
                        txtDOB.Text = dobdate.ToShortDateString()
                        txtcontact.Text = info("Contact").ToString
                        txtAdd1.Text = info("Address1").ToString
                        txtAdd2.Text = info("Address2").ToString
                        txtAddress4.Text = info("Address3").ToString
                        TxtNationalID.Text = info("NationalID").ToString
                        txtPOB.Text = info("POB").ToString
                        dpgender.Text = info("gender").ToString
                        ddlEntryType.Text = info("EntryType").ToString
                        ddlEntryType_SelectedIndexChanged(Me, Nothing)
                        dpSchool.Text = info("School").ToString
                        dpSchool_SelectedIndexChanged(Me, Nothing)
                        dpProgram.SelectedValue = info("Program").ToString
                        dpProgram_SelectedIndexChanged(Me, Nothing)
                        dpIntake.Text = info("Intake").ToString
                        dpclass.Text = info("Class").ToString
                        DpSession.Text = info("Session").ToString
                        dpLevel.Text = info("Level").ToString
                        dpSemester.Text = info("Sem").ToString
                        dpIncome.Text = info("IncomeSource").ToString
                        dpKnowhow.Text = info("KnowHow").ToString
                        txtoccupation.Text = info("Occupation").ToString
                        txtworkphone.Text = info("WorkPhone").ToString
                        txtWorkAddress.Text = info("workAddress").ToString
                        txtRemarks.Text = info("Remarks").ToString
                        ddlCampus.Text = info("Campus").ToString
                        dpPreviouslyStudiedWithTrust.Text = IIf(info("PreviousEnrollment").ToString = "True", "Yes", "No")
                        txtNokName.Text = info("NokName").ToString
                        txtNokAddress.Text = info("NokAddress").ToString
                        txtNokContactNumber.Text = info("NokContact").ToString
                        txtNokEmail.Text = info("NOKEmail").ToString
                        LoadFiles()
                        loadSubjects()




                    End While


                End If
            Else




            End If

        Else
            Response.Redirect("~/SessionExpired.aspx")
        End If


    End Sub


    Private Sub loadSubjects()
        Dim sql As String = ""
        Dim subs As SqlDataReader
        sql = "select subjectid from studsubs where appref = '" & ref & "'"
        subs = ExecuteReader(sql, True)

        If subs.HasRows Then
            gdSubjects.Visible = True
        Else
            gdSubjects.Visible = False
        End If

        While subs.Read
            For i = 0 To gdSubjects.Rows.Count - 1
                If CType(gdSubjects.Rows(i).FindControl("lbSubjectID"), Label).Text = subs(0).ToString Then
                    CType(gdSubjects.Rows(i).FindControl("chkSelectsubject"), CheckBox).Checked = True
                    Continue For

                End If
            Next
        End While

    End Sub

    Private Sub initGrid()


        Dim filetype As List(Of String) = CType(Session("FileType"), List(Of String))
        ' If IsNothing(Docs) Then
        Docs = New List(Of csDocs)
        '   End If

        sql = ""

        For i = 0 To filetype.Count - 1


            Dim doc As New csDocs

            doc.StudentId = ""
            doc.Filename = filetype(i)
            doc.filesize = 0
            doc.FileType = ""
            doc.Doc = Nothing
            doc.Rownumber = i + 1

            Docs.Add(doc)



        Next

        Session("Docs") = Docs

        'param = New SqlParameter("@doc", SqlDbType.VarBinary)
        'param.Value = bytes
        'parameters = New List(Of SqlParameter)
        'parameters.Add(param)
        '  sql = sql & " order by rownumber asc"
        ' Docs.Sort()

        gdFiles.DataSource = Docs
        gdFiles.DataBind()




        gdFiles.DataBind()



    End Sub


    Protected Function changedate(ByVal dat As String) As String
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
    Private Function submitapp() As Boolean

        Dim bytes1(), bytes2() As Byte
        bytes2 = Nothing
        bytes1 = Nothing

        Dim reference As Guid
        reference = Guid.NewGuid

        Dim trans As SqlTransaction

        Dim cnn As New SqlConnection(ConnectionString)

        Docs = CType(Session("Docs"), List(Of csDocs))
        Try
            cnn.Open() '
            trans = cnn.BeginTransaction


            Dim comment As String = "Pending"

            Dim appstatus As String

            If ref = "" Then
                ref = reference.ToString
                appstatus = "Pending"
            Else
                appstatus = "Updated"
            End If

            sql = "spInsertStudApplication "


            Dim cmd As New SqlCommand(sql, cnn, trans)

            cmd.CommandType = CommandType.StoredProcedure


            parameters = New List(Of SqlParameter)
            param = New SqlParameter("@firstname", txtFirstNAme.Text)
            parameters.Add(param)


            param = New SqlParameter("@lastname", txtLastName.Text)
            parameters.Add(param)



            param = New SqlParameter("@email", txtEmail.Text)
            parameters.Add(param)


            param = New SqlParameter("@dob", changedate(txtDOB.Text))
            parameters.Add(param)


            param = New SqlParameter("@gender", dpgender.Text)
            parameters.Add(param)


            param = New SqlParameter("@address1", txtAdd1.Text)
            parameters.Add(param)


            param = New SqlParameter("@address2", txtAdd2.Text)
            parameters.Add(param)


            param = New SqlParameter("@address3", txtAddress4.Text)
            parameters.Add(param)


            param = New SqlParameter("@contact", txtcontact.Text)
            parameters.Add(param)


            param = New SqlParameter("@program", dpProgram.SelectedValue)
            parameters.Add(param)


            param = New SqlParameter("@intake", dpIntake.Text)
            parameters.Add(param)


            param = New SqlParameter("@class", dpclass.Text)
            parameters.Add(param)


            param = New SqlParameter("@session", DpSession.Text)
            parameters.Add(param)


            param = New SqlParameter("@incomesource", dpIncome.SelectedValue)
            parameters.Add(param)


            param = New SqlParameter("@knowhow", dpKnowhow.Text)
            parameters.Add(param)




            param = New SqlParameter("@appreference", ref)
            parameters.Add(param)



            param = New SqlParameter("@appstatus", appstatus)
            parameters.Add(param)


            param = New SqlParameter("@datesubmitted", changedate(Now.Date.ToShortDateString))
            parameters.Add(param)


            param = New SqlParameter("@school", dpSchool.Text)
            parameters.Add(param)



            param = New SqlParameter("@occupation", txtoccupation.Text)
            parameters.Add(param)


            param = New SqlParameter("@workphone", txtworkphone.Text)
            parameters.Add(param)


            param = New SqlParameter("@workaddress", txtWorkAddress.Text)
            parameters.Add(param)


            param = New SqlParameter("@comment", "Pending")
            parameters.Add(param)


            param = New SqlParameter("@remarks", txtRemarks.Text)
            parameters.Add(param)


            param = New SqlParameter("@level", dpLevel.Text)
            parameters.Add(param)


            param = New SqlParameter("@sem", dpSemester.Text)
            parameters.Add(param)


            param = New SqlParameter("@nationalid", TxtNationalID.Text)
            parameters.Add(param)


            param = New SqlParameter("@campus", ddlCampus.Text)
            parameters.Add(param)


            param = New SqlParameter("@previousenrollment", IIf(dpPreviouslyStudiedWithTrust.Text = "Yes", "True", "False"))
            parameters.Add(param)


            param = New SqlParameter("@pob", txtPOB.Text)
            parameters.Add(param)


            param = New SqlParameter("@entrytype", ddlEntryType.Text)
            parameters.Add(param)


            param = New SqlParameter("@nokname", txtNokName.Text)
            parameters.Add(param)


            param = New SqlParameter("@nokaddress", txtNokAddress.Text)
            parameters.Add(param)


            param = New SqlParameter("@nokcontact", txtNokContactNumber.Text)
            parameters.Add(param)


            param = New SqlParameter("@nokemail", txtNokEmail.Text)
            parameters.Add(param)


            For Each par As SqlParameter In parameters
                cmd.Parameters.Add(par)
            Next

            cmd.ExecuteNonQuery()


            If Not IsNothing(Docs) Then

                If Docs.Count = 0 Then
                    btnLoadingPopUp_ModalPopupExternder.Hide()
                    trans.Rollback()
                    lblAppSubmitResult.Text = "Required Documents for this Program's Entry Type are not maintained  , please contact Trust Academy's Admissions Department for more Info."
                    btnConfirmPopUp_ModalPopupExtender.Show()
                    Return False
                End If
                For Each doc In Docs

                    If doc.filesize = 0 Then
                        lblAppSubmitResult.Text = "Document : " & doc.Filename & " missing."
                        trans.Rollback()
                        btnConfirmPopUp_ModalPopupExtender.Show()
                        Return False
                    End If

                    sql = "spInsertDoc"
                    If Not doc.deleted Then

                        cmd = New SqlCommand(sql, cnn, trans)

                        cmd.CommandType = CommandType.StoredProcedure

                        parameters = New List(Of SqlParameter)
                        param = New SqlParameter("@stud", txtEmail.Text)
                        parameters.Add(param)

                        param = New SqlParameter("@docname", doc.Filename)
                        parameters.Add(param)

                        param = New SqlParameter("@doc", doc.Doc)
                        parameters.Add(param)

                        param = New SqlParameter("@filetype", doc.FileType)
                        parameters.Add(param)

                        param = New SqlParameter("@filesize", doc.filesize)
                        parameters.Add(param)

                        param = New SqlParameter("@AppRef", ref)
                        parameters.Add(param)

                        param = New SqlParameter("@fileref", IIf(doc.fileref = "", Guid.NewGuid.ToString, doc.fileref))
                        parameters.Add(param)


                        For Each PAR In parameters
                            cmd.Parameters.Add(PAR)
                        Next

                        cmd.ExecuteNonQuery()


                    End If
                Next
            Else
                btnLoadingPopUp_ModalPopupExternder.Hide()
                trans.Rollback()
                lblAppSubmitResult.Text = "No documents uploaded"
                btnConfirmPopUp_ModalPopupExtender.Show()
                Return False
                '  SendEmail(txtEmail.Text, EmailType.ConfirmApplication)
            End If


            Dim chckdcount As Integer = 0

            sql = "delete studsubs where appref = '" & ref & "'"
            cmd = New SqlCommand(sql, cnn, trans)
                cmd.ExecuteNonQuery()

                For i = 0 To gdSubjects.Rows.Count - 1

                If CType(gdSubjects.Rows(i).FindControl("chkSelectSubject"), CheckBox).Checked Then
                    chckdcount += 1

                    sql = "spInsertSubReg"
                    cmd = New SqlCommand(sql, cnn, trans)
                    cmd = New SqlCommand(sql, cnn, trans)
                    cmd.CommandType = CommandType.StoredProcedure

                    parameters = New List(Of SqlParameter)
                    param = New SqlParameter("@stud", txtEmail.Text)
                    parameters.Add(param)

                    param = New SqlParameter("@sub", CType(gdSubjects.Rows(i).FindControl("lbsubjectid"), Label).Text)
                    parameters.Add(param)



                    param = New SqlParameter("@AppRef", ref)
                    parameters.Add(param)



                    For Each par As SqlParameter In parameters
                        cmd.Parameters.Add(par)
                    Next
                    cmd.ExecuteNonQuery()
                End If
            Next



                If chckdcount = 0 Then
                    btnLoadingPopUp_ModalPopupExternder.Hide()
                    lblAppSubmitResult.Text = "Select at Least 1(one) subject for registration"
                    trans.Rollback()
                    btnConfirmPopUp_ModalPopupExtender.Show()
                    Return False
                End If








            trans.Commit()
            Session("AppSaved") = "True"
            appstud.FullName = txtFirstNAme.Text & " " & txtLastName.Text
            appstud.Email = txtEmail.Text
            emailsent = SendEmail(appstud, EmailType.ApplicationSubmitted)
            Dim msg As String = "An application has been received for " & ddlCampus.Text & "-" & dpclass.Text & "-  " & dpProgram.Text & "-" & dpIntake.Text & " Intake  from " & appstud.FullName & ""
            For Each hod As Enrol In getHOD(dpSchool.Text)

                SendEmail(hod, EmailType.ApplicationReceived,, msg)
            Next
            '      lblAppSubmitResult.Text = "Application Submitted"
            btnLoadingPopUp_ModalPopupExternder.Hide()

            btnConfirmPopUp_ModalPopupExtender.Show()
            Return True
        Catch ex As Exception
            trans.Rollback()
            btnLoadingPopUp_ModalPopupExternder.Hide()
            lblAppSubmitResult.Text = "Error on Saving the Application" & ex.Message.ToString
            btnConfirmPopUp_ModalPopupExtender.Show()

        Finally
            cnn.Close()

        End Try

        Return False

    End Function


    Private Function CheckExistingApp(ByVal email)

        Dim sql As String = ""
        Dim app As SqlDataReader

        cnn = New SqlConnection(ConnectionString)


        Try
            sql = "select * from studentapplication where email =  '" & email & "' and appstatus = 'Pending' "
            cnn.Open()
            cmd = New SqlCommand(sql, cnn)
            app = cmd.ExecuteReader

            If app.HasRows Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
        Finally
            cnn.Close()

        End Try
        Return False

    End Function


    Protected Sub dpSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpSchool.SelectedIndexChanged
        Dim reader As SqlDataReader

        Try

                For i = 0 To dpProgram.Items.Count - 1
                dpProgram.Items.Clear()

            Next


            Catch ex As Exception



            End Try
            dpProgram.Items.Add(New ListItem("Select Program", "-1"))
        sql = "select forms,description from forms  where section = '" & dpSchool.Text & "' and onlineapplication = 1"
        reader = ExecuteReader(sql, True)
            While reader.Read

                dpProgram.Items.Add(New ListItem(reader(1), reader(0)))

        End While

        If dpSchool.Text = "IT" Then
            '        RegSubs.ENA = True
        Else

            '        RegSubs.Visible = True
        End If



        Session("FileType") = initfiles(ddlEntryType.Text, dpSchool.Text, dpProgram.SelectedValue)
        initGrid()
        getIntakes()
        getsessions()
    End Sub

    Protected Sub hideModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideModalPopupViaServer.Click


        btnConfirmPopUp_ModalPopupExtender.Hide()

        If Session("AppSaved") = "True" Then
            Response.Redirect("~/Student/OnlineApplication/ApplicationStatus.aspx")
            Session("AppSaved") = "False"
        End If

    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click



    End Sub
    Private Sub LoadFiles()
        Dim files As SqlDataReader


        sql = "Select * from studDocs where  appref = '" & ref & "'"
        files = ExecuteReader(sql,, True)

        If files.HasRows Then

            Docs = New List(Of csDocs)
        End If



        ''   gdFiles.DataSource = files

        '   gdFiles.DataBind()

        While files.Read
            Dim doc As New csDocs
            Dim dateuploaded As Date

            doc.StudentId = files("Stud").ToString
            doc.Filename = files("FileName").ToString
            doc.filesize = files("FileSize").ToString
            doc.FileType = files("FileType").ToString
            doc.Doc = files("Doc")
            Date.TryParse(files("DateUploaded"), dateuploaded)
            doc.dateuploaded = dateuploaded
            doc.fileref = files("FileRef").ToString 


            Docs.Add(doc)
        End While

        For rowindex = 0 To gdFiles.Rows.Count - 1
            For Each doc As csDocs In Docs
                If gdFiles.Rows(rowindex).Visible Then




                    If doc.Filename = CType(gdFiles.Rows(rowindex).FindControl("lbfilename"), LinkButton).Text Then


                        CType(gdFiles.Rows(rowindex).FindControl("lbfiletype"), Label).Text = doc.FileType
                        CType(gdFiles.Rows(rowindex).FindControl("lbdateuploaded"), Label).Text = doc.dateuploaded.ToShortDateString
                        CType(gdFiles.Rows(rowindex).FindControl("lbfilesize"), Label).Text = doc.filesize
                        CType(gdFiles.Rows(rowindex).FindControl("lbfileref"), Label).Text = doc.fileref
                    End If



                End If



            Next

        Next




    End Sub

    Protected Sub gdFiles_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdFiles.RowCommand
        Dim rowindex As Integer

        Docs = CType(Session("Docs"), List(Of csDocs))

        If e.CommandName = "DeleteFiles" Then

            rowindex = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow).RowIndex
            If Docs.Count > 0 Then
                Dim cnt As Integer = 0
                For Each doc In Docs







                    If doc.Filename = CType(gdFiles.Rows(rowindex).FindControl("lbfilename"), LinkButton).Text Then
                        doc.deleted = True
                        CType(gdFiles.Rows(rowindex).FindControl("lbfiletype"), Label).Text = ""
                        CType(gdFiles.Rows(rowindex).FindControl("lbdateuploaded"), Label).Text = ""
                        CType(gdFiles.Rows(rowindex).FindControl("lbfilesize"), Label).Text = 0
                        CType(gdFiles.Rows(rowindex).FindControl("lbFileRef"), Label).Text = ""
                    End If

                Next

            End If

            Session("Docs") = Docs


        ElseIf e.CommandName = "UploadDoc" Then
            rowindex = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow).RowIndex

            Dim sql As String
            Dim parameters As List(Of SqlParameter)
            Dim param As SqlParameter
            Dim docsCol As SqlDataReader





            Dim uploadfile As FileUpload = CType(gdFiles.Rows(rowindex).FindControl("FileUpload1"), FileUpload)
            If uploadfile.HasFile Then
                Dim postedfile As HttpPostedFile
                Dim filename As String
                Dim ext As String
                Dim size As Double

                Dim contenttype As String
                '    Dim file2 As String
                Dim bytes() As Byte




                postedfile = uploadfile.PostedFile
                '     filename = Path.GetFileName(postedfile.FileName)
                ext = Path.GetExtension(postedfile.FileName)
                size = (postedfile.ContentLength) / (1024)
                filename = postedfile.FileName
                contenttype = postedfile.ContentType



                If ext.ToLower = ".jpg" Or ext.ToLower = ".jpeg" Or ext.ToLower = ".pdf" Or ext.ToLower = ".png" Or ext.ToLower = ".doc" Or ext.ToLower = ".docx" Then

                    Dim Stream As Stream = postedfile.InputStream
                    Dim BinaryReader As BinaryReader = New BinaryReader(Stream)
                    bytes = BinaryReader.ReadBytes(Stream.Length)



                    For Each doc As csDocs In Docs
                        If gdFiles.Rows(rowindex).Visible Then




                            If doc.Filename = CType(gdFiles.Rows(rowindex).FindControl("lbfilename"), LinkButton).Text Then
                                doc.Doc = bytes
                                doc.filesize = size
                                doc.FileType = ext
                                doc.dateuploaded = Now.Date.ToShortDateString
                                doc.deleted = False

                                CType(gdFiles.Rows(rowindex).FindControl("lbfiletype"), Label).Text = ext
                                CType(gdFiles.Rows(rowindex).FindControl("lbdateuploaded"), Label).Text = Now.Date.ToShortDateString
                                CType(gdFiles.Rows(rowindex).FindControl("lbfilesize"), Label).Text = Math.Round(size, 0)

                            End If



                        End If



                    Next


                Else
                    lblAppSubmitResult.Text = "unsupported file format"

                    btnConfirmPopUp_ModalPopupExtender.Show()

                End If
            Else
                lblAppSubmitResult.Text = "Select File to be uploaded first"

                btnConfirmPopUp_ModalPopupExtender.Show()


            End If

            '  End If


        ElseIf e.CommandName = "Download" Then

            rowindex = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow).RowIndex

            Dim fileref As String = CType(gdFiles.Rows(rowindex).FindControl("lbFileRef"), Label).Text
            Dim doc As SqlDataReader

                Dim contentype As String = ""
                Dim fil() As Byte = Nothing

            Dim filename As String = ""

            If fileref <> "" Then

                sql = "select * from dbo.fnDownloadDoc(@docref)"
                param = New SqlParameter("@docref", fileref)
                parameters = New List(Of SqlParameter)
                parameters.Add(param)
                doc = ExecuteReader(sql,, True,, parameters)

                While doc.Read
                    fil = doc("doc")
                    contentype = doc("filetype")
                    filename = doc("filename")
                End While

                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = "application/octet-stream"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + contentype)
                Response.BinaryWrite(fil)
                Response.Flush()
                Response.End()
            Else
                lblAppSubmitResult.Text = "Document cannot be downloaded yet , it has not been uploaded onto the server"

                btnConfirmPopUp_ModalPopupExtender.Show()

            End If

        End If
    End Sub

    Protected Sub ddlEntryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEntryType.SelectedIndexChanged
        Session("FileType") = initfiles(ddlEntryType.Text, dpSchool.Text, dpProgram.SelectedValue)
        initGrid()


    End Sub

    Protected Sub dpProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpProgram.SelectedIndexChanged
        If dpSchool.Text = "Business School" Then
            getSubjects()
        Else
            getSubjects()
        End If
        Session("FileType") = initfiles(ddlEntryType.Text, dpSchool.Text, dpProgram.SelectedValue)
        initGrid()
        getIntakes()
        getsessions()
    End Sub
    Private Sub getSubjects()
        Dim subjects As SqlDataReader
        sql = "spGetProgramSubjects_Level"
        Dim cnn As New SqlConnection(ConnectionString)
        Try
            cnn.Open()

            Dim cmd As New SqlCommand(sql, cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@prog", dpProgram.SelectedValue)
                .Parameters.AddWithValue("@lvl", dpLevel.Text)
                .Parameters.AddWithValue("@sem", dpSemester.Text)

                subjects = .ExecuteReader()
            End With



            gdSubjects.DataSource = subjects
            gdSubjects.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cnn.Close()

        End Try



        '    SubjectsPopup_ModalPopupExtender.Show()

    End Sub
    Private Sub getsessions()
        Dim progcount As Integer = 0
        Dim sql As String
        Dim docs As SqlDataReader
        DpSession.Items.Clear()


        DpSession.Items.Add(New ListItem("Select Session", "-1"))


        Dim j As Integer = 0
        sql = "select distinct [session] from progsessions where school = '" & dpSchool.Text & "' and program = '" & dpProgram.SelectedValue & "' "

        docs = ExecuteReader(sql,, True)
        While docs.Read
            DpSession.Items.Add(docs(0))

        End While
    End Sub

    Private Sub LoadKnowHow()
        Dim progcount As Integer = 0
        Dim sql As String
        Dim docs As SqlDataReader
        dpKnowhow.Items.Clear()


        dpKnowhow.Items.Add(New ListItem("How did you know about Trust Academy?", "-1"))


        Dim j As Integer = 0
        sql = "select distinct mode from knowhow order by mode asc  "

        docs = ExecuteReader(sql,, True)
        While docs.Read
            dpKnowhow.Items.Add(docs(0))

        End While

    End Sub

    Private Sub getIntakes()
        Dim progcount As Integer = 0
        Dim sql As String
        Dim docs As SqlDataReader
        dpclass.Items.Clear()
        dpIntake.Items.Clear()

        dpclass.Items.Add(New ListItem("Select Class", "-1"))
        dpIntake.Items.Add(New ListItem("Select Intake", "-1"))

        Dim j As Integer = 0
        sql = "select distinct clas, intake from progintks where school = '" & dpSchool.Text & "' and program = '" & dpProgram.SelectedValue & "' and [active] = 1"

        docs = ExecuteReader(sql,, True)
        While docs.Read
            dpIntake.Items.Add(docs(1))
            dpclass.Items.Add(docs(0))
        End While
        'For i = 0 To dgProIntkIntakes.Rows.Count - 2

    End Sub

    Protected Sub txtFirstNAme_TextChanged(sender As Object, e As EventArgs) Handles txtFirstNAme.TextChanged
        If txtFirstNAme.Text <> "" Then
            lbFirstName.Visible = True
        Else
            lbFirstName.Visible = False
        End If
        NXTCONTROL = txtLastName
    End Sub

    Protected Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        lbLastName.Visible = IIf(txtLastName.Text = "", False, True)
        NXTCONTROL = txtDOB
    End Sub

    Protected Sub txtDOB_TextChanged(sender As Object, e As EventArgs) Handles txtDOB.TextChanged
        lbdob.Visible = IIf(txtDOB.Text = "", False, True)
    End Sub

    Protected Sub txtPOB_TextChanged(sender As Object, e As EventArgs) Handles txtPOB.TextChanged

        lbLastName.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        lbEmail.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtcontact_TextChanged(sender As Object, e As EventArgs) Handles txtcontact.TextChanged
        lbContact.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub TxtNationalID_TextChanged(sender As Object, e As EventArgs) Handles TxtNationalID.TextChanged
        lbNationalID.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtoccupation_TextChanged(sender As Object, e As EventArgs) Handles txtoccupation.TextChanged
        lbOccupation.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtworkphone_TextChanged(sender As Object, e As EventArgs) Handles txtworkphone.TextChanged
        lbWorkPhone.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtAdd1_TextChanged(sender As Object, e As EventArgs) Handles txtAdd1.TextChanged
        lbAddress1.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtAdd2_TextChanged(sender As Object, e As EventArgs) Handles txtAdd2.TextChanged
        lbAddress2.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtAddress4_TextChanged(sender As Object, e As EventArgs) Handles txtAddress4.TextChanged
        lbAddress3.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtWorkAddress_TextChanged(sender As Object, e As EventArgs) Handles txtWorkAddress.TextChanged
        lbWorkAddress.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtNokName_TextChanged(sender As Object, e As EventArgs) Handles txtNokName.TextChanged
        lbNokName.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtNokAddress_TextChanged(sender As Object, e As EventArgs) Handles txtNokAddress.TextChanged
        lbNokAddress.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtNokContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtNokContactNumber.TextChanged
        lbNokContactNumber.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtNokEmail_TextChanged(sender As Object, e As EventArgs) Handles txtNokEmail.TextChanged
        lbNokEmail.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged
        lbRemarks.Visible = IIf(CType(sender, TextBox).Text = "", False, True)
    End Sub

    Protected Sub ddlCampus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCampus.SelectedIndexChanged

    End Sub


    Protected Sub wzAppForm_FinishButtonClick(sender As Object, e As WizardNavigationEventArgs) Handles wzAppForm.FinishButtonClick

        'If Page.IsValid Then



        '    If CheckExistingApp(Session("Email")) Then
        '        appsaved = False
        '        btnLoadingPopUp_ModalPopupExternder.Hide()
        '        lblAppSubmitResult.Text = "Application cannot be submitted, you have a Pending application. " & vbNewLine & "Please contact Trust Academy's admissions department to get the status of the application or check the status of your application status on the portal. "
        '        btnConfirmPopUp_ModalPopupExtender.Show()
        '    Else

        '        errorstatus.Text = ""
        '        If submitapp() Then
        '            '   lblAppSubmitResult.Text = "Application Submitted" & IIf(Not emails'ent, " ,email could not be sent. ", " ,please check your your email for proceeding steps.")
        '            lblAppSubmitResult.Text = "Application Submitted ,please check your your email for proceeding steps."
        '        End If
        '    End If




        'Else
        '    errorstatus.Text = "Validation Failed"
        'End If

    End Sub

    Protected Sub wzAppForm_CancelButtonClick(sender As Object, e As EventArgs) Handles wzAppForm.CancelButtonClick


        Response.Redirect("~/Student/OnlineApplication/ApplicationForm.aspx")
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Session("AppSaved") = "False"
        If Page.IsValid Then



            If CheckExistingApp(Session("Email")) Then
                Session("AppSaved") = "False"
                btnLoadingPopUp_ModalPopupExternder.Hide()
                lblAppSubmitResult.Text = "Application cannot be submitted, you have a Pending application. " & vbNewLine & "Please contact Trust Academy's admissions department to get the status of the application or check the status of your application status on the portal. "
                btnConfirmPopUp_ModalPopupExtender.Show()
            Else

                errorstatus.Text = ""
                If submitapp() Then
                    '   lblAppSubmitResult.Text = "Application Submitted" & IIf(Not emails'ent, " ,email could not be sent. ", " ,please check your your email for proceeding steps.")
                    lblAppSubmitResult.Text = "Application Submitted ,please check your your email for proceeding steps."
                End If
            End If




        Else
            errorstatus.Text = "Validation Failed"
        End If

    End Sub

    Protected Sub wzAppForm_NextButtonClick(sender As Object, e As WizardNavigationEventArgs)

    End Sub

    Protected Sub gdFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gdFiles.SelectedIndexChanged

    End Sub

    Protected Sub dpLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpLevel.SelectedIndexChanged, dpSemester.SelectedIndexChanged
        getSubjects()
    End Sub


End Class