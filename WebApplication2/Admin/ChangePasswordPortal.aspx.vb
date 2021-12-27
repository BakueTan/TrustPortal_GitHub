
Imports System.Data.SqlClient

Partial Public Class WebForm3
    Inherits System.Web.UI.Page


    Protected Sub ChangePasswordPushButton_Click(sender As Object, e As EventArgs) Handles ChangePasswordPushButton.Click
        Dim cnn As New SqlConnection(ConnectionString)

        Try
            cnn.Open()
            Dim sql As String = "spChangePassword"
            Dim cmd As New SqlCommand(sql, cnn)

            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@acc", Session("userName"))
                .Parameters.AddWithValue("@oldpassword", CurrentPassword.Text)
                .Parameters.AddWithValue("@newpassword", NewPassword.Text)
                .Parameters.AddWithValue("@type", "Student")
                .ExecuteNonQuery()
                lbCreateUserResults.Text = "Password successfully changed"
            End With
        Catch ex As Exception
            lbCreateUserResults.Text = ex.Message
        Finally
            cnn.Close()


        End Try
        ModalPopupExtender_Creater.Show()
    End Sub

    Protected Sub hideResultsModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideResultsModalPopupViaServer.Click
        ModalPopupExtender_Creater.Hide()
    End Sub

    Protected Sub CancelPushButton_Click(sender As Object, e As EventArgs) Handles CancelPushButton.Click

    End Sub
End Class