Imports System.Data.SqlClient
Public Class AssignStudentID
    Inherits System.Web.UI.Page

    Private appstud As New Enrol

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = ""
        If Not Page.IsPostBack Then
            If Not Page.IsPostBack Then
                txtFirstNAme.Text = Session("FirstName") & " " & Session("LastName")

                txtAppRef.Text = Session("AppReference")
            End If
        End If
    End Sub
    Protected Sub hideModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideModalPopupViaServer.Click
        btnConfirmPopUp_ModalPopupExtender.Hide()
    End Sub
    Protected Sub btnUpdateApplication_Click(sender As Object, e As EventArgs) Handles btnUpdateApplication.Click

        Dim cnn As New SqlConnection(ConnectionString)




        '   Dim message As String = "Once again , thank you for choosing to study with us . " & vbNewLine & " Please find below the Student ID you will be using  ." & vbNewLine & "StudentID : " & txtStudentID.Text & vbNewLine & " Thank You ."
        Try
            cnn.Open()
            Dim sql As String = "spAssignStudentID"

            Dim cmd As New SqlCommand(sql, cnn)
            cmd.CommandType = CommandType.StoredProcedure

            parameters = New List(Of SqlParameter)
            param = New SqlParameter("@Appref", txtAppRef.Text)

            parameters.Add(param)

            param = New SqlParameter()
            param.ParameterName = "@outstud"
            param.Direction = ParameterDirection.Output
            param.Size = 50
            param.DbType = DbType.String
            parameters.Add(param)

            For Each par As SqlParameter In parameters
                cmd.Parameters.Add(par)
            Next

            cmd.ExecuteNonQuery()
            With appstud
                .FullName = txtFirstNAme.Text
                .Email = Session("Email")
                .Student = cmd.Parameters("@outstud").Value
            End With

            SendEmail(appstud, EmailType.StudentIDAssigned)

            lblAppSubmitResult.Text = "StudentID Assigned ID : " & appstud.Student
            btnConfirmPopUp_ModalPopupExtender.Show()

        Catch ex As Exception
            lblAppSubmitResult.Text = "Error Assigning ID " & ex.Message
            btnConfirmPopUp_ModalPopupExtender.Show()
        Finally
            cnn.Close()
        End Try


    End Sub
End Class