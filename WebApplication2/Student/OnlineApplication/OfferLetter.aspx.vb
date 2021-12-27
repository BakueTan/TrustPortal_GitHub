Imports System.Data.SqlClient
Imports System.IO

Public Class OfferLetter
    Inherits System.Web.UI.Page



    Private appstud As New Enrol


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAcceptOffer.Visible = False
        btnDeclineOffer.Visible = False
        Session("ActivePage") = ""
        If Trim(Session("StudentOfferAcceptance")) = "Pending" Then
            lbAcccept.Text = "Accept or Decline the Offer To Complete the Application Process"
            btnAcceptOffer.Visible = True
            btnDeclineOffer.Visible = True
            lbacceptanceslip.Visible = True
            fuOfferSlip2.Visible = True
        ElseIf Trim(Session("StudentOfferAcceptance")) = "Accepted" Then
            lbAcccept.Text = "You already accepted the offer"
        ElseIf Trim(Session("StudentOfferAcceptance")) = "Declined" Then
            lbAcccept.Text = "You already declined the offer"
        End If
    End Sub

    Protected Sub btnAcceptOffer_Click(sender As Object, e As EventArgs) Handles btnAcceptOffer.Click
        appstud.FullName = Session("userName")
        appstud.Email = Session("Email")
        Dim trans As SqlTransaction


        Try
            If Not IsNothing(postedfile) Then


                Dim filename As String
                Dim ext As String
                Dim size As Double

                Dim contenttype As String
                '    Dim file2 As String
                Dim bytes() As Byte

                Dim cnn As New SqlConnection(ConnectionString)
                Try


                    cnn.Open()
                    trans = cnn.BeginTransaction

                    sql = "spInsertDoc"
                    Dim cmd As New SqlCommand(sql, cnn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Transaction = trans

                    ext = Path.GetExtension(postedfile.FileName)
                    size = (postedfile.ContentLength) / (1024)
                    filename = postedfile.FileName
                    Dim BinaryReader As BinaryReader = New BinaryReader(postedfile.InputStream)
                    bytes = BinaryReader.ReadBytes(postedfile.InputStream.Length)


                    parameters = New List(Of SqlParameter)
                    param = New SqlParameter("@stud", appstud.Email)
                    parameters.Add(param)

                    param = New SqlParameter("@docname", "AcceptanceSlip")
                    parameters.Add(param)

                    param = New SqlParameter("@doc", bytes)
                    parameters.Add(param)

                    param = New SqlParameter("@filetype", ext)
                    parameters.Add(param)

                    param = New SqlParameter("@filesize", size)
                    parameters.Add(param)

                    param = New SqlParameter("@AppRef", Session("Reference"))
                    parameters.Add(param)

                    param = New SqlParameter("@fileref", Guid.NewGuid.ToString)
                    parameters.Add(param)

                    For Each par In parameters
                        cmd.Parameters.Add(par)
                    Next

                    cmd.ExecuteNonQuery()




                    sql = "SpAcceptOffer"
                    cmd = New SqlCommand(sql, cnn)
                    cmd.Transaction = trans
                    cmd.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@appref", Session("Reference"))

                    cmd.Parameters.Add(param)

                    param = New SqlParameter()
                    param.ParameterName = "@stud"
                    param.Direction = ParameterDirection.Output
                    param.Size = 50
                    param.DbType = DbType.String

                    cmd.Parameters.Add(param)





                    cmd.ExecuteNonQuery()

                    appstud.Student = cmd.Parameters("@stud").Value


                    trans.Commit()
                    SendEmail(appstud, EmailType.StudentIDAssigned)

                    Dim msg As String = "Offer Accepted for " & Session("Class") & "-  " & Session("Program") & "-" & Session("Intake") & " Intake  from " & appstud.FullName & "." & vbNewLine & " And the Student has been automatically assigned StudentID:  " & appstud.Student
                    For Each hod As Enrol In getHOD(Session("School"))

                        SendEmail(hod, EmailType.StudentAccepted,, msg)
                    Next
                    Session("StudentOfferAcceptance") = "Accepted"

                    lblAppSubmitResult.Text = "Status Updated"
                    btnConfirmPopUp_ModalPopupExtender.Show()

                Catch ex As Exception
                    lblAppSubmitResult.Text = "Offer cannot be accepted please contact Trust Academy for support" & vbNewLine & ex.Message
                    btnConfirmPopUp_ModalPopupExtender.Show()
                    trans.Rollback()
                Finally
                    cnn.Close()

                End Try




            Else
                lblAppSubmitResult.Text = "Please upload signed Acceptance Slip"
                '       trans.Rollback()
                btnConfirmPopUp_ModalPopupExtender.Show()
                Exit Sub
            End If

        Catch ex As Exception
            lblAppSubmitResult.Text = "Offer cannot be accepted please contact Trust Academy for support " & vbNewLine & ex.Message
            btnConfirmPopUp_ModalPopupExtender.Show()

        End Try


    End Sub



    Protected Sub btnDeclineOffer_Click(sender As Object, e As EventArgs) Handles btnDeclineOffer.Click



        appstud.FullName = Session("userName")
        appstud.Email = Session("Email")

        sql = "update studentapplication set ApllicationAccepted = 0 ,dateaccepted = '" & changedate(Now.Date.ToShortDateString) & "' where appreference = '" & Session("Reference") & "'"

                    ExecuteNonQuery(sql,, True)
        If Not era Then
            SendEmail(appstud, EmailType.StudentDeclined)
            lblAppSubmitResult.Text = "Status updated"
            Session("StudentOfferAcceptance") = "Declined"
            Dim msg As String = "Offer Declined " & Session("Class") & "-  " & Session("Program") & "-" & Session("Intake") & " Intake  from " & appstud.FullName & ""
            For Each hod As Enrol In getHOD(Session("School"))

                SendEmail(hod, EmailType.StudentDeclined,, msg)
            Next
            btnConfirmPopUp_ModalPopupExtender.Show()
            Exit Sub
        Else
            lblAppSubmitResult.Text = eramsg
            '       trans.Rollback()
            btnConfirmPopUp_ModalPopupExtender.Show()
            Exit Sub
        End If


    End Sub
    Protected Sub hideModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideModalPopupViaServer.Click
        btnConfirmPopUp_ModalPopupExtender.Hide()
        Response.Redirect("~/Student/OnlineApplication/OfferLetter.aspx")
    End Sub

    Protected Sub fuOfferSlip2_UploadedComplete(sender As Object, e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles fuOfferSlip2.UploadedComplete
        If fuOfferSlip2.HasFile Then
            postedfile = fuOfferSlip2.PostedFile
        End If
    End Sub
End Class