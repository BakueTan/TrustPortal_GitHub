
Imports System.Data.SqlClient
Public Class RegConfirm
    Inherits System.Web.UI.Page
    Public cnn As SqlConnection
    Public cmd As SqlCommand
    Private appactivated As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim ref As String
        Dim sql As String


        If Not Page.IsPostBack Then
            Session("AppActivated") = "False"

            appactivated = False
            cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
            Try
                cnn.Open()
                ref = Request.QueryString("Reference")
                sql = "spConfirmRegLink"
                cmd = New SqlCommand(sql, cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@reg", ref)

                cmd.ExecuteNonQuery()
                Session("AppActivated") = "True"
                lbCreateUserResults.Text = "Application activated, Login to continue"

            Catch ex As Exception
                Session("AppActivated") = "False"
                lbCreateUserResults.Text = ex.Message
            Finally
                cnn.Close()
            End Try


            ModalPopupExtender_Creater.Show()

        End If

    End Sub

    Protected Sub hideResultsModalPopupViaServer_Click(sender As Object, e As EventArgs) Handles hideResultsModalPopupViaServer.Click
        If Session("AppActivated") = "True" Then
            Response.Redirect("~/Student/OnlineApplication/ApplicationLogin.aspx")

        End If

        ModalPopupExtender_Creater.Hide()

    End Sub
End Class