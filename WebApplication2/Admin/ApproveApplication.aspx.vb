Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class ApproveApplication
    Inherits System.Web.UI.Page
    Public sql As String
    Public cnn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
    Public cmd As SqlCommand
    Public drr As SqlDataReader
    Private appstud As New Enrol
    Protected Sub Page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Session("AppReference")

        Session("ActivePage") = ""
        If Not Page.IsPostBack Then
            txtFirstNAme.text = Session("FirstName")
            txtLastName.Text = Session("LastName")
            txtEmail.Text = Session("Email")
            txtgender.Text = Session("Gender")
            txtcontact.Text = Session("Contact")
            txtIntake.Text = Session("Intake")
            txtProgram.Text = Session("Program")
            txtclass.Text = Session("Class")
            txtSession.Text = Session("Session")
            txtDOB.Text = Session("DOB")
            txtAdd1.Text = Session("Address")
            txtcontact.Text = Session("Contact")
            txtIncome.Text = Session("IncomeSource")
            txtKnowhow.Text = Session("KnowHow")
            txtoccupation.Text = Session("Occupation")
            txtworkphone.Text = Session("WorkPhone")
            txtWorkAddress.Text = Session("WorkAddress")
            DpChangeStatus.Text = Session("AppStatus")
            TextComment.Text = Session("Comment")
            txtDateApplicationSubmitted.Text = Session("DateSubmitted")
            txtAppRef.Text = Session("AppReference")
            TextComment.Text = Session("Comment")
            txtSchool.Text = Session("School")
            txtSemester.Text = Session("Semester")
            txtLevel.Text = Session("Level")
            txtRemarks.Text = Session("Remarks")
            txtStudentResponse.Text = Session("ApplicationAccepted")
            txtStudentID.Text = Session("StudentID")
            txtNokName.Text = Session("NokName")
            TxtNokAdddress.Text = Session("NokAddress")
            txtNokContact.Text = Session("NokContact")
            txtNokEmail.Text = Session("NokEmail")
            txtEntryType.Text = Session("EntryType")
            txtPreviousEnrollment.Text = IIf(Session("PreviousEnrollment") = "True", "Yes", "No")
            txtCampus.Text = Session("Campus")
            If Session("AppStatus") = "Approved" Then

                btnCancel.Visible = True
                btnUpdateApplication.Visible = True
                lbMessage.Visible = False
                TxtDateDecisionMade.Text = Session("DateUpdated")
                txtDateStudentResponded.Text = Session("DateAccepted")
                DpChangeStatus.Items.Remove("Decision Withheld")
                DpChangeStatus.Items.Remove(Session("AppStatus"))
                DpChangeStatus.Items.Remove("Declined")
            ElseIf Session("AppStatus") = "Declined" Then
                btnCancel.Visible = True
                btnUpdateApplication.Visible = True
                lbMessage.Visible = False
                TxtDateDecisionMade.Text = Session("DateUpdated")
                txtDateStudentResponded.Text = Session("DateAccepted")
                DpChangeStatus.Items.Remove("Decision Withheld")
                DpChangeStatus.Items.Remove(Session("AppStatus"))
                DpChangeStatus.Items.Remove("Approved")

            ElseIf Session("AppStatus") = "Decision Withdrawn" Then
                btnCancel.Visible = False
                btnUpdateApplication.Visible = True
                lbMessage.Visible = False
                btnCancel.Visible = True
                btnUpdateApplication.Visible = True
                DpChangeStatus.Items.Remove(Session("AppStatus"))

            ElseIf Session("AppStatus") = "Application Withdrawn" Then
                DpChangeStatus.Items.Remove("Decision Withheld")
                DpChangeStatus.Items.Remove("Approved")
                DpChangeStatus.Items.Remove("Declined")
                DpChangeStatus.Items.Remove("Decision Withdrawn")
                btnCancel.Visible = False
                btnUpdateApplication.Visible = False
            Else

                DpChangeStatus.Items.Remove("Decision Withdrawn")
                btnCancel.Visible = True
                btnUpdateApplication.Visible = True
                lbMessage.Visible = False
                TxtDateDecisionMade.Text = Session("DateUpdated")
            End If

            LoadFiles()
            loadsubjects()
        End If
    End Sub

    Private Sub loadsubjects()
        Dim subjects As SqlDataReader
        sql = "SELECT  concat(row_number () over (order by s.subjectid ),'.',' ',  s.Subject) as Subject FROM StudSubs AS st INNER JOIN Subjects AS s ON s.SubjectID = st.subjectid WHERE (st.AppRef = '" & Session("AppReference") & "')"
        subjects = ExecuteReader(sql,, True)
        dgSubjects.DataSource = subjects
        dgSubjects.DataBind()

        If Session("School") = "Business School" Then
            dgSubjects.Visible = True
        Else
            dgSubjects.Visible = True
        End If
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





    Protected Sub hideModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideModalPopupViaServer.Click
        btnConfirmPopUp_ModalPopupExtender.Hide()
        Response.Redirect("~/Admin/ApproveApplication.aspx")
    End Sub


    Private Sub LoadFiles()
        Dim files As SqlDataReader


        sql = "Select * from studDocs where appref = '" & Session("AppReference") & "'"
        files = ExecuteReader(sql,, True)


        gdFiles.DataSource = files

        gdFiles.DataBind()

    End Sub

    Protected Sub btnUpdateApplication_Click(sender As Object, e As EventArgs) Handles btnUpdateApplication.Click
        Dim sql As String
        appstud.FullName = txtFirstNAme.Text & " " & txtLastName.Text
        appstud.Email = txtEmail.Text

        Try

            If Session("AppReference") <> "" Then
                parameters = New List(Of SqlParameter)
                param = New SqlParameter("@comment", TextComment.Text)
                parameters.Add(param)

                sql = "update studentApplication set appstatus = '" & DpChangeStatus.Text & "',dateupdated = '" & changedate(Now.Date.ToShortDateString) & "',updatedby = '" & Session("UserName") & "',comment = @comment  where appreference ='" & Session("AppReference") & "'"



                ExecuteNonQuery(sql, , True,,,,, parameters)
                If Not era Then
                    lblAppSubmitResult.Text = "Status Updated"
                    btnConfirmPopUp_ModalPopupExtender.Show()

                    SendEmail(appstud, EmailType.DecisionMade)

                    Session("AppStatus") = DpChangeStatus.Text
                    Session("Comment") = TextComment.Text
                Else
                    lblAppSubmitResult.Text = "Error on updating the Application" & eramsg
                    btnConfirmPopUp_ModalPopupExtender.Show()
                End If

            Else
                lblAppSubmitResult.Text = "Inavlid Reference"
                btnConfirmPopUp_ModalPopupExtender.Show()
            End If
        Catch ex As Exception
            lblAppSubmitResult.Text = ex.Message
            btnConfirmPopUp_ModalPopupExtender.Show()
        End Try

    End Sub

    Protected Sub gdFiles_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdFiles.RowCommand
        If e.CommandName = "Download" Then
            Dim doc As SqlDataReader

            Dim contentype As String = ""
            Dim fil() As Byte = Nothing

            Dim filename As String = ""

            sql = "select * from dbo.fnDownloadDoc(@docref)"
            param = New SqlParameter("@docref", e.CommandArgument)
            parameters = New List(Of SqlParameter)
            parameters.Add(param)
            doc = ExecuteReader(sql,, True,, parameters)

            While doc.Read
                fil = doc("doc")
                contentype = doc("filetype")
                filename = doc("filename")
            End While

            'imgStud.ImageUrl = "data:application/octet-stream;base64," + Convert.ToBase64String(fil)

            'SubjectsPopup_ModalPopupExtender.Show()
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/octet-stream"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + contentype)
            Response.BinaryWrite(fil)
            Response.Flush()
            Response.End()
        End If
    End Sub

    Protected Sub gdFiles_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gdFiles.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblDateSub As Label = CType(e.Row.FindControl("Label2"), Label)
            Dim datesub As Date = Convert.ToDateTime(lblDateSub.Text)
            lblDateSub.Text = datesub.ToShortDateString()

            Dim lblFize As Label = CType(e.Row.FindControl("Label1"), Label)
            Dim filesize As Double

            Double.TryParse(lblFize.Text, filesize)
            lblFize.Text = Math.Round(filesize, 0)



        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Admin/ViewApllications.aspx")
    End Sub
End Class