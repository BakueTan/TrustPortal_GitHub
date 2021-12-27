Imports System.Data.SqlClient
Public Class frmUserAdmin
    Inherits System.Web.UI.Page
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = "ResetPassword"
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim sql As String
        Dim cnn As New SqlConnection(ConnectionString)

        If Page.IsValid Then
            Try



                cnn.Open()
                sql = "spResetStudentPassword"
                Dim cmd As New SqlCommand(sql, cnn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@acc", Trim(txtUserName.Text))
                    .Parameters.AddWithValue("@password", Trim(txtPassword.Text))
                    .ExecuteNonQuery()
                    lbreset.Text = "Student Password reset successful"
                End With

            Catch ex As Exception
                lbreset.Text = ex.Message
            Finally
                cnn.Close()

            End Try







        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        txtPassword.Text = ""
        txtUserName.Text = ""

    End Sub
End Class