Public Class ApplicationStatus
    Inherits System.Web.UI.Page
    Private appstud As New Enrol

    Private Sub ApplicationStatus_Init(sender As Object, e As System.EventArgs) Handles Me.Init





    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Email") <> "" Then
            Session("ActivePage") = "MyApplications"
        Else
            Response.Redirect("~/SessionExpired.aspx")
        End If

    End Sub

    Private Sub GetApplications()

        sql = " select isnull(appstatus,0),passwordreset, dbo.StudOfferAcceptence(dateaccepted,ApllicationAccepted) from StudentApplication " &
               " where email = '" & Session("Email") & "'"


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim rowindex As Integer = 0
        Dim clas As String = ""
        Dim prog As String = ""
        Dim intk As String = ""
        Dim school As String = ""
        Dim firstName As String = ""
        Dim LastName As String = ""
        ' dex
        If e.CommandName = "View" Then
            rowindex = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow).RowIndex
            Session("Reference") = CType(GridView1.Rows(rowindex).FindControl("lbAppReference"), Label).Text
            Session("StudentOfferAcceptance") = CType(GridView1.Rows(rowindex).FindControl("lbAppicationAccepted"), Label).Text
            Session("Status") = CType(GridView1.Rows(rowindex).FindControl("lbAppStatus"), Label).Text
            Session("School") = CType(GridView1.Rows(rowindex).FindControl("lbSchool"), Label).Text
            Session("Class") = CType(GridView1.Rows(rowindex).FindControl("lbClass"), Label).Text
            Session("Program") = CType(GridView1.Rows(rowindex).FindControl("lbProgram"), Label).Text
            Session("Intake") = CType(GridView1.Rows(rowindex).FindControl("lbIntake"), Label).Text
            LastName = CType(GridView1.Rows(rowindex).FindControl("lbLastName"), Label).Text
            If Session("Status") = "Approved" Then
                Response.Redirect("~/Student/OnlineApplication/OfferLetter.aspx")
            ElseIf Session("Status") = "Declined" Then
                Response.Redirect("~/Student/OnlineApplication/DeclineLetter.aspx")
            Else
                Response.Redirect("~/Student/OnlineApplication/PendingDecision.aspx")
            End If

        ElseIf e.CommandName = "WithDraw" Then
            rowindex = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow).RowIndex
            Session("Reference") = CType(GridView1.Rows(rowindex).FindControl("lbAppReference"), Label).Text
            Session("StudentOfferAcceptance") = CType(GridView1.Rows(rowindex).FindControl("lbAppicationAccepted"), Label).Text
            Session("Status") = CType(GridView1.Rows(rowindex).FindControl("lbAppStatus"), Label).Text
            clas = CType(GridView1.Rows(rowindex).FindControl("lbClass"), Label).Text
            prog = CType(GridView1.Rows(rowindex).FindControl("lbProgram"), Label).Text
            school = CType(GridView1.Rows(rowindex).FindControl("lbSchool"), Label).Text
            intake = CType(GridView1.Rows(rowindex).FindControl("lbIntake"), Label).Text
            LastName = CType(GridView1.Rows(rowindex).FindControl("lbLastName"), Label).Text

            firstName = CType(GridView1.Rows(rowindex).FindControl("lbFirstName"), Label).Text
            If Session("Status") = "Pending" Then
                sql = "update studentapplication set [appstatus] = 'Application Withdrawn' where appreference ='" & Session("Reference") & "'"
                ExecuteNonQuery(sql,, True)
                GridView1.DataBind()
                lbStatusError.Text = "Application Successfully Withdrawn"
                appstud.FullName = firstName & " " & LastName
                appstud.Email = Session("Email")
                Dim emailsent As Boolean = SendEmail(appstud, EmailType.ApplicationWithDrawn)
                Dim msg As String = "An application has been withdrawn for " & clas & "-  " & prog & "-" & intake & " Intake  from " & appstud.FullName & ""
                For Each hod As Enrol In getHOD(school)

                    SendEmail(hod, EmailType.ApplicationWithDrawn,, msg)
                Next
            Else
                lbStatusError.Text = "Application can not be WithDrawn"
            End If
        ElseIf e.CommandName = "UpdateApp" Then
            rowindex = CType(CType(e.CommandSource, LinkButton).NamingContainer, GridViewRow).RowIndex
            Session("Reference") = CType(GridView1.Rows(rowindex).FindControl("lbAppReference"), Label).Text
            Response.Redirect("~/Student/OnlineApplication/ApplicationForm.aspx?Ref=" & Session("Reference") & "")



        End If
    End Sub



    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblDateSub As Label = CType(e.Row.FindControl("lblDateSubmitted"), Label)
            Dim datesub As Date = Convert.ToDateTime(lblDateSub.Text)
            lblDateSub.Text = datesub.ToShortDateString()

            Dim lblDateDec As Label = CType(e.Row.FindControl("lbDateDecisionMade"), Label)
            Dim dateDec As Date
            Date.TryParse(lblDateDec.Text, dateDec)
            Try
                lblDateDec.Text = dateDec.ToShortDateString()
            Catch ex As Exception
                lblDateDec.Text = "-"
            End Try

            Dim lbdDecision As Label = CType(e.Row.FindControl("lbAppstatus"), Label)
            If lbdDecision.Text = "Pending" Or lbdDecision.Text = "Updated" Then

                lbdDecision.BackColor = Drawing.Color.Yellow
            ElseIf lbdDecision.Text = "Decision Withheld" Then


                lbdDecision.BackColor = Drawing.Color.Orange
            ElseIf lbdDecision.Text = "Declined" Or lbdDecision.Text = "Decision Withdrawn" Then

                lbdDecision.BackColor = Drawing.Color.Red
            ElseIf lbdDecision.Text = "Approved" Then


                lbdDecision.BackColor = Drawing.Color.Green

            End If
        End If

    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit

    End Sub
End Class