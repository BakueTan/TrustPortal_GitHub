Imports System.Data.SqlClient
Public Class WebForm12
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = "ViewApplications"

        If Not Page.IsPostBack Then




            If Trim(Session("GroupName")) = "HOD_IT" Then
                Session("School") = "IT"
            ElseIf Trim(Session("GroupName")) = "HOD_BusSchool" Then
                Session("School") = "Business School"
            ElseIf Trim(Session("GroupName")) = "Registrar" Or Trim(Session("GroupName")) = "Admissions Office" Then
                Session("School") = "ALL"
            Else
                Session("School") = ""
            End If

            '    loadPrograms()
        End If
    End Sub
    Private Sub loadPrograms()
        Dim reader As SqlDataReader
        Try

            For i = 0 To ddlAppIntake.Items.Count - 1
                ddlAppIntake.Items.RemoveAt(i)
                i = -1
            Next


        Catch ex As Exception



        End Try

        Select Case Session("School")
            Case "ICT"

                'ddlAppProgram.Items.Add(New ListItem("Select Program", "-1"))
                sql = "select forms from forms  where section = 'IT'"
                reader = ExecuteReader(sql, True)
                While reader.Read

                    ddlAppIntake.Items.Add(New ListItem(reader(0), reader(0)))

                End While


            Case "Business School"

                'ddlAppProgram.Items.Add(New ListItem("Select Program", "-1"))
                sql = "select forms from forms where section = 'Business School'"
                reader = ExecuteReader(sql, True)
                While reader.Read

                    ddlAppIntake.Items.Add(New ListItem(reader(0), reader(0)))

                End While
        End Select
    End Sub
    Protected Sub gdApplications_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdApplications.RowCommand
        Dim rowindex As Integer = 0
        ' dex
        If e.CommandName = "ViewApplication" Then
            rowindex = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow).RowIndex
            Session("AppReference") = CType(gdApplications.Rows(rowindex).FindControl("lbAppReference"), Label).Text
            Session("FirstName") = CType(gdApplications.Rows(rowindex).FindControl("lbFirstName"), Label).Text
            Session("LastName") = CType(gdApplications.Rows(rowindex).FindControl("lbLastName"), Label).Text
            Session("Email") = CType(gdApplications.Rows(rowindex).FindControl("lbEmail"), Label).Text
            Session("Gender") = CType(gdApplications.Rows(rowindex).FindControl("lbGender"), Label).Text
            Session("Contact") = CType(gdApplications.Rows(rowindex).FindControl("lbContact"), Label).Text
            Session("Intake") = CType(gdApplications.Rows(rowindex).FindControl("lbIntake"), Label).Text
            Session("Program") = CType(gdApplications.Rows(rowindex).FindControl("lbProgram"), Label).Text
            Session("Class") = CType(gdApplications.Rows(rowindex).FindControl("lbClass"), Label).Text
            Session("Session") = CType(gdApplications.Rows(rowindex).FindControl("lbSession"), Label).Text
            Session("AppStatus") = CType(gdApplications.Rows(rowindex).FindControl("lbAppStatus"), Label).Text
            Session("Comment") = CType(gdApplications.Rows(rowindex).FindControl("lbComment"), Label).Text
            Session("DateSubmitted") = CType(gdApplications.Rows(rowindex).FindControl("lbDateSubmitted"), Label).Text
            Session("School") = CType(gdApplications.Rows(rowindex).FindControl("lbSchool"), Label).Text
            Session("ApplicationAccepted") = CType(gdApplications.Rows(rowindex).FindControl("lbApplicationAccepted"), Label).Text
            Session("DateAccepted") = CType(gdApplications.Rows(rowindex).FindControl("lbDateAccepted"), Label).Text
            Session("DOB") = CType(gdApplications.Rows(rowindex).FindControl("lbDob"), Label).Text
            Session("Address") = CType(gdApplications.Rows(rowindex).FindControl("lbAddress"), Label).Text
            Session("Contact") = CType(gdApplications.Rows(rowindex).FindControl("lbContact"), Label).Text
            Session("IncomeSource") = CType(gdApplications.Rows(rowindex).FindControl("lbIncomeSource"), Label).Text
            Session("KnowHow") = CType(gdApplications.Rows(rowindex).FindControl("lbKnowHow"), Label).Text
            Session("Occupation") = CType(gdApplications.Rows(rowindex).FindControl("lbOccupation"), Label).Text
            Session("WorkPhone") = CType(gdApplications.Rows(rowindex).FindControl("lbWorkPhone"), Label).Text
            Session("WorkAddress") = CType(gdApplications.Rows(rowindex).FindControl("lbWorkAddress"), Label).Text
            Session("DateUpdated") = CType(gdApplications.Rows(rowindex).FindControl("lbdateupdated"), Label).Text
            Session("UpdatedBy") = CType(gdApplications.Rows(rowindex).FindControl("lbupdatedby"), Label).Text
            Session("School") = CType(gdApplications.Rows(rowindex).FindControl("lbSchool"), Label).Text
            Session("Level") = CType(gdApplications.Rows(rowindex).FindControl("lbLevel"), Label).Text
            Session("Semester") = CType(gdApplications.Rows(rowindex).FindControl("lbSemester"), Label).Text
            Session("Remarks") = CType(gdApplications.Rows(rowindex).FindControl("lbRemarks"), Label).Text
            Session("StudentID") = CType(gdApplications.Rows(rowindex).FindControl("lbStudentID"), Label).Text
            Session("PreviousEnrollment") = CType(gdApplications.Rows(rowindex).FindControl("lbPreviousEnrollment"), Label).Text
            Session("EntryType") = CType(gdApplications.Rows(rowindex).FindControl("lbEntryType"), Label).Text
            Session("NokName") = CType(gdApplications.Rows(rowindex).FindControl("lbNokName"), Label).Text
            Session("NokAddress") = CType(gdApplications.Rows(rowindex).FindControl("lbAddress"), Label).Text
            Session("NokContact") = CType(gdApplications.Rows(rowindex).FindControl("lbNokContact"), Label).Text
            Session("NokEmail") = CType(gdApplications.Rows(rowindex).FindControl("lbNokEmail"), Label).Text
            Session("Campus") = CType(gdApplications.Rows(rowindex).FindControl("lbCampus"), Label).Text
            Session("NationalID") = CType(gdApplications.Rows(rowindex).FindControl("lbNationalID"), Label).Text
            Response.Redirect("~/Admin/ApproveApplication.aspx")
        ElseIf e.CommandName = "AssignID" Then
            rowindex = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow).RowIndex
            Session("AppReference") = CType(gdApplications.Rows(rowindex).FindControl("lbAppReference"), Label).Text
            Session("Email") = CType(gdApplications.Rows(rowindex).FindControl("lbEmail"), Label).Text
            Session("FirstName") = CType(gdApplications.Rows(rowindex).FindControl("lbFirstName"), Label).Text
            Session("LastName") = CType(gdApplications.Rows(rowindex).FindControl("lbLastName"), Label).Text
            Response.Redirect("~/Admin/AssignStudentID.aspx")
        End If
    End Sub



    Private Sub gdApplications_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gdApplications.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblDateSub As Label = CType(e.Row.FindControl("lbDateSubmitted"), Label)
            Dim datesub As Date = Convert.ToDateTime(lblDateSub.Text)
            lblDateSub.Text = datesub.ToShortDateString()

            Dim lblDateDec As Label = CType(e.Row.FindControl("lbDateUpdated"), Label)
            Dim dateDec As Date
            Date.TryParse(lblDateDec.Text, dateDec)
            Try
                lblDateDec.Text = dateDec.ToShortDateString()
            Catch ex As Exception
                lblDateDec.Text = "-"
            End Try

            Dim lblDateDob As Label = CType(e.Row.FindControl("lbDob"), Label)
            Dim datedob As Date
            Date.TryParse(lblDateDob.Text, datedob)

            lblDateDob.Text = datedob.ToShortDateString()

            Dim lblDateAcc As Label = CType(e.Row.FindControl("lbDateAccepted"), Label)
            Dim dateAcc As Date
            Date.TryParse(lblDateAcc.Text, dateAcc)

            lblDateAcc.Text = dateAcc.ToShortDateString()


        End If
    End Sub

    Protected Sub ddlAppStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAppStatus.SelectedIndexChanged, ddlAppCampus.SelectedIndexChanged, ddlAppClass.SelectedIndexChanged, ddlAppIntake.SelectedIndexChanged,
            btnGridviewNext.Click, btnStudGridviewPrev.Click

        Dim ctrl As Control = sender
        Dim source As SqlDataReader = Nothing
        pnlGdStudDisplay.Visible = True

        If ctrl.GetType Is GetType(DropDownList) Then






            If ddlStudentSubjectsGridDisplay.Text <> "All" Then


                Session("offset") = 0



                FillApplications(Session("offset"), ddlStudentSubjectsGridDisplay.Text, btnGridviewNext, btnStudGridviewPrev, lbStudentsubjectsDisp, ddlAppStatus.Text, ddlAppClass.Text, ddlAppCampus.Text, Session("School"), ddlAppIntake.Text)
            Else

                Session("offset") = 0



                FillApplications(Session("offset"), 0, btnGridviewNext, btnStudGridviewPrev, lbStudentsubjectsDisp, ddlAppStatus.Text, ddlAppClass.Text, ddlAppCampus.Text, Session("School"), ddlAppIntake.Text)
            End If

        ElseIf ctrl.GetType Is GetType(Button) Then

            Dim clickedbtn As Button = ctrl
            If ddlStudentSubjectsGridDisplay.Text <> "All" Then

                Select Case clickedbtn.ID
                    Case btnGridviewNext.ID
                        If Session("offset") >= 0 Then
                            Session("offset") += ddlStudentSubjectsGridDisplay.Text
                        End If
                    Case btnStudGridviewPrev.ID
                        If Session("offset") > 0 Then
                            Session("offset") -= ddlStudentSubjectsGridDisplay.Text
                        Else
                            Session("offset") = 0
                        End If


                End Select

                FillApplications(Session("offset"), ddlStudentSubjectsGridDisplay.Text, btnGridviewNext, btnStudGridviewPrev, lbStudentsubjectsDisp, ddlAppStatus.Text, ddlAppClass.Text, ddlAppCampus.Text, Session("School"), ddlAppIntake.Text)
            Else
                Select Case clickedbtn.ID
                    Case btnGridviewNext.ID
                        If Session("offset") >= 0 Then
                            Session("offset") += 0
                        End If
                    Case btnStudGridviewPrev.ID
                        If Session("offset") > 0 Then
                            Session("offset") -= 0
                        Else
                            Session("offset") = 0
                        End If


                End Select
                FillApplications(Session("offset"), 0, btnGridviewNext, btnStudGridviewPrev, lbStudentsubjectsDisp, ddlAppStatus.Text, ddlAppClass.Text, ddlAppCampus.Text, Session("School"), ddlAppIntake.Text)
            End If




        End If

        '    gdApplications.DataSourceID = Nothing

        'gdApplications.DataSource = source
        gdApplications.DataBind()



        '''gdApplications.DataBind()
    End Sub

    Public Sub FillApplications(ByVal offset As Integer, ByVal filter As Integer, nextbtn As Button, prevbtn As Button, lbDisplay As Label, appstatus As String, clas As Integer, campus As String, school As String, intk As String)
        Dim drr As SqlDataReader
        Dim itms As Integer = 0
        Dim sql As String


        If filter > 0 Then
            If appstatus.ToUpper <> "ALL" Then
                If school.ToUpper <> "ALL" Then
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
        " WHERE (Active = 1) And (School = '" & school & "') AND (AppStatus = '" & appstatus & "') AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"
                Else
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
                " WHERE (Active = 1)  AND (AppStatus = '" & appstatus & "') AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"
                End If
            Else
                If school.ToUpper <> "ALL" Then
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
" WHERE (Active = 1) And (School = '" & school & "')  AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"
                Else
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
" WHERE (Active = 1)   AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"
                End If


            End If
            itms = ExecuteScalar(sql,, True)



            GridDisplayPanel(offset, filter, itms, prevbtn, nextbtn, lbDisplay)
        Else

            If appstatus.ToUpper <> "ALL" Then

                If school.ToUpper <> "ALL" Then
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
           " WHERE (Active = 1) And (School = '" & school & "') AND (AppStatus = '" & appstatus & "') AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"

                Else
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
           " WHERE (Active = 1) And  (AppStatus = '" & appstatus & "') AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"

                End If

            Else
                If school.ToUpper <> "ALL" Then
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
           " WHERE (Active = 1) And (School = '" & school & "')  AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"

                Else
                    sql = "SELECT count(*) as cnt FROM StudentApplication " &
           " WHERE (Active = 1)   AND (Intake = '" & intk & "') AND (Class = '" & clas & "' ) AND (Campus = '" & campus & "')"

                End If


            End If

            itms = ExecuteScalar(sql,, True)



            GridDisplayPanel(offset, itms, itms, prevbtn, nextbtn, lbDisplay)

        End If


        '  Return drr
    End Sub

    Protected Sub ddlAppClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAppClass.SelectedIndexChanged

    End Sub

    Protected Sub ddlAppIntake_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAppIntake.SelectedIndexChanged

    End Sub

    Protected Sub ddlAppCampus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAppCampus.SelectedIndexChanged

    End Sub

    Protected Sub ddlStudentSubjectsGridDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStudentSubjectsGridDisplay.SelectedIndexChanged
        ddlAppStatus_SelectedIndexChanged(ddlAppStatus, Nothing)
    End Sub

    Protected Sub gdApplications_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gdApplications.Sorting

    End Sub

    Protected Sub dsStudApplications_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles dsStudApplications.Selecting

    End Sub
End Class